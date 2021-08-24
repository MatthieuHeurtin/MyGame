using System;
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
        
        public Engine(IMap map)
        {
            _map = map;
            _player = map.Player;
        }

        public void Start()
        {
            //Init Map
            _mapState = new Map.Map();
            _mapState.BuildMap(_map);

            //add npc/item (set character to a cell) and subscribe to their events
            foreach (var element in _map.Elements)
            {
                _mapState.GetViewModel().AddElement(element.Value);
                if ((element.Value as ICharacter)?.Routine != null)
                {
                    ((element.Value as ICharacter)?.Routine?.RoutinedEvent).OnRaise += AddRoutinedEvent;
                }

            }



            //add player
            _mapState.GetViewModel().AddElement(_map.Player);
            // PLAYERS EVENTS //
            //subscribe to events coming from the map
            _mapState.GetViewModel().RaiseMovement += Move;

            //subscribe to events coming npc/scripted events
            foreach (var entry in _mapState.GetViewModel().MapCelles)
            {
                entry.Value.RaiseClickOnCell += UpdateControlArea;
            }




            //create clock
            Clock clock = new Clock();

            //start event consumer (npc events only)
            _eventConsumer = new EventConsumer(clock);
            _eventConsumer.Start();



            //display
            _mapState.Show();

            //start characters routine
            foreach (var element in _map.Elements)
            {
                if ((element.Value as ICharacter)?.Routine != null)
                { (element.Value as ICharacter)?.Routine.Start(); }
            }

            //start clock
            clock.Start();

        }

        private void AddRoutinedEvent(object sender, EventArgs e)
        {
            string direction = (e as MovementEvent).Direction;
            string key = (e as MovementEvent).Key;
            MoveEvent p = new MoveEvent(direction, _map, _mapState, _map.Elements[key] as ICharacter);
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
        }
    }
}
