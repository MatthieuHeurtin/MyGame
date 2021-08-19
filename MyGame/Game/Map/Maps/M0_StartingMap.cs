using MyGame.Game.Character.Characters;
using MyGame.Game.Characters.Character;
using MyGame.Game.GraphicElements.MapCells;
using System;
using System.Collections.Generic;

namespace MyGame.Game.Map.Maps
{
    public class M0_StartingMap : IMap
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
        public Dictionary<string, ICharacter> Characters { get { return _characters; } }

        public ICharacter Player { get { return _player; } }

        private readonly Dictionary<string, ICharacter> _characters;
        private readonly ICharacter _player;

        public M0_StartingMap()
        {
            _characters = new Dictionary<string, ICharacter>();
            var npc = new NonPlayableCharacter("random1");
            _characters.Add(npc.Key, npc);

            _player = new PlayableCharacter();


            _height = 25;
            _width = 25;
            _cases = new CaseTypes[_width, _height];


            //2 bottom lines are PATH
            for (int i = 0; i < _height; i++)
            {
                for (int j = 7; j < _width; j++)
                {
                    _cases[j, i] = CaseTypes.PATH;
                }

            }

            _cases[6, 0] = CaseTypes.DESERT;
            _cases[6, 1] = CaseTypes.DESERT;
            _cases[6, 2] = CaseTypes.DESERT;
            _cases[6, 3] = CaseTypes.PATH;
            _cases[6, 4] = CaseTypes.GRASS;
            _cases[6, 5] = CaseTypes.GRASS;
            _cases[6, 6] = CaseTypes.GRASS;
            _cases[6, 7] = CaseTypes.GRASS;

            _cases[5, 0] = CaseTypes.DESERT;
            _cases[5, 1] = CaseTypes.DESERT;
            _cases[5, 2] = CaseTypes.DESERT;
            _cases[5, 3] = CaseTypes.PATH;
            _cases[5, 4] = CaseTypes.GRASS;
            _cases[5, 5] = CaseTypes.GRASS;
            _cases[5, 6] = CaseTypes.GRASS;
            _cases[5, 7] = CaseTypes.GRASS;

            _cases[4, 0] = CaseTypes.DESERT;
            _cases[4, 1] = CaseTypes.DESERT;
            _cases[4, 2] = CaseTypes.DESERT;
            _cases[4, 3] = CaseTypes.PATH;
            _cases[4, 4] = CaseTypes.GRASS;
            _cases[4, 5] = CaseTypes.GRASS;
            _cases[4, 6] = CaseTypes.GRASS;
            _cases[4, 7] = CaseTypes.GRASS;

            _cases[3, 0] = CaseTypes.DESERT;
            _cases[3, 1] = CaseTypes.DESERT;
            _cases[3, 2] = CaseTypes.DESERT;
            _cases[3, 3] = CaseTypes.PATH;
            _cases[3, 4] = CaseTypes.PATH;
            _cases[3, 5] = CaseTypes.PATH;
            _cases[3, 6] = CaseTypes.GRASS;
            _cases[3, 7] = CaseTypes.GRASS;

            _cases[2, 0] = CaseTypes.DESERT;
            _cases[2, 1] = CaseTypes.DESERT;
            _cases[2, 2] = CaseTypes.DESERT;
            _cases[2, 3] = CaseTypes.DESERT;
            _cases[2, 4] = CaseTypes.GRASS;
            _cases[2, 5] = CaseTypes.PATH;
            _cases[2, 6] = CaseTypes.GRASS;
            _cases[2, 7] = CaseTypes.GRASS;

            _cases[1, 0] = CaseTypes.DESERT;
            _cases[1, 1] = CaseTypes.DESERT;
            _cases[1, 2] = CaseTypes.DESERT;
            _cases[1, 3] = CaseTypes.DESERT;
            _cases[1, 4] = CaseTypes.GRASS;
            _cases[1, 5] = CaseTypes.PATH;
            _cases[1, 6] = CaseTypes.GRASS;
            _cases[1, 7] = CaseTypes.GRASS;

            _cases[0, 0] = CaseTypes.DESERT;
            _cases[0, 1] = CaseTypes.DESERT;
            _cases[0, 2] = CaseTypes.DESERT;
            _cases[0, 3] = CaseTypes.DESERT;
            _cases[0, 4] = CaseTypes.GRASS;
            _cases[0, 5] = CaseTypes.PATH;
            _cases[0, 6] = CaseTypes.GRASS;
            _cases[0, 7] = CaseTypes.GRASS;

            //SetCharcaters();

        }

        private void SetCharcaters()
        {
            throw new NotImplementedException();
        }
    }
}
