using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModels;

namespace UI.Commands
{
    class GetFlightsCommand : ICommand
    {
        // public event EventHandler CanExecuteChanged;
        MainWindowVM mainWindowVM;

        public GetFlightsCommand(MainWindowVM _mainWindowVM)
        {
            mainWindowVM = _mainWindowVM;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //mainWindowVM.
        }
    }
}
