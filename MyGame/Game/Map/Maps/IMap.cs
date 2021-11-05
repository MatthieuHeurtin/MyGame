using MyGame.Game.Character.Characters;
using MyGame.Game.MapCells;
using MyGame.Game.MapElements;
using System.Collections.Generic;

namespace MyGame.Game.Map.Maps
{
    public interface IMap
    {
        IMapCell[,] MapCells { get; }
        int Height { get; }
        int Width { get; }
        string Key { get; }

        Dictionary<string, IMapElement> Elements { get; }
        ICharacter Player { get; }
    }
}
