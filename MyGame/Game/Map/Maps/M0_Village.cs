﻿using MyGame.Game.Character.Characters;
using MyGame.Game.Character.Routines;
using MyGame.Game.Characters.Character;
using MyGame.Game.Item;
using MyGame.Game.MapCells;
using MyGame.Game.MapElements;
using System.Collections.Generic;

namespace MyGame.Game.Map.Maps
{
    public class M0_Village : IMap
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

        public M0_Village()
        {


            _elements = new Dictionary<string, IMapElement>();



            _player = new PlayableCharacter();
            _player.SetPosition(13, 18);
            _elements.Add(_player.Key, _player);

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


            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _cases[j, i] = CaseTypes.STONE_PATH;
                }
            }

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
            npc6.SetRoutine(npcR6);

            var npc7 = new NonPlayableCharacter("random7");
            npc7.SetPosition(5, 15);
            _elements.Add(npc7.Key, npc7);
            IRoutine npcR7 = new MovementRoutine(new string[] { "Up", "Up", "Up", "Up", "Up", "Up", "Down", "Down", "Down", "Down", "Down", "Down", });
            npc7.SetRoutine(npcR7);

            var npc8 = new NonPlayableCharacter("random8");
            npc8.SetPosition(5, 5);
            _elements.Add(npc8.Key, npc8);
            IRoutine npcR8 = new MovementRoutine(new string[] { "Up", "Left", "Left", "Left", "Left", "Left", "Down", "Right", "Right", "Right", "Right", "Right", });
            npc8.SetRoutine(npcR8);

            var npc9 = new NonPlayableCharacter("random9");
            npc9.SetPosition(0, 17);
            _elements.Add(npc9.Key, npc9);
            IRoutine npcR9 = new MovementRoutine(new string[] { "Up", "Up", "Up", "Up", "Up", "Up", "Down", "Down", "Down", "Down", "Down", "Down", });
            npc9.SetRoutine(npcR9);

            var npc10 = new NonPlayableCharacter("random10");
            npc10.SetPosition(7, 8);
            _elements.Add(npc10.Key, npc7);
            IRoutine npcR10 = new MovementRoutine(new string[] { "Up", "Up", "Up", "Up", "Up", "Up", "Down", "Down", "Down", "Down", "Down", "Down", });
            npc10.SetRoutine(npcR10);

            var npc11 = new NonPlayableCharacter("random11");
            npc11.SetPosition(11, 15);
            _elements.Add(npc11.Key, npc11);
            IRoutine npcR11 = new MovementRoutine(new string[] { "Up", "Down" });
            npc11.SetRoutine(npcR11);

            var npc12 = new NonPlayableCharacter("random12");
            npc12.SetPosition(15, 9);
            _elements.Add(npc12.Key, npc12);
            IRoutine npcR12 = new MovementRoutine(new string[] { "Up", "Up", "Up", "Up", "Up", "Up", "Down", "Down", "Down", "Down", "Down", "Down", });
            npc12.SetRoutine(npcR12);


            for (int j = 0; j < _width; j++)
            {
                var fence = new Fence(string.Concat("fence", 19, ";", j));
                fence.SetPosition(j, 19);
                fence.SetSpriteName("tree.png");
                _elements.Add(fence.Key, fence);
            }


        }
    }
}
