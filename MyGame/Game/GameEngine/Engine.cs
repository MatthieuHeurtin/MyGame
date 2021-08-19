using MyGame.Game.Character.Characters;
using MyGame.Game.Map.Maps;

namespace MyGame.Game.GameEngine
{
    public class Engine
    {
        private readonly IMap _map;
        private Map.Map _graphicMap;
        private readonly ICharacter _player;

        public Engine(IMap map)
        {
            _map = map;
            _player = map.Player;
        }

        public void Start()
        {
            //Init Map
            _graphicMap = new Map.Map();
            _graphicMap.BuildMap(_map);


            //add npc (set character to a cell)
            foreach (var character in _map.Characters)
            {
                _graphicMap.MapViewModel.AddCharacter(character.Value);
            }

            //add players
            _graphicMap.MapViewModel.AddCharacter(_map.Player);



            //display
            _graphicMap.Show();
        }

    }
}
