using System;
using System.Windows.Input;

namespace Sulmar.WPFMVVM.Common
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        // .NET 4.x
        //public event EventHandler CanExecuteChanged
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}

        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged!=null)
            {
                CanExecuteChanged.Invoke(this, EventArgs.Empty);
            }
        }

        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        // private readonly Predicate<object> canExecute2;


        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute.Invoke(parameter);

            //if (canExecute!=null)
            //{
            //    return canExecute.Invoke(parameter);
            //}
            //else
            //{
            //    return true;
            //}
        }

        public void Execute(object parameter)
        {
            //if (execute!=null)
            //    execute.Invoke(parameter);

            execute?.Invoke(parameter);
        }
    }
}
