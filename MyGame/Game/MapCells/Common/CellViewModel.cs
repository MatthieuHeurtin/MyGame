﻿using MyGame.Game.Character.Characters;
using MyGame.Game.Item;
using MyGame.Game.MapElements;
using MyGame.Ressources;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MyGame.Game.MapCells.Common
{
    public class CellViewModel : ICellViewModel, INotifyPropertyChanged
    {
        private bool _isOccupied = false;
        private bool _isMouseOver = false;
        private string _spriteImagePath;
        private IMapElement _element;

        private ICommand _displayDetailWindowCommand;

        public event EventHandler RaiseClickOnCell;

        public ICommand DisplayDetailWindowCommand
        {
            get
            {
                return (_displayDetailWindowCommand ?? (_displayDetailWindowCommand = new CommandRelay(DisplayDetailWindow, true)));
            }
        }

        private void DisplayDetailWindow(string key)
        {
            EventArgs e = new EventParameter(key);
            RaiseClickOnCell?.Invoke(this, e);
        }

        public string SpriteImagePath { get { return _spriteImagePath; } }

        public bool IsOccupied { get { return _isOccupied; } }

        public bool IsMouseOver { get { return _isMouseOver; } set { _isMouseOver = value; } }

        public IMapElement Element { get { return _element; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetElement(IMapElement element)
        {
            if (element == null)
            {
                SetSprite(null);
                _isOccupied = false;
                NotifyPropertyChanged(nameof(Element));
                return;
            }


            string folderRessourcesPath = RessourcesManager.GetPathFromElementMap(element);

            SetSprite(string.Concat(folderRessourcesPath, element.SpriteName));
            _isOccupied = element.IsPhysical;
            _element = element;

            NotifyPropertyChanged(nameof(Element));
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
