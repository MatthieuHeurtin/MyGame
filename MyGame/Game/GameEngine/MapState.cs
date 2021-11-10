using System;
using MyGame.Game.Character.Characters;
using MyGame.Game.Character.Routines.Events;
using MyGame.Game.GameEngine.Events.Event;
using MyGame.Game.Map;
using MyGame.Game.Map.Maps;
using MyGame.Game.MapCells;
using MyGame.Game.MapElements;

namespace MyGame.Game.GameEngine
{
    public class MapState : IDisposable
    {
        private Map.Map _mapGui { get; set; }
        public IMap _map { get; }
        private EventConsumer _eventConsumer { get; }
        private Clock _clock { get; }
        public event EventHandler ForwardEventToEngine ;

        public MapState(IMap map, int clockTick)
        {
            _clock = new Clock();
            //event consumer (npc events only)
            _eventConsumer = new EventConsumer(_clock);
            _map = map;
        }

        internal void Start()
        {
            _eventConsumer.Start();
            //display
            _mapGui.Show();
        }

        internal void Init()
        {
            AddElementsOnMap();
            SubscribeToCellsEvent();
            StartRountinesForMap();
            _mapGui = new Map.Map();
            _mapGui.BuildMap(_map);
            //subscribe to events coming from the global map
            _mapGui.GetViewModel().RaiseMovement += Move;
        }

        internal void Pause()
        {
            _clock.Pause();
            _mapGui.Hide();
        }

        internal void Resume()
        {
            _clock.Resume();
            _mapGui.Show();
        }

        #region set up map
        private void AddElementsOnMap()
        {
            //add npc/item (set character to a cell) and subscribe to their events
            foreach (var element in _map.Elements)
            {
                _map.MapCells[element.Value.X, element.Value.Y].SetMapElement(element.Value);
                if ((element.Value as ICharacter)?.Routine != null)
                {
                    ((element.Value as ICharacter)?.Routine?.RoutinedEvent).OnRaise += AddRoutinedEvent;
                }
                if ((element.Value as IMapElement)?.PlayerInteraction != null)
                {
                    // ((element.Value as IItem)?.Routine?.RoutinedEvent).OnRaise += AddRoutinedEvent;
                }

            }


        }

        private void StartRountinesForMap()
        {
            foreach (var element in _map.Elements)
            {
                if ((element.Value as ICharacter)?.Routine != null)
                {
                    (element.Value as ICharacter)?.Routine?.Start();
                }
            }
        }

        private void SubscribeToCellsEvent()
        {
            for (int i = 0; i < _map.Height; i++)
            {
                for (int j = 0; j < _map.Width; j++)
                {
                    _map.MapCells[i, j].ForwardEventToTheMap += RunCellPlayerEvent;
                }
            }
        }

        private void UnsubscribeToCellsEvent()
        {
            for (int i = 0; i < _map.Height; i++)
            {
                for (int j = 0; j < _map.Width; j++)
                {
                    _map.MapCells[i, j].ForwardEventToTheMap -= RunCellPlayerEvent;
                }
            }
        }

        #endregion

        #region events
        private void AddRoutinedEvent(object sender, EventArgs e)
        {
            string direction = (e as MovementEvent).Direction;
            string key = (e as MovementEvent).Key;

            //TODO handle several types of events, not only move
            MoveEvent p = new MoveEvent(direction, _map, _map.Elements[key]);

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
                    // IMap nextMap = _map.Elements[key].PlayerInteraction.Execute();
                    Pause();
                    ForwardEventToEngine?.Invoke(this, e);

                    //  var mapState = new MapState(nextMap, new Clock());
                    // _maps.TryAdd(nextMap.Key, mapState);
                    // StartMap(nextMap.Key);
                    break;
                default:
                    break;
            }
        }


        //player events, do not go to the queue
        private void Move(object sender, EventArgs e)
        {
            string direction = (e as EventArgsFromMap).Param;

            using (MoveEvent p = new MoveEvent(direction, _map, Engine._player))
            {
                p.Execute();
            }
        }
        #endregion
        #endregion

        public void Dispose()
        {
            ////Unsubscribe to events coming from the cells
            //for (int i = 0; i < _maps[_currentMapKey].Height; i++)
            //{
            //    for (int j = 0; j < _maps[_currentMapKey].Width; j++)
            //    {
            //        _maps[_currentMapKey].MapCells[i, j].ForwardEventToTheMap -= RunCellPlayerEvent;
            //    }
            //}

            ////Unsubscribe to events coming from the map
            //_mapGui.GetViewModel().RaiseMovement -= Move;

            //_eventConsumer.Dispose();
            //_clock.Dispose();    
        }



    }
}
