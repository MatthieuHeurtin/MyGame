using MyGame.Game.Character.Models;
using MyGame.Game.MapElements;
using MyGame.Ressources;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyGame.Game.Map
{
    public class MapViewModel : INotifyPropertyChanged
    {
        public event EventHandler RaiseMovement;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PlayerItem> PlayerItems { get; set; }
        public IMapElement MapElement { get; set; }
        public string SpriteFullPath { get; set; }


        public MapViewModel()
        {
            PlayerItems = new ObservableCollection<PlayerItem>();
        }
        internal void Move(string direction)
        {
            EventArgsFromMap e = new EventArgsFromMap(null, direction);
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

        internal void AddAnItem(PlayerItem playerItem)
        {
            string folderRessourcesPath = RessourcesManager.GetPathFromPLayerItem(playerItem);
            playerItem.Icon = string.Concat(folderRessourcesPath, playerItem.SpriteName);
            PlayerItems.Add(playerItem);
        }
    }
}
