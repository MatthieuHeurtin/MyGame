using MyGame.Game.Character.Characters;
using MyGame.Ressources;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MyGame.Game.GraphicElements.MapCells.Common
{
    public class CellViewModel : ICellViewModel, INotifyPropertyChanged
    {
        private bool _isOccupied = false;
        private bool _isMouseOver = false;
        private string _spriteImagePath;
        private ICharacter _character;

        private ICommand _displayDetailWindowCommand;

        public event EventHandler RaiseClickOnCell;

        public ICommand DisplayDetailWindowCommand
        {
            get
            {
                return (_displayDetailWindowCommand ?? (_displayDetailWindowCommand = new CommandRelay(DisplayDetailWindow, true)));
            }
        }

        private void DisplayDetailWindow(string obj)
        {
            EventArgs e = new EventParameter(obj);
            RaiseClickOnCell?.Invoke(this, e);
        }

        public string SpriteImagePath { get { return _spriteImagePath; } }

        public bool IsOccupied { get { return _isOccupied; } }

        public bool IsMouseOver { get { return _isMouseOver; } set { _isMouseOver = value; } }

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
            SetSprite(string.Concat(RessourcesManager.CharacterSpriteCellsPath, character.SpriteName));
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
