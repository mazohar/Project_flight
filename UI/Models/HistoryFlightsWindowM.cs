using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using Entities;

namespace UI.Models
{
    class HistoryFlightsWindowM
    {
        IBL bl;

        public HistoryFlightsWindowM()
        {
            bl = new BLImp();
        }

        public ObservableCollection<FlightDB> GetFlightsFromDB()
        {
            return bl.GetFlightsFromDB();
        }
    }
}
