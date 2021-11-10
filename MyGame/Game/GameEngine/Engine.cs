using System;
using System.Collections.Concurrent;
using MyGame.Game.Characters.Character;
using MyGame.Game.Map.Maps;
using MyGame.Game.MapCells;

namespace MyGame.Game.GameEngine
{
    public class Engine : IDisposable
    {
        private readonly ConcurrentDictionary<string, MapState> _maps;

        public readonly MapState _currentMap;
        internal static PlayableCharacter _player;

        public Engine(IMap map, bool IsDebug = false)
        {
            var mapState = new MapState(map, map.ClockTick);
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
                    IMap nextMap = _currentMap._map.Elements[key].PlayerInteraction.Execute();


                    var mapState = new MapState(nextMap, nextMap.ClockTick);
                    _player = nextMap.Player;
                    _maps.TryAdd(nextMap.Key, mapState);
                    StartMap(nextMap.Key);
                    break;
                default:
                    break;
            }
        }

        public void StartMap(string mapKey)
        {
            if (_maps.TryGetValue(mapKey, out MapState mapState))
            {
                mapState.Init();
                mapState.Start();
            }
        }

        public void Dispose()
        {

        }
    }
}
