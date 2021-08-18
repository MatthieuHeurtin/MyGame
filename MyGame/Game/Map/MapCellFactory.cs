using MyGame.Game.GraphicElements.MapCells;
using MyGame.Game.GraphicElements.MapCells.Desert;
using MyGame.Game.GraphicElements.MapCells.Forest;
using MyGame.Game.GraphicElements.MapCells.Grass;
using MyGame.Game.GraphicElements.MapCells.Path;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Game.Map
{
    public class MapCellFactory
    {
        public static IMapCell GetCaseFromType(CaseTypes caseType)
        {
            switch (caseType)
            {
                case CaseTypes.FOREST:
                    var t = new ForestCell();
                    return t;
                case CaseTypes.DESERT:
                    return new DesertCell();
                case CaseTypes.GRASS:
                    return new GrassCell();
                case CaseTypes.PATH:
                    return new PathCell();
                default:
                    throw new System.Exception();
            }
        }
    }
}
