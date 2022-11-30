using MyGame.Game.Map.Maps;
using MyGame.Game.MapCells;

namespace MyGame.Game.MapElements.Interactions
{
    public interface IPlayerInteraction
    {
        string Execute();

        EventFromCellType GetEventType();
    }
}
