using MyGame.Game.Character.Characters;
using MyGame.Game.Character.Models;
using System.Collections.Generic;

namespace MyGame.Game.Characters.Character
{
    public class PlayableCharacter : AbstractCharacter
    {
        private readonly string _key;
        private readonly string _name;
        private readonly string _spriteName;
        private readonly IList<PlayerItem> _playerItems;

        public IList<PlayerItem> PlayerItems
        {
            get { return _playerItems; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override string Key
        {
            get { return _key; }
        }

        public override string SpriteName
        {
            get { return _spriteName; }
        }

        public PlayableCharacter():base()
        {
            _name = "Matt";
            _key = "player";
            _spriteName = "mainCharacter.png";
            _playerItems = new List<PlayerItem>();
        }
    }
}
