using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CompanyApp
{
    public class CompanyCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public CompanyCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExecute = CanExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            _execute(parameter);
        }
    }
}
