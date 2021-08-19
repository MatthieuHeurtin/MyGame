using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Game.Character.Characters
{
    public class NonPlayableCharacter : AbstractCharacter
    {
        private readonly string _key;

        public NonPlayableCharacter(string key)
        {
            _key = key;
        }

        public override string Key
        {
            get { return _key; }
        }

        
    }
}
