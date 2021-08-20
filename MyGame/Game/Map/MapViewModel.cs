using MyGame.Game.Character.Characters;
using MyGame.Game.GraphicElements.MapCells;
using System;
using System.Collections.Generic;

namespace MyGame.Game.Map
{
    public partial class MapViewModel
    {
      
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
            cell.SetCharacter(character);
        }

        internal void RemoveCharacter(ICharacter character)
        {
            ICellViewModel cell = MapCelles[string.Concat(character.X,  ";", character.Y)];
            cell.SetCharacter(null);
        }

        internal bool IsOccupied(int X, int Y)
        {
            return MapCelles[string.Concat(X, ";", Y)].IsOccupied;
        }

    }
}
