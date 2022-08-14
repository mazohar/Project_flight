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


        public BLImp() { }

        private IDL DL = new DLImp();
        public AsynceAdapter DLAdapter = new AsynceAdapter();


        //dictionary that contains the flights - outgoing and coinming  
        public Dictionary<string, List<FlightData>> getFlights()
        {
            return DL.getFlights();
        }

        //Information on one flight
        public FlightDetails getFlightData(string key)
        {
            return DL.getFlightData(key);
        }

        //Weather information by location
        public Weather GetWeather(double latatiude, double longitude)
        {
            return DL.GetWeather(latatiude, longitude);
        }

        //Checking whether a certain day is a holiday
        public string IfErevHolliday(int year, int month, int day)
        {
            return DL.IfErevHolliday(year, month, day);
        }

        //Entering a flight into a database

        public void addFlightToDB(FlightDetails flight)
        {
            DL.addFlightToDB(flight);
        }

        //Extracting flights from a database
        public ObservableCollection<FlightDB> GetFlightsFromDB()
        {
            return DL.GetFlightsFromDB();
        }

    }
}
