using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModels;

namespace UI.Commands
{
    class GetFlightDetailsCommand : ICommand
    {
        DetailsPageVM detailsPageVM;

        public GetFlightDetailsCommand(DetailsPageVM _detailsPageVM)
        {
            detailsPageVM = _detailsPageVM;
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
            detailsPageVM.getFlightData(detailsPageVM.Flight.Id);
        }
    }
}
