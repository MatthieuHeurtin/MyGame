﻿using MyGame.Game.Character.Characters;
using MyGame.Game.Characters.Character;
using MyGame.Game.GraphicElements.MapCells;
using System;
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
        public Dictionary<string, ICharacter> Characters { get { return _characters; } }

        public ICharacter Player { get { return _player; } }

        private readonly Dictionary<string, ICharacter> _characters;
        private readonly ICharacter _player;

        public M1_StartingMap()
        {
            _characters = new Dictionary<string, ICharacter>();
            var npc = new NonPlayableCharacter("random1");
            _characters.Add(npc.Key, npc);

            _player = new PlayableCharacter();


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