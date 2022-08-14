using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BL
{
    public interface IBL
    {
        Dictionary<string, List<FlightData>> getFlights(); //dictionary that contains the flights - outgoing and coinming  

        FlightDetails getFlightData(string key); //Information on one flight

        Weather GetWeather(double latatiude, double longitude); //Weather information by location
        string IfErevHolliday(int year, int month, int day); //Checking whether a certain day is a holiday
        void addFlightToDB(FlightDetails flight); //Entering a flight into a database
        ObservableCollection<FlightDB> GetFlightsFromDB(); //Extracting flights from a database

    }
}
