using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModels;

namespace UI.Commands
{
    class GetFlightsFromDBCommand : ICommand
    {
        HistoryFlightsWindowVM vm;

        public GetFlightsFromDBCommand(HistoryFlightsWindowVM _vm)
        {
            vm = _vm;
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
            vm.GetFlightsFromDB();
        }
    }
}
