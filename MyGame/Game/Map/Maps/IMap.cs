using MyGame.Game.Character.Characters;
using MyGame.Game.GraphicElements.MapCells;
using System.Collections.Generic;

namespace MyGame.Game.Map.Maps
{
    public interface IMap
    {
        CaseTypes[,] Cases { get; }
        int Height { get; }
        int Width { get; }

        Dictionary<string, ICharacter> Characters { get; }
        ICharacter Player { get; }
    }
}
