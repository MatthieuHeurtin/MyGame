using MyGame.Game.MapCells;
using MyGame.Game.MapCells.Desert;
using MyGame.Game.MapCells.Forest;
using MyGame.Game.MapCells.Grass;
using MyGame.Game.MapCells.HappyGrass;
using MyGame.Game.MapCells.Path;
using MyGame.Game.MapCells.StonePath;

namespace MyGame.Game.Map
{
    public class MapCellFactory
    {
        public static IMapCell GetCaseFromType(CaseTypes caseType)
        {
            switch (caseType)
            {
                case CaseTypes.FOREST:
                    return new ForestCell(); //default value, since caseType default value is 0
                case CaseTypes.DESERT:
                    return new DesertCell();
                case CaseTypes.GRASS:
                    return new GrassCell();
                case CaseTypes.PATH:
                    return new PathCell();
                case CaseTypes.STONE_PATH:
                    return new StonePath();
                case CaseTypes.HAPPY_GRASS:
                    return new HappyGrass();
                default:
                    throw new System.Exception();
            }
        }
    }
}
