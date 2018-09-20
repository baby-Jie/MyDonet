using System;
using System.Windows.Input;

namespace WpfTest.Models
{
    class RelayCommand : ICommand
    {

        private Action<object> _exectuteMethod;
        private Func<object, bool> _canexecuteMethod;

        public RelayCommand(Action<object> executeMethod, Func<object, bool> canexecuteMethod)
        {
            _exectuteMethod = executeMethod;
            _canexecuteMethod = canexecuteMethod;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_canexecuteMethod != null)
            {
                return _canexecuteMethod(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            if (_exectuteMethod != null)
            {
                _exectuteMethod(parameter);
            }
        }
    }
}
