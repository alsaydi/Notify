using System;
using System.Windows;
using System.Windows.Input;

namespace Notify
{
    public class RelayCommand<T> : ICommand where T :class, new()
    {
        public Action<T> CommandAction { get; set; }

        public Func<T,bool> CanExecuteFunc { get; set; }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc != null && CanExecuteFunc(parameter as T);
        }

        public void Execute(object parameter)
        {
            CommandAction(parameter as T);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
