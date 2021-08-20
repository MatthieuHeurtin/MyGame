using MyGame.Game.Character.Characters;
using System;

namespace MyGame.Game.GraphicElements.MapCells
{
    public interface ICellViewModel
    {
        void SetCharacter(ICharacter character);
        bool IsOccupied { get; }
        event EventHandler RaiseClickOnCell;
    }
}
