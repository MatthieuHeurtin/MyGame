using System.Windows.Input;

namespace MyGame.Game.Map
{
    public class MapDataContext
    {
        private ICommand _moveCommand;
        private MapViewModel _mapViewModel;

        public ICommand MoveCommand
        {
            get
            {
                return (_moveCommand ?? (_moveCommand = new CommandRelay(_mapViewModel.Move, true)));
            }
        }

        public MapViewModel MapViewModel { get { return _mapViewModel; } }

        public MapDataContext()
        {
            _mapViewModel = new MapViewModel();
        }

    }
}
