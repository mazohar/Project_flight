using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;
using Entities;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UI.Commands;

namespace UI.ViewModels
{
    class DetailsPageVM : INotifyPropertyChanged
    {
        DetailsPageM model = new DetailsPageM();
        //public ICommand flightDetailsCommand { get; set; }

        public DetailsPageVM(FlightDetails _flight)
        {
            flight = _flight;
            weatherOrigin = model.GetWeather(flight.SourceLat, flight.SourceLong);
            weatherDestination = model.GetWeather(flight.DestinationLat, flight.DestinationLong);
            //flightDetailsCommand = new GetFlightDetailsCommand(this);
        }

        Weather weatherOrigin;
        public Weather WeatherOrigin
        {
            get
            {
                return weatherOrigin;
            }
            set
            {
                weatherOrigin = value;
                OnPropertyChanged("weatherOrigin");

            }
        }

        Weather weatherDestination;
        public Weather WeatherDestination
        {
            get
            {
                return weatherDestination;
            }
            set
            {
                weatherDestination = value;
                OnPropertyChanged("WeatherDestination");
            }
        }

        FlightDetails flight;
        public FlightDetails Flight
        {
            get
            {
                return flight;
            }
            set
            {
                flight = value;
                OnPropertyChanged("Flight");
            }
        }

        public void getFlightData(string key)
        {
            flight = model.getFlightData(key);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
