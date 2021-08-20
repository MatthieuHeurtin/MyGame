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
                SetSprite(null);
                _isOccupied = false;
                NotifyPropertyChanged(nameof(Character));
                return;
            }
            _isOccupied = true;
            SetSprite(String.Concat("./../Characters/ressources/", character.SpriteName));
            _character = character;

            NotifyPropertyChanged(nameof(Character));
        }

        private void SetSprite(string spriteNamePath)
        {
            _spriteImagePath = spriteNamePath;


            NotifyPropertyChanged(nameof(SpriteImagePath));
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
