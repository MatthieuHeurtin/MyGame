using MyGame.Game.Character.Models;
using MyGame.Game.Characters.Character;
using MyGame.Game.MapElements.Interactions;
using System;

namespace MyGame.Game.Item
{
    internal class Treasure : AbstractItem
    {
        private readonly string _key;

        public override string Key
        {
            get { return _key; }
        }

        private readonly bool _isPhysical;
        public override bool IsPhysical
        {
            get { return _isPhysical; }
        }


        private PlayerItem _playerItem;




        public Treasure(string key, PlayableCharacter player, PlayerItem playerItem) : base()
        {
            _key = key;
            _playerItem = playerItem;
            SetPlayerInteraction(new TreasureToOpen(player, playerItem));
            _isPhysical = false;

        }

    }
}
