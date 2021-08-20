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
            npc.SetPosition(6, 3);
            _characters.Add(npc.Key, npc);

            var npc2 = new NonPlayableCharacter("sleepingDragon");
            npc2.SetPosition(14, 7);
            npc2.SetSpriteName("sleepingDragon.jpg");
            _characters.Add(npc2.Key, npc2);

            _player = new PlayableCharacter();
            _player.SetPosition(13, 19);



            _height = 20;
            _width = 20;
            _cases = new CaseTypes[_width, _height];

            /* --------------> X
             * |
             * |
             * |
             * |
             * |
             * V
             * Y
             */


            //2 bottom lines are PATH
            for (int i = 15; i < _height; i++)
            {
                for (int j = 5; j < _width; j++)
                {
                    _cases[j, i] = CaseTypes.PATH;
                }

            }


            _cases[6, 3] = CaseTypes.PATH;
            _cases[5, 3] = CaseTypes.PATH;
            _cases[4, 3] = CaseTypes.PATH;
            _cases[3, 3] = CaseTypes.PATH;
            _cases[3, 4] = CaseTypes.PATH;
            _cases[3, 5] = CaseTypes.PATH;
            _cases[2, 5] = CaseTypes.PATH;
            _cases[1, 5] = CaseTypes.PATH;
            _cases[0, 5] = CaseTypes.PATH;

            _cases[13, 16] = CaseTypes.PATH;
            _cases[14, 13] = CaseTypes.PATH;
            _cases[13, 13] = CaseTypes.PATH;
            _cases[15, 13] = CaseTypes.PATH;
            _cases[16, 13] = CaseTypes.PATH;
            _cases[18, 13] = CaseTypes.PATH;
            _cases[18, 12] = CaseTypes.PATH;
            _cases[18, 11] = CaseTypes.PATH;
            _cases[18, 10] = CaseTypes.PATH;
            _cases[18, 9] = CaseTypes.PATH;
            _cases[18, 8] = CaseTypes.PATH;
            _cases[18, 7] = CaseTypes.PATH;
            _cases[18, 6] = CaseTypes.PATH;
            _cases[18, 5] = CaseTypes.PATH;
            _cases[18, 4] = CaseTypes.PATH;
            _cases[18, 3] = CaseTypes.PATH;
            _cases[18, 2] = CaseTypes.PATH;
            _cases[17, 2] = CaseTypes.PATH;
            _cases[16, 2] = CaseTypes.PATH;
            _cases[15, 2] = CaseTypes.PATH;
            _cases[14, 2] = CaseTypes.PATH;
            _cases[13, 2] = CaseTypes.PATH;
            _cases[12, 2] = CaseTypes.PATH;
            _cases[11, 2] = CaseTypes.PATH;
            _cases[11, 3] = CaseTypes.PATH;
            _cases[11, 4] = CaseTypes.PATH;
            _cases[11, 5] = CaseTypes.PATH;

            _cases[11, 6] = CaseTypes.PATH;
            _cases[11, 7] = CaseTypes.PATH;
            _cases[11, 8] = CaseTypes.PATH;
            _cases[11, 9] = CaseTypes.PATH;
            _cases[11, 10] = CaseTypes.PATH;
            _cases[11, 11] = CaseTypes.PATH;
            _cases[10, 11] = CaseTypes.PATH;
            _cases[9, 11] = CaseTypes.PATH;
            _cases[8, 11] = CaseTypes.PATH;
            _cases[7, 11] = CaseTypes.PATH;
            _cases[6, 11] = CaseTypes.PATH;

            _cases[6, 10] = CaseTypes.PATH;
            _cases[6, 9] = CaseTypes.PATH;
            _cases[6, 8] = CaseTypes.PATH;
            _cases[6, 7] = CaseTypes.PATH;
            _cases[6, 6] = CaseTypes.PATH;
            _cases[6, 5] = CaseTypes.PATH;
            _cases[6, 4] = CaseTypes.PATH;
            _cases[6, 3] = CaseTypes.PATH;
            _cases[17, 13] = CaseTypes.PATH;
            _cases[13, 14] = CaseTypes.PATH;

            //_cases[13, 6] = CaseTypes.GRASS;
            //_cases[13, 7] = CaseTypes.GRASS;
            //_cases[13, 8] = CaseTypes.GRASS;
            //_cases[14, 6] = CaseTypes.GRASS;
            //_cases[14, 7] = CaseTypes.GRASS;
            //_cases[14, 8] = CaseTypes.GRASS;
            //_cases[15, 6] = CaseTypes.GRASS;
            //_cases[15, 7] = CaseTypes.GRASS;
            //_cases[15, 8] = CaseTypes.GRASS;


        }
    }
}
