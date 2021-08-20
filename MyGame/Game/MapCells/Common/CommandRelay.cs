using System;
using System.Windows.Input;

namespace MyGame.Game.MapCells.Common
{
    public class CommandRelay : ICommand
    {
        private readonly Action<string> _action;
        private readonly bool _canExecute;

        public CommandRelay(Action<string> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action(parameter as string);
        }
    }
}
