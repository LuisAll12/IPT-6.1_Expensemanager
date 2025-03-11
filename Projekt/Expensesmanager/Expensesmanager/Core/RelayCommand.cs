﻿using System;
using System.Windows.Input;

namespace Expensesmanager.Core
{

    // Binds UI Buttons to methods in ViewModel
    class RelayCommand : ICommand
    {
        // Variables
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value;}
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // Functions
        // Determines whether the command can be executed
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
        // Invokes the _execute delegate with the provided parameter.
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
