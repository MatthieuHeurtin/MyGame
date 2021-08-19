using MyGame.Game.Character.Characters;
using MyGame.Game.Map.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace MyGame.Game.Map
{
    public class MapDataContext
    {
        private ICommand _moveCommand;

        public ICommand MoveCommand
        {
            get
            {
                return (_moveCommand ?? (_moveCommand = new CommandRelay(Movement.Move, true)));
            }
        }


    }
}
