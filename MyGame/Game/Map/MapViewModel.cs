using MyGame.Game.Character.Characters;
using MyGame.Game.GraphicElements.MapCells;
using System;
using System.Collections.Generic;

namespace MyGame.Game.Map
{
    public class MapViewModel 
    {
        //XY used to indentify the cell
        private class XY : IEquatable<XY>
        {
            public XY(int x, int y)
            {
                X = x;
                Y = y;
            }

            readonly int X;
            readonly int Y;

            public bool Equals(XY other)
            {
                return other != null && X == other.X && Y == other.X;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as XY);
            }

            public override int GetHashCode()
            {
                return X + Y; //should be enough
            }
        }

        IDictionary<XY, ICellViewModel> MapCelles;


        public MapViewModel()
        {
            MapCelles = new Dictionary<XY, ICellViewModel>();
        }

        internal void AddCell(int i, int j, ICellViewModel cellInst)
        {
            MapCelles.Add(new XY(i, j), cellInst);
        }

        internal void AddCharacter(ICharacter character)
        {
            ICellViewModel cell = MapCelles[new XY(character.X, character.Y)];
            cell.SetSprite(character.SpriteName);
        }
    }
}
