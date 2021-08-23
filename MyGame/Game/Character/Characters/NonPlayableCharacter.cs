using MyGame.Game.Character.Routines;
using MyGame.Game.MapCells.Common;
using System;

namespace MyGame.Game.Character.Characters
{
    public class NonPlayableCharacter : AbstractCharacter
    {
        private readonly string _key;
        public NonPlayableCharacter(string key):base()
        {
            _key = key;
        }

        public override string Key
        {
            get { return _key; }
        }

        public override void SetRoutine(IRoutine routine)
        {
            Routine = routine;
        }


    }
}
