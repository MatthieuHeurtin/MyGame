using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using MyGame.Game.Map.Maps;
using MyGame.Game.MapCells;

namespace MyGame.Game.GameEngine
{
    public class Engine : IDisposable
    {
        private readonly ConcurrentDictionary<string, MapState> _maps;

        public MapState _currentMap;
        private readonly IStory _story;
        public Engine(IStory story)
        {
            IMap map = story.StoryMaps.FirstOrDefault().Value;
            _story = story;
            MapState mapState = new MapState(map, map.ClockTick, ExecuteEvent);
            _maps = new ConcurrentDictionary<string, MapState>();
            _maps.TryAdd(map.Key, mapState);
            _currentMap = mapState;


            for (int i = 1; i < 2; i++)
            {
                var undisplayedMap = _story.StoryMaps.Skip(i)?.FirstOrDefault().Value;

                MapState undisplayedMapState = new MapState(undisplayedMap, undisplayedMap.ClockTick, ExecuteEvent);
                undisplayedMapState.Init();
                undisplayedMapState.Start();
                undisplayedMapState.Pause();

                _maps.TryAdd(undisplayedMap.Key, undisplayedMapState);

            }




        }


        //event coming from maps
        private void ExecuteEvent(object sender, EventArgs e)
        {
            string key = (e as EventArgsFromCell).Key;
            EventFromCellType type = (e as EventArgsFromCell).Type;
            switch (type)
            {
                case EventFromCellType.ChangeMap:
                    string newMapKey = _currentMap._map.Elements[key].PlayerInteraction.Execute();

                    if (_maps.TryGetValue(newMapKey, out var nextMap))
                    {
                        nextMap.Resume();
                        _currentMap = nextMap;
                        return;
                    }
                    var newMap = _story.StoryMaps[newMapKey];
                    var mapState = new MapState(newMap, newMap.ClockTick, ExecuteEvent);
                    _maps.TryAdd(newMap.Key, mapState);
                    StartMap(newMapKey);
                    break;
                default:
                    break;
            }
        }

        private void StartMap(string mapKey)
        {
            if (_maps.TryGetValue(mapKey, out MapState mapState))
            {
                mapState.Init();
                mapState.Start();
                _currentMap = mapState;
            }
        }

        public void Start()
        {
            StartMap(_currentMap._map.Key);
        }

        public void Dispose()
        {

        }
    }
}
