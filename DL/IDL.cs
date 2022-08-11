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
        Dictionary<string, List<FlightData>> getFlights();//return all the data at the data base       
        FlightDetails getFlightData(string key);//return one flights
        Weather GetWeather(double latatiude, double longitude);
        string IfErevHolliday(int year, int month, int day);
        void addFlightToDB(FlightDetails flight);
        ObservableCollection<FlightDB> GetFlightsFromDB();
    }
}
