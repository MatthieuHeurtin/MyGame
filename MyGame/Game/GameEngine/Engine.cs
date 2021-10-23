using System;
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
        private Map.Map _mapGui;
        private readonly ICharacter _player;
        private EventConsumer _eventConsumer;
        private Clock _clock;
        private DebugConsole _dc;

        public Engine(IMap map, bool IsDebug = false)
        {
            _map = map;
            _player = _map.Player;

            if (IsDebug) { _dc = new DebugConsole(); _dc.Show(); }
        }

        public void Start()
        {
            //Init Map
            _mapGui = new Map.Map();
            _mapGui.BuildMap(_map);

            _dc?.AppendText("INIT MAP");

            //add npc/item (set character to a cell) and subscribe to their events
            foreach (var element in _map.Elements)
            {
                _dc?.AppendElement(element);

                _mapGui.GetViewModel().AddElement(element.Value);
                if ((element.Value as ICharacter)?.Routine != null)
                {
                    ((element.Value as ICharacter)?.Routine?.RoutinedEvent).OnRaise += AddRoutinedEvent;
                }

               // element.Value.PlayerInteraction.OnRaise += 
            }



            // PLAYERS EVENTS //
            //subscribe to events coming from the map
            _mapGui.GetViewModel().RaiseMovement += Move;

            //subscribe to events coming npc/scripted events
            foreach (var entry in _mapGui.GetViewModel().MapCelles)
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
            _mapGui.Show();



            //start clock
            _dc?.AppendText("START CLOCK");


            //start characters routine
            _dc?.AppendText("START ROUTINES");
            foreach (var element in _map.Elements)
            {
                if ((element.Value as ICharacter)?.Routine != null)
                {
                    (element.Value as ICharacter)?.Routine?.Start();
                }
            }
        }


        #region events
        private void AddRoutinedEvent(object sender, EventArgs e)
        {
            string direction = (e as MovementEvent).Direction;
            string key = (e as MovementEvent).Key;

            //TODO handle several types of events, not only move
            MoveEvent p = new MoveEvent(direction, _map, _mapGui, _map.Elements[key] as ICharacter);

            _dc?.AddEvent(p, direction, key);
            _eventConsumer.QueueEvent(p);
        }

        //player events, does not go to the queue

        private void UpdateControlArea(object sender, EventArgs e)
        {
            string key = (e as MapCells.Common.EventParameter).Key;
            _mapGui.GetViewModel().SetFocusedElement(_map.Elements[key]);
        }

        //player events, does not go to the queue
        private void Move(object sender, EventArgs e)
        {
            string direction = (e as EventParameter).Param;
            MoveEvent p = new MoveEvent(direction, _map, _mapGui, _player);
            p.Execute();
        }
        #endregion

        public void Dispose()
        {
            //Unsubscribe to events coming from the cells
            foreach (var entry in _mapGui.GetViewModel().MapCelles)
            {
                entry.Value.RaiseClickOnCell -= UpdateControlArea;
            }

            //Unsubscribe to events coming from the map
            _mapGui.GetViewModel().RaiseMovement += Move;

            _eventConsumer.Dispose();
            _clock.Dispose();
        }
    }
}
