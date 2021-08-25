using MyGame.Game.Character.Characters;
using MyGame.Game.Character.Routines;
using MyGame.Game.Characters.Character;
using MyGame.Game.Item;
using MyGame.Game.MapCells;
using MyGame.Game.MapElements;
using System.Collections.Generic;

namespace MyGame.Game.Map.Maps
{
    public class M1_VillageBorder : IMap
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

        public IEnumerable<IMap> Neighbours { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private readonly Dictionary<string, IMapElement> _elements;
        private readonly ICharacter _player;

        public M1_VillageBorder()
        {
            _elements = new Dictionary<string, IMapElement>();
            var npc = new NonPlayableCharacter("random1");
            npc.SetPosition(6, 3);
            _elements.Add(npc.Key, npc);
            IRoutine npcR = new MovementRoutine(new string[] { "Left", "Left", "Left", "Right", "Right", "Right" });
            npc.SetRoutine(npcR);

            var npc2 = new NonPlayableCharacter("random2");
            npc2.SetPosition(15, 14);
            _elements.Add(npc2.Key, npc2);
            IRoutine npcR2 = new MovementRoutine(new string[] { "Left", "Left", "Left", "Right", "Right", "Right" });
            npc2.SetRoutine(npcR2);


            var npc3 = new NonPlayableCharacter("random3");
            npc3.SetPosition(14, 18);
            _elements.Add(npc3.Key, npc3);
            IRoutine npcR3 = new MovementRoutine(new string[] { "Up", "Left", "Left", "Down", "Right", "Right" });
            npc3.SetRoutine(npcR3);

            var npc4 = new NonPlayableCharacter("random4");
            npc4.SetPosition(18, 18);
            _elements.Add(npc4.Key, npc4);
            IRoutine npcR4 = new MovementRoutine(new string[] { "Left", "Left", "Right", "Right" });
            npc4.SetRoutine(npcR4);


            var npc5 = new NonPlayableCharacter("random5");
            npc5.SetPosition(12, 15);
            _elements.Add(npc5.Key, npc5);
            IRoutine npcR5 = new MovementRoutine(new string[] { "Up", "Up", "Up", "Up", "Up", "Up", "Down", "Down", "Down", "Down", "Down", "Down", });
            npc5.SetRoutine(npcR5);


            var npc6 = new NonPlayableCharacter("random6");
            npc6.SetPosition(5, 15);
            _elements.Add(npc6.Key, npc6);
            IRoutine npcR6 = new MovementRoutine(new string[] { "Up", "Up", "Up", "Up", "Up", "Up", "Down", "Down", "Down", "Down", "Down", "Down", });
            npc5.SetRoutine(npcR6);

            var npcD = new NonPlayableCharacter("sleepingDragon");
            npcD.SetPosition(18, 7);
            npcD.SetSpriteName("sleepingDragon.jpg");
            _elements.Add(npcD.Key, npcD);





            _player = new PlayableCharacter();
            _player.SetPosition(13, 19);
            _elements.Add(_player.Key, _player);

            //HOUSE
            var house = new House(string.Concat("houseGateDownTopRight", 19, ";", 15));
            house.SetPosition(19, 15);
            house.SetSpriteName("houseGateDown.png");
            _elements.Add(house.Key, house);

            var houseTopLeft = new House(string.Concat("houseGateDownTopLeft", 18, ";", 15));
            houseTopLeft.SetPosition(18, 15);
            houseTopLeft.SetSpriteName("houseGateDown.png");
            _elements.Add(houseTopLeft.Key, houseTopLeft);

            var houseBottomLeft = new House(string.Concat("houseGateDownBottomLeft", 18, ";", 16));
            houseBottomLeft.SetPosition(18, 16);
            houseBottomLeft.SetSpriteName("houseGateDown.png");
            _elements.Add(houseBottomLeft.Key, houseBottomLeft);

            var houseBottomRight = new House(string.Concat("houseGateDownBottomRight", 19, ";", 16));
            houseBottomRight.SetPosition(7, 19);
            houseBottomRight.SetSpriteName("houseGateDown.png");
            _elements.Add(houseBottomRight.Key, houseBottomRight);

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
                    _cases[j, i] = CaseTypes.STONE_PATH;
                }
            }

