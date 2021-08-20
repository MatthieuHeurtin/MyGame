using MyGame.Game.Character.Characters;
using MyGame.Game.MapElements;
using System;

namespace MyGame.Game.MapCells
{
    public interface ICellViewModel
    {
        void SetElement(IMapElement character);
        bool IsOccupied { get; }
        event EventHandler RaiseClickOnCell;
    }
}
