using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DLAPI
{
    public interface IDL
    {
        Dictionary<string, List<FlightData>> getFlights(); //return all the data at the data base       
        FlightDetails getFlightData(string key); //return one flight
        Weather GetWeather(double latatiude, double longitude); //Weather check by location
        string IfErevHolliday(int year, int month, int day); //Checking whether a certain day is a holiday
        void addFlightToDB(FlightDetails flight); //Entering a flight into a database
        ObservableCollection<FlightDB> GetFlightsFromDB(); //Extracting flights from a database




    }  
}