            #region path
            List<string> pathCells = new List<string>
            {
                string.Concat(6, ";", 3),
                string.Concat(5, ";", 3),
                string.Concat(4, ";", 3),
                string.Concat(3, ";", 3),
                string.Concat(3, ";", 4),
                string.Concat(3, ";", 5),
                string.Concat(2, ";", 5),
                string.Concat(1, ";", 5),
                string.Concat(0, ";", 5),
                string.Concat(13, ";", 16),
                string.Concat(14, ";", 13),
                string.Concat(13, ";", 13),
                string.Concat(15, ";", 13),
                string.Concat(16, ";", 13),
                string.Concat(18, ";", 13),
                string.Concat(18, ";", 12),
                string.Concat(18, ";", 11),
                string.Concat(18, ";", 10),
                string.Concat(18, ";", 9),
                string.Concat(18, ";", 8),
                string.Concat(18, ";", 7),
                string.Concat(18, ";", 6),
                string.Concat(18, ";", 5),
                string.Concat(18, ";", 4),
                string.Concat(18, ";", 3),
                string.Concat(18, ";", 2),
                string.Concat(17, ";", 2),
                string.Concat(16, ";", 2),
                string.Concat(15, ";", 2),
                string.Concat(14, ";", 2),
                string.Concat(13, ";", 2),
                string.Concat(12, ";", 2),
                string.Concat(11, ";", 2),
                string.Concat(11, ";", 3),
                string.Concat(11, ";", 4),
                string.Concat(11, ";", 6),
                string.Concat(11, ";", 7),
                string.Concat(11, ";", 8),
                string.Concat(11, ";", 9),
                string.Concat(11, ";", 5),
                string.Concat(6, ";", 9),
                string.Concat(6, ";", 8),
                string.Concat(6, ";", 7),
                string.Concat(6, ";", 6),
                string.Concat(6, ";", 5),
                string.Concat(6, ";", 4),
                string.Concat(6, ";", 3),
                string.Concat(6, ";", 10),
                string.Concat(9, ";", 11),
                string.Concat(8, ";", 11),
                string.Concat(7, ";", 11),
                string.Concat(6, ";", 11),
                string.Concat(17, ";", 13),
                string.Concat(13, ";", 14),
                string.Concat(11, ";", 10),
                string.Concat(11, ";", 11),
                string.Concat(10, ";", 11),


            };







            _cases[6, 3] = CaseTypes.PATH;
            _cases[5, 3] = CaseTypes.PATH;
            _cases[4, 3] = CaseTypes.PATH;
            _cases[3, 3] = CaseTypes.PATH;
            _cases[3, 4] = CaseTypes.PATH;
            _cases[3, 5] = CaseTypes.PATH;
            _cases[2, 5] = CaseTypes.PATH;
            _cases[1, 5] = CaseTypes.PATH;
            _cases[0, 5] = CaseTypes.PATH;
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
            #endregion path

            _cases[6, 19] = CaseTypes.HAPPY_GRASS;
            _cases[6, 18]= CaseTypes.HAPPY_GRASS;
            _cases[7, 19] = CaseTypes.HAPPY_GRASS;
            _cases[7, 18] = CaseTypes.HAPPY_GRASS;
            _cases[8, 19] = CaseTypes.HAPPY_GRASS;
            _cases[8, 18] = CaseTypes.HAPPY_GRASS;


            //set trees and grass
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (pathCells.Contains(string.Concat(j, ";", i))) continue;
                    _cases[j, i] = CaseTypes.GRASS;

                    var tree = new Tree(string.Concat("tree", i, ";", j));
                    tree.SetPosition(j, i);
                    tree.SetSpriteName("tree.png");
                    _elements.Add(tree.Key, tree);
                }
            }

            for (int i = 15; i < _height; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (pathCells.Contains(string.Concat(j, ";", i))) continue;

                    _cases[j, i] = CaseTypes.GRASS;

                    var tree = new Tree(string.Concat("tree", i, ";", j));
                    tree.SetPosition(j, i);
                    tree.SetSpriteName("tree.png");
                    _elements.Add(tree.Key, tree);
                }
            }


        }
    }
}
