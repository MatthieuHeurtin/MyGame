﻿using MyGame.Game.Character.Characters;
using MyGame.Game.MapCells;
using MyGame.Game.MapElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyGame.Game.Map
{
    public class MapViewModel : INotifyPropertyChanged
    {
      
        public event EventHandler RaiseMovement;
        public event PropertyChangedEventHandler PropertyChanged;

        public IDictionary<string, ICellViewModel> MapCelles;

        public string Path { get; set; }

        public MapViewModel()
        {
            MapCelles = new Dictionary<string, ICellViewModel>();
        }

        internal void Move(string obj)
        {
            EventArgs e = new EventParameter(obj);
            RaiseMovement?.Invoke(this, e);
        }

        internal void AddElement(IMapElement element)
        {
            ICellViewModel cell = MapCelles[string.Concat(element.X, ";", element.Y)];
            cell.SetElement(element);
        }

        internal void AddCell(int i, int j, ICellViewModel cellInst)
        {
            MapCelles.Add(string.Concat(i, ";", j), cellInst);
        }

        internal void RemoveCharacter(ICharacter character)
        {
            ICellViewModel cell = MapCelles[string.Concat(character.X,  ";", character.Y)];
            cell.SetElement(null);
        }

        internal bool IsOccupied(int X, int Y)
        {
            return MapCelles[string.Concat(X, ";", Y)].IsOccupied;
        }

        internal void SetCellItemSprite(string cellSpriteName)
        {
            Path = cellSpriteName;
            NotifyPropertyChanged(nameof(Path));
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
