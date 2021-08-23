using MyGame.Game.Character.Characters;
using MyGame.Game.Characters.Character;
using MyGame.Game.MapCells;
using MyGame.Game.MapElements;
using System.Collections.Generic;

namespace MyGame.Game.Map.Maps
{
    public class M1_StartingMap : IMap
    {
        public CaseTypes[,] Cases
        {
            get { return _cases; }
        }

        private readonly CaseTypes[,] _cases;

        public int Width
        {
            get { return _width; }
        }

        private readonly int _width;

        public int Height
        {
            get { return _height; }
        }


        private readonly int _height;
        public Dictionary<string, IMapElement> Elements { get { return _elements; } }

        public ICharacter Player { get { return _player; } }

        private readonly Dictionary<string, IMapElement> _elements;
        private readonly ICharacter _player;

        public M1_StartingMap()
        {
            _elements = new Dictionary<string, IMapElement>();
            var npc = new NonPlayableCharacter("random1");
            npc.SetPosition(4, 3);
            _elements.Add(npc.Key, npc);

            var npc2 = new NonPlayableCharacter("sleepingDragon");
            npc2.SetPosition(2, 2);
            npc2.SetSpriteName("sleepingDragon.jpg");
            _elements.Add(npc2.Key, npc2);


            _player = new PlayableCharacter();
            _player.SetPosition(5, 5);
            _elements.Add(_player.Key, _player);


            _height = 6;
            _width = 6;
            _cases = new CaseTypes[_width, _height];


            //2 bottom lines are PATH
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _cases[j, i] = CaseTypes.DESERT;
                }

            }



 

        }

    }
}
