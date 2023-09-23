using System;
using System.Windows.Input;

namespace PizzeriaGuide.Handlers
{
    public class CommandHandler : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Action _executeWithoutparam;
        private readonly Predicate<object> _canExecute;
        private readonly Func<bool> _canExecuteWithoutParam;

        public CommandHandler(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public CommandHandler(Action execute, Func<bool> canExecute = null)
        {
            _executeWithoutparam = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecuteWithoutParam = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is null)
            {
               return _canExecuteWithoutParam == null || _canExecuteWithoutParam();
            }

            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if(parameter is null)
            {
                _executeWithoutparam();
            }
            else
            {
                _execute(parameter);
            }
        }
    }
}
