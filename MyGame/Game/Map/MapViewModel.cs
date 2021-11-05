using MyGame.Game.Character.Characters;
using MyGame.Game.MapCells;
using MyGame.Game.MapElements;
using MyGame.Ressources;
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

        public IMapElement MapElement { get; set; }
        public string SpriteFullPath { get; set; }

        internal void Move(string obj)
        {
            EventArgs e = new EventParameter(obj);
            RaiseMovement?.Invoke(this, e);
        }
        internal void SetFocusedElement(IMapElement mapElement)
        {
            string folderRessourcesPath = RessourcesManager.GetPathFromElementMap(mapElement);

            SpriteFullPath = string.Concat(folderRessourcesPath, mapElement.SpriteName);
            MapElement = mapElement;
            NotifyPropertyChanged(nameof(MapElement));
            NotifyPropertyChanged(nameof(SpriteFullPath));
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
