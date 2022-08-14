using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModels;

namespace UI.Commands
{
    //Responsible for the "Filter" button on the search page
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

        //A call to the function that is responsible for displaying all the flights in the database
        public void Execute(object parameter)
        {
            vm.GetFlightsFromDB();
        }
    }
}
