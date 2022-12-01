using MyGame.Game.Character.Models;
using MyGame.Game.Characters.Character;
using MyGame.Game.MapCells;
using System;

namespace MyGame.Game.MapElements.Interactions
{
    internal class TreasureToOpen : IPlayerInteraction
    {
        private readonly PlayableCharacter _player;
        private readonly PlayerItem _newPlayerItem;

        public TreasureToOpen(PlayableCharacter player, PlayerItem newPlayerItem)
        {
            _player = player;
            _newPlayerItem = newPlayerItem;
        }
        public string Execute()
        {
            _player.PlayerItems.Add(_newPlayerItem);
            return String.Empty;
        }

        public EventFromCellType GetEventType()
        {
            return EventFromCellType.Treasure;
        }
    }
}
