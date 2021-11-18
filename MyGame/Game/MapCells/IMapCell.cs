using MyGame.Game.MapCells.GraphicMapCell;
using MyGame.Game.MapElements;
using System;

namespace MyGame.Game.MapCells
{
    public interface IMapCell
    {
        CaseTypes Type { get; }
        IMapElement MapElement { get; }
        bool IsOccupied { get; }

        void SetMapElement(IMapElement mapElement);
        void RemoveMapElement();
        GuiMapCell GetGui();
        event EventHandler ForwardEventToTheMap;
    }


    public enum CaseTypes
    {
        FOREST,
        DESERT,
        GRASS,
        PATH,
        STONE_PATH,
        HAPPY_GRASS
    }
}
