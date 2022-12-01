using System;
using System.Linq;
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
        public event EventHandler ForwardEventToEngine;

        public MapState(IMap map, int clockTick, EventHandler callback)
        {
            _clock = new Clock(clockTick);
            //event consumer (npc events only)
            _eventConsumer = new EventConsumer(_clock);
            _map = map;
            ForwardEventToEngine += callback;
        }

        internal void Start()
        {
            _eventConsumer.Start();
         
            //display
            _mapGui.Show();

            StartRountinesForMap();
            SubscribeToCellsEvent();
        }

        internal void Init()
        {
            AddElementsOnMap();
         
            _mapGui = new Map.Map();
            _mapGui.BuildMap(_map);
            SetuoPlayerArea();
            //subscribe to events coming from the user
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

        private void SetuoPlayerArea()
        {
           //setup player area (on the right)
            foreach (var item in _map.Player.PlayerItems)
            {
                _mapGui.GetViewModel().AddAnItem(item);
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
                case EventFromCellType.Treasure:
                     _map.Elements[key].PlayerInteraction?.Execute();
                    _mapGui.GetViewModel().AddAnItem(_map.Player.PlayerItems.Last());
                    break;
                case EventFromCellType.ChangeMap:
                    Pause();
                    ForwardEventToEngine?.Invoke(this, e);
                    break;
                default:
                    break;
            }
        }


        //player events, do not go to the queue
        private void Move(object sender, EventArgs e)
        {
            string direction = (e as EventArgsFromMap).Param;

            using (MoveEvent p = new MoveEvent(direction, _map, _map.Player))
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
