using System;
using System.Collections.Generic;
using MyGame.DebugTools;
using MyGame.Game.Character.Characters;
using MyGame.Game.Character.Routines.Events;
using MyGame.Game.Characters.Character;
using MyGame.Game.GameEngine.Events.Event;
using MyGame.Game.Map;
using MyGame.Game.Map.Maps;
using MyGame.Game.MapCells;
using MyGame.Game.MapElements;

namespace MyGame.Game.GameEngine
{
    public class Engine : IDisposable
    {
        private readonly IDictionary<string, IMap> _maps;
        private Map.Map _mapGui;
        private EventConsumer _eventConsumer;
        private Clock _clock;
        private readonly DebugConsole _dc;
        private  string _currentMapKey;
        private PlayableCharacter _player;

        public Engine(IMap map, bool IsDebug = false)
        {
            _maps = new Dictionary<string, IMap>
            {
                { map.Key, map }
            };
            _currentMapKey = map.Key;
            _player = map.Player;

            //create clock
            _clock = new Clock();

            //start event consumer (npc events only)
            _eventConsumer = new EventConsumer(_clock, _dc);
            _eventConsumer.Start();

        }



        public void StartMap(string mapKey)
        {
            _currentMapKey = mapKey;
            AddElementsOnMap(mapKey);
            SubscribeToCellsEvent(mapKey);
            StartRountinesForMap(mapKey);

            //Init Map
            _mapGui = new Map.Map();
            //subscribe to events coming from the global map
            _mapGui.GetViewModel().RaiseMovement += Move;
            _mapGui.BuildMap(_maps[mapKey]);

            
            //display
            _mapGui.Show();
        }

        #region set up map
        private void AddElementsOnMap(string mapKey)
        {
            //add npc/item (set character to a cell) and subscribe to their events
            foreach (var element in _maps[mapKey].Elements)
            {
                _maps[mapKey].MapCells[element.Value.X, element.Value.Y].SetMapElement(element.Value);
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

        private void StartRountinesForMap(string mapKey)
        {
            foreach (var element in _maps[mapKey].Elements)
            {
                if ((element.Value as ICharacter)?.Routine != null)
                {
                    (element.Value as ICharacter)?.Routine?.Start();
                }
            }
        }

        private void SubscribeToCellsEvent(string mapKey)
        {
            for (int i = 0; i < _maps[mapKey].Height; i++)
            {
                for (int j = 0; j < _maps[mapKey].Width; j++)
                {
                    _maps[mapKey].MapCells[i, j].ForwardEventToTheMap += RunCellPlayerEvent;
                }
            }
        }

        private void UnsubscribeToCellsEvent(string mapKey)
        {
            for (int i = 0; i < _maps[mapKey].Height; i++)
            {
                for (int j = 0; j < _maps[mapKey].Width; j++)
                {
                    _maps[mapKey].MapCells[i, j].ForwardEventToTheMap -= RunCellPlayerEvent;
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
            MoveEvent p = new MoveEvent(direction, _maps[_currentMapKey], _maps[_currentMapKey].Elements[key]);

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
                    _mapGui.GetViewModel().SetFocusedElement(_maps[_currentMapKey].Elements[key]);
                    break;
                case EventFromCellType.ChangeMap:
                    IMap nextMap = _maps[_currentMapKey].Elements[key].PlayerInteraction.Execute();

                    _maps.Add(nextMap.Key, nextMap);

                    StartMap(nextMap.Key);
                    break;
                default:
                    break;


            }

        }




        //player events, do not go to the queue
        private void Move(object sender, EventArgs e)
        {
            string direction = (e as EventArgsFromMap).Param;
            using (MoveEvent p = new MoveEvent(direction, _maps[_currentMapKey], _player))
            {
                p.Execute();
            }
        }
        #endregion
        #endregion

        public void Dispose()
        {
            //Unsubscribe to events coming from the cells
            for (int i = 0; i < _maps[_currentMapKey].Height; i++)
            {
                for (int j = 0; j < _maps[_currentMapKey].Width; j++)
                {
                    _maps[_currentMapKey].MapCells[i, j].ForwardEventToTheMap -= RunCellPlayerEvent;
                }
            }

            //Unsubscribe to events coming from the map
            _mapGui.GetViewModel().RaiseMovement -= Move;

            _eventConsumer.Dispose();
            _clock.Dispose();
        }
    }
}
