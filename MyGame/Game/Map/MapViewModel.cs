using MyGame.Game.Character.Characters;
using MyGame.Game.GraphicElements.MapCells;
using System;
using System.Collections.Generic;

namespace MyGame.Game.Map
{
    public partial class MapViewModel
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
                unchecked // Allow arithmetic overflow, numbers will just "wrap around"
                {
                    int hashcode = 1430287;
                    hashcode = hashcode * 7302013 ^ X.GetHashCode();
                    hashcode = hashcode * 7302013 ^ Y.GetHashCode();
                    return hashcode;
                }
            }
        }
        public event EventHandler RaiseMovement;



        IDictionary<string, ICellViewModel> MapCelles;


        public MapViewModel()
        {
            MapCelles = new Dictionary<string, ICellViewModel>();
        }

        internal void Move(string obj)
        {
            EventArgs e = new EventParameter(obj);
            RaiseMovement?.Invoke(this, e);
        }

        internal void AddCell(int i, int j, ICellViewModel cellInst)
        {
            MapCelles.Add(string.Concat(i, ";", j), cellInst);
        }

        internal void AddCharacter(ICharacter character)
        {
            ICellViewModel cell = MapCelles[string.Concat(character.X, ";", character.Y)];
            cell.SetSprite(character.SpriteName);
        }

        internal void RemoveCharacter(ICharacter character)
        {
            ICellViewModel cell = MapCelles[string.Concat(character.X,  ";", character.Y)];
            cell.SetSprite(string.Empty);
        }

        internal bool IsOccupied(int X, int Y)
        {
            return MapCelles[string.Concat(X, ";", Y)].IsOccupied;
        }

    }
}
