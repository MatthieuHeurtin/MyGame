using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Game.Item
{
    public class Tree : AbstractItem
    {
        private readonly string _key;

        public override string Key
        {
            get { return _key; }
        }

        public Tree(string key):base()
        {
            _key = key;
        }
    }
}
