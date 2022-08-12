using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands;
using UI.Models;


namespace UI.ViewModels
{
    class HistoryFlightsWindowVM : INotifyPropertyChanged
    {
        HistoryFlightsWindowM model = new HistoryFlightsWindowM();
        GetFlightsFromDBCommand command;

        public HistoryFlightsWindowVM()
        {
            flights = new ObservableCollection<FlightDB>();
            FlightsFromDBCommand = new GetFlightsFromDBCommand(this);
            fromTime = new DateTime(DateTime.Today.Year,DateTime.Today.Month,1);
            toTime = DateTime.Today;
        }

        public ICommand FlightsFromDBCommand { get; set; }


        ObservableCollection<FlightDB> flights;
        public ObservableCollection<FlightDB> Flights
        {
            get
            {
                return flights;
            }
            set
            {
                flights = value;
                OnPropertyChanged("flights");

            }
        }

        DateTime fromTime;
        public DateTime FromTime
        {
            get
            {
                return fromTime;
            }
            set
            {
                fromTime = value;
                OnPropertyChanged("fromTime");

            }
        }

        DateTime toTime;
        public DateTime ToTime
        {
            get
            {
                return toTime;
            }
            set
            {
                toTime = value;
                OnPropertyChanged("toTime");

            }
        }

        public void GetFlightsFromDB()
        {
            flights = model.GetFlightsFromDB();
            ObservableCollection<FlightDB> flightFilter = new ObservableCollection<FlightDB>(flights);
            foreach (var item in flights)
            {
                if (item.DateToday < fromTime || item.DateToday > toTime.AddDays(1))
                    flightFilter.Remove(item);
            }
            flights = flightFilter;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
