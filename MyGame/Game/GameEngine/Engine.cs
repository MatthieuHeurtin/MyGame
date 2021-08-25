using System;
using System.Collections.Generic;
using System.Linq;
using MyGame.DebugTools;
using MyGame.Game.Character.Characters;
using MyGame.Game.Character.Routines.Events;
using MyGame.Game.GameEngine.Events.PlayerEvent;
using MyGame.Game.Map;
using MyGame.Game.Map.Maps;

namespace MyGame.Game.GameEngine
{
    public class Engine : IDisposable
    {
        private readonly IMap _map;
        private Map.Map _mapState;
        private readonly ICharacter _player;
        private EventConsumer _eventConsumer;
        private Clock _clock;
        private readonly IEnumerable<IMap> _maps;
        private DebugConsole _dc;

        public Engine(IEnumerable<IMap> maps, bool IsDebug = false)
        {
            _maps = maps;
            _map = maps.First();
            _player = _map.Player;

            if (IsDebug) { _dc = new DebugConsole(); _dc.Show(); }
        }

        public void Start()
        {
            //Init Map
            _mapState = new Map.Map();
            _mapState.BuildMap(_map);


            _dc?.AppendText("INIT MAP");

            //add npc/item (set character to a cell) and subscribe to their events
            foreach (var element in _map.Elements)
            {
                _dc?.AppendElement(element);

                _mapState.GetViewModel().AddElement(element.Value);
                if ((element.Value as ICharacter)?.Routine != null)
                {
                    ((element.Value as ICharacter)?.Routine?.RoutinedEvent).OnRaise += AddRoutinedEvent;
                }

            }



            // PLAYERS EVENTS //
            //subscribe to events coming from the map
            _mapState.GetViewModel().RaiseMovement += Move;

            //subscribe to events coming npc/scripted events
            foreach (var entry in _mapState.GetViewModel().MapCelles)
            {
                entry.Value.RaiseClickOnCell += UpdateControlArea;
            }




            //create clock
            _clock = new Clock();

            //start event consumer (npc events only)
            _eventConsumer = new EventConsumer(_clock, _dc);
            _dc?.AppendText("START EVENT CONSUMMER");
            _eventConsumer.Start();



            //display
            _mapState.Show();



            //start clock
            _dc?.AppendText("START CLOCK");
            _clock.Start();

            //start characters routine
            _dc?.AppendText("START ROUTINES");
            foreach (var element in _map.Elements)
            {
                if ((element.Value as ICharacter)?.Routine != null)
                {
                    (element.Value as ICharacter)?.Routine.Start();
                }
            }

        }

        private void AddRoutinedEvent(object sender, EventArgs e)
        {
            string direction = (e as MovementEvent).Direction;
            string key = (e as MovementEvent).Key;
            MoveEvent p = new MoveEvent(direction, _map, _mapState, _map.Elements[key] as ICharacter);

            _dc?.AddEvent(p, direction, key);
            _eventConsumer.QueueEvent(p);
        }

        private void UpdateControlArea(object sender, EventArgs e)
        {
            string key = (e as MapCells.Common.EventParameter).Key;
            _mapState.GetViewModel().SetFocusedElement(_map.Elements[key]);
        }

        private void Move(object sender, EventArgs e)
        {
            string direction = (e as EventParameter).Param;
            MoveEvent p = new MoveEvent(direction, _map, _mapState, _player);
            p.Execute();
        }

        public void Dispose()
        {
            //Unsubscribe to events coming from the cells
            foreach (var entry in _mapState.GetViewModel().MapCelles)
            {
                entry.Value.RaiseClickOnCell -= UpdateControlArea;
            }

            //Unsubscribe to events coming from the map
            _mapState.GetViewModel().RaiseMovement += Move;

            _eventConsumer.Dispose();
            _clock.Dispose();
        }
    }
}
