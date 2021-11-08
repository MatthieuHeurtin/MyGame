using MyGame.Game.MapElements;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MyGame.Game.MapCells.GraphicMapCell
{
    public class GuiMapCellViewModel : IGuiMapCellViewModel, INotifyPropertyChanged
    {

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
            EventArgsFromCell e = new EventArgsFromCell(EventFromCellType.UpdateControlArea, key);
            RaiseClickOnCell?.Invoke(this, e);
        }

        public string SpriteImagePath { get { return _spriteImagePath; } }


        public bool IsMouseOver { get { return _isMouseOver; } set { _isMouseOver = value; } }

        public IMapElement Element { get { return _element; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetElement(IMapElement element)
        {
            _element = element;

            NotifyPropertyChanged(nameof(Element));
        }

        public void SetSprite(string spriteNamePath)
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
