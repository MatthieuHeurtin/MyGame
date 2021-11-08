using System;
using MyGame.DebugTools;
using MyGame.Game.Character.Characters;
using MyGame.Game.Character.Routines.Events;
using MyGame.Game.GameEngine.Events.PlayerEvent;
using MyGame.Game.Map;
using MyGame.Game.Map.Maps;
using MyGame.Game.MapCells;

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

                _map.MapCells[element.Value.X, element.Value.Y].SetMapElement(element.Value);
                if ((element.Value as ICharacter)?.Routine != null)
                {
                    ((element.Value as ICharacter)?.Routine?.RoutinedEvent).OnRaise += AddRoutinedEvent;
                }

            }



            // PLAYER EVENTS //
            //subscribe to events coming from the global map
            _mapGui.GetViewModel().RaiseMovement += Move;

            //subscribe to events coming cellules
            SubscribeToCellEvent();
            // END PLAYER EVENTS //




            //create clock
            _clock = new Clock();

            //start event consumer (npc events only)
            _eventConsumer = new EventConsumer(_clock, _dc);
            _dc?.AppendText("START EVENT CONSUMMER");
            _eventConsumer.Start();







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

            //display
            _mapGui.Show();
        }

        private void SubscribeToCellEvent()
        {
            for (int i = 0; i < _map.Height; i++)
            {
                for (int j = 0; j < _map.Width; j++)
                {
                    if (_map.MapCells[i, j].MapElement != null)
                        _map.MapCells[i, j].ForwardEventToTheMap += RunCellPlayerEvent;


                }
            }
        }



        #region events
        private void AddRoutinedEvent(object sender, EventArgs e)
        {
            string direction = (e as MovementEvent).Direction;
            string key = (e as MovementEvent).Key;

            //TODO handle several types of events, not only move
            MoveEvent p = new MoveEvent(direction, _map, _map.Elements[key] as ICharacter);

            _dc?.AddEvent(p, direction, key);
            _eventConsumer.QueueEvent(p);
        }

        #region player events
        //player events do not go to the queue
        private void RunCellPlayerEvent(object sender, EventArgs e)
        {
            string key = (e as EventArgsFromCell).Key;
            EventFromCellType type = (e as EventArgsFromCell).Type;
            switch (type)
            {
                case EventFromCellType.UpdateControlArea:
                    _mapGui.GetViewModel().SetFocusedElement(_map.Elements[key]);
                    break;
                case EventFromCellType.ChangeMap:
                    Engine newEngine = new Engine(_map.Elements[key].PlayerInteraction.Execute());
                    newEngine.Start();
                    break;
                default:
                    break;


            }

        }




        //player events, do not go to the queue
        private void Move(object sender, EventArgs e)
        {
            string direction = (e as EventParameter).Param;
            using (MoveEvent p = new MoveEvent(direction, _map, _player))
            {
                p.Execute();
            }
        }
        #endregion
        #endregion

        public void Dispose()
        {
            //Unsubscribe to events coming from the cells
            for (int i = 0; i < _map.Height; i++)
            {
                for (int j = 0; j < _map.Width; j++)
                {
                    _map.MapCells[i, j].ForwardEventToTheMap -= RunCellPlayerEvent;
                }
            }

            //Unsubscribe to events coming from the map
            _mapGui.GetViewModel().RaiseMovement -= Move;

            _eventConsumer.Dispose();
            _clock.Dispose();
        }
    }
}
