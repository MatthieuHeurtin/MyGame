using MyGame.Game.Character.Characters;

namespace MyGame.Game.GraphicElements.MapCells
{
    public interface ICellViewModel
    {
        void SetCharacter(ICharacter character);
        bool IsOccupied { get; }
    }
}
