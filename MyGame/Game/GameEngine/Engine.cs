using System;
using System.Collections.Concurrent;
using System.Linq;
using MyGame.Game.Characters.Character;
using MyGame.Game.Map.Maps;
using MyGame.Game.MapCells;

namespace MyGame.Game.GameEngine
{
    public class Engine : IDisposable
    {
        private readonly ConcurrentDictionary<string, MapState> _maps;

        public MapState _currentMap;
        public static PlayableCharacter _player;
        private readonly IStory _story;

        public Engine(IStory story)
        {
            IMap map = story.StoryMaps.FirstOrDefault().Value;
            _story = story;
            MapState mapState = new MapState(map, map.ClockTick);
            _maps = new ConcurrentDictionary<string, MapState>();
            mapState.ForwardEventToEngine += ExecuteEvent;
            _maps.TryAdd(map.Key, mapState);
            _currentMap = mapState;
            _player = map.Player;
        }

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
                        _player = nextMap._map.Player;
                        nextMap.Resume();
                        return;
                    }
                    var newMap = _story.StoryMaps[newMapKey];
                    _player = newMap.Player;
                    var mapState = new MapState(newMap, newMap.ClockTick);

                    _maps.TryAdd(newMap.Key, mapState);
                    StartMap(newMapKey);
                    mapState.ForwardEventToEngine += ExecuteEvent;

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
