using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using DLAPI;
using Entities;

namespace BL
{
    public class BLImp : IBL
    {


        /*#region singelton
        static readonly BLImp instance = new BLImp();
        static BLImp() { }
        public static BLImp Instance { get => instance; }
        #endregion*/

        public BLImp() { }

        private IDL DL = new DLImp();
        public AsynceAdapter DLAdapter = new AsynceAdapter();

        public Dictionary<string, List<FlightData>> getFlights()
        {
            return DL.getFlights();
        }

        public FlightDetails getFlightData(string key)
        {
            return DL.getFlightData(key);
        }
        public Weather GetWeather(double latatiude, double longitude)
        {
            return DL.GetWeather(latatiude, longitude);
        }
        public string IfErevHolliday(int year, int month, int day)
        {
            return DL.IfErevHolliday(year, month, day);
        }
        public void addFlightToDB(FlightDetails flight)
        {
            DL.addFlightToDB(flight);
        }
        public ObservableCollection<FlightDB> GetFlightsFromDB()
        {
            return DL.GetFlightsFromDB();
        }

    }
}
