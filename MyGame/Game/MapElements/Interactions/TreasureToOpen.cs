using MyGame.Game.MapCells;
using System;

namespace MyGame.Game.MapElements.Interactions
{
    internal class TreasureToOpen : IPlayerInteraction
    {
        public string Execute()
        {
            throw new NotImplementedException();
        }

        public EventFromCellType GetEventType()
        {
            return EventFromCellType.Treasure;
        }
    }
}
