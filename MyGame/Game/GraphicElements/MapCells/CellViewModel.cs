using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyGame.Game.GraphicElements.MapCells
{
    public class CellViewModel : ICellViewModel, INotifyPropertyChanged
    {
        private bool _isOccupied = false;
        private string _spriteImagePath;

        public string SpriteImagePath { get { return _spriteImagePath; } }

        public bool IsOccupied { get { return _isOccupied; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetSprite(string spriteName)
        {
            if (!string.IsNullOrEmpty(spriteName))
            {
                _spriteImagePath = String.Concat("./../Characters/ressources/", spriteName);
                _isOccupied = true;
            }
            else
            {
                _spriteImagePath = null;
                _isOccupied = false;
            }
            NotifyPropertyChanged(nameof(SpriteImagePath));
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
