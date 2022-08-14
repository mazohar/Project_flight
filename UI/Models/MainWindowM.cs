using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using Entities;

namespace UI.Models
{
    //Model for the main page
    class MainWindowM
    {
        IBL bl;

        public MainWindowM()
        {
            bl = new BLImp();
        }

        public Dictionary<string, List<FlightData>> getFlights()
        {
            return bl.getFlights();
        }

        public FlightDetails getFlightData(string key)
        {
            return bl.getFlightData(key);
        }

        public string IfErevHolliday(int year, int month, int day)
        {
            return bl.IfErevHolliday(year, month, day);
        }

        public void addFlightToDB(FlightDetails flight)
        {
            bl.addFlightToDB(flight);
        }
    }
}
