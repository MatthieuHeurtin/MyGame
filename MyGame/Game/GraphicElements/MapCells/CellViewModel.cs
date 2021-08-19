using MyGame.Game.Character.Characters;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyGame.Game.GraphicElements.MapCells
{
    public class CellViewModel : ICellViewModel, INotifyPropertyChanged
    {
        private bool _isOccupied = false;
        private string _spriteImagePath;
        private ICharacter _character;

        public string SpriteImagePath { get { return _spriteImagePath; } }

        public bool IsOccupied { get { return _isOccupied; } }

        public ICharacter Character { get { return _character; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetCharacter(ICharacter character)
        {
            if (character == null)
            {
                SetSprite(string.Empty);
                _isOccupied = false;
                return;
            }
            _isOccupied = true;
            SetSprite(character.SpriteName);
            NotifyPropertyChanged(nameof(Character));
        }

        private void SetSprite(string spriteName)
        {
            _spriteImagePath = String.Concat("./../Characters/ressources/", spriteName);
            NotifyPropertyChanged(nameof(SpriteImagePath));
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
