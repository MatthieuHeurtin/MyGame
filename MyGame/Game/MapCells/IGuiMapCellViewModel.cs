using MyGame.Game.Character.Characters;
using MyGame.Game.MapElements;
using System;

namespace MyGame.Game.MapCells
{
    public interface IGuiMapCellViewModel
    {
        void SetElement(IMapElement character);
        event EventHandler RaiseClickOnCell;
        void SetSprite(string spriteNamePath);
    }
}
