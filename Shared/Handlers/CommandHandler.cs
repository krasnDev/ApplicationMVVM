using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Shared.Handlers
{
    public class CommandHandler : ICommand
    {
        public CommandHandler(Action executeDelegate)
        {
            ExecuteDelegate = (arg) => executeDelegate();
            CanExecuteDelegate = () => true;
        }

        public CommandHandler(Action executeDelegate, Func<bool> canExecuteDelegate)
        {
            ExecuteDelegate = (arg) => executeDelegate();
            CanExecuteDelegate = canExecuteDelegate;
        }

        public CommandHandler(Action<object?> executeDelegate)
        {
            ExecuteDelegate = executeDelegate;
            CanExecuteDelegate = () => true;
        }

        public CommandHandler(Action<object?> executeDelegate, Func<bool> canExecuteDelegate)
        {
            ExecuteDelegate = executeDelegate;
            CanExecuteDelegate = canExecuteDelegate;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Func<bool> CanExecuteDelegate { get; set; }
        private Action<object?> ExecuteDelegate { get; set; }

        public static void UpdateCommandHandlers()
        {
            Application.Current?.Dispatcher?.Invoke(CommandManager.InvalidateRequerySuggested);
        }

        public bool CanExecute(object? parameter) => CanExecuteDelegate.Invoke();

        public void Execute(object? parameter) => ExecuteDelegate(parameter);
    }
}
