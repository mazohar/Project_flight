using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using UI.Models;
using Entities;
using Microsoft.Maps.MapControl.WPF;
using static Entities.FlightM;
using System.Windows.Controls;
using UI.View;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using BL;

namespace UI.ViewModels
{
    //view model for the main window
    class MainWindowVM : INotifyPropertyChanged
    {
        //object of the model type
        MainWindowM model = new MainWindowM();

        //ID for the current flight - which we can display even after a 10-second update
        string chooseFlightID = "";

        //constructor
        public MainWindowVM(Map _map)
        {
            var flightKeys = model.getFlights();
            flightIn = new ObservableCollection<FlightData>(flightKeys["Incoming"]);
            flightOut = new ObservableCollection<FlightData>(flightKeys["Outgoing"]);
            map = _map;
            routeFlight = new MapLayer();
            showAllFlight = new MapLayer();
            map.Children.Add(routeFlight);
            map.Children.Add(showAllFlight);

            //Checking whether today is the day before a holiday
            checkHoliday();

            frame = new Frame();
        }


        //property:

        ObservableCollection<FlightData> flightIn;
        public ObservableCollection<FlightData> FlightIn
        {
            get
            {
                return flightIn;
            }
            set
            {
                flightIn = value;
                OnPropertyChanged("flightIn");

            }
        }

        ObservableCollection<FlightData> flightOut;
        public ObservableCollection<FlightData> FlightOut
        {
            get
            {
                return flightOut;
            }
            set
            {
                flightOut = value;
                OnPropertyChanged("flightOut");

            }
        }

        MapLayer routeFlight;
        public MapLayer RouteFlight
        {
            get
            {
                return routeFlight;
            }
            set
            {
                routeFlight = value;
                OnPropertyChanged("routeFlight");

            }
        }

        MapLayer showAllFlight;
        public MapLayer ShowAllFlight
        {
            get
            {
                return showAllFlight;
            }
            set
            {
                showAllFlight = value;
                OnPropertyChanged("showAllFlight");

            }
        }

        Map map;
        public Map Map
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
                OnPropertyChanged("map");

            }
        }

        Frame frame;
        public Frame Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
                OnPropertyChanged("frame");

            }
        }

        string holiday;
        public string Holiday
        {
            get
            {
                return holiday;
            }
            set
            {
                holiday = value;
                OnPropertyChanged("holiday");

            }
        }

        public void checkHoliday()
        {
            string check = ifBeforeHoliday();
            if (check == "no holliday")
                holiday = "Today is regular day";
            else
                holiday = check + " will apply soon";
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //A function that displays all flights
        public void showFlights()
        {
            Location BGA = new Location(32.009444, 34.876944);
            var flightKeys = model.getFlights();
            flightIn = new ObservableCollection<FlightData>(flightKeys["Incoming"]);
            flightOut = new ObservableCollection<FlightData>(flightKeys["Outgoing"]);
            showAllFlight.Children.Clear();
            showAllFlight = new MapLayer();

            map.Children.Remove(showAllFlight);

            foreach (var i in flightKeys)
            {
                // Going over each flight and creating a picture that fits
                foreach (var flight in i.Value)
                {
                    Location l = new Location(flight.Lat, flight.Long);
                    Image myPushPin = addAirPlane(flight.DirectionFly);
                    myPushPin.ToolTip = flight.Id;
                    myPushPin.Tag = flight.Id;
                    showAllFlight.AddChild(myPushPin, l, PositionOrigin.Center);
                    
                }
            }

            // Deleting the current plane to put it in a glowing color
            if (chooseFlightID != "")
                deleteFlight(chooseFlightID);

            map.Children.Add(showAllFlight);

        }

        //Rotate the image to the angle of flight
        Image addAirPlane(int rotate)
        {
            Image myPushPin = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"C:\Users\מעין זוהר\Source\Repos\Project_flight3\UI\icon\airplane-mode.png");
            bitmap.DecodePixelHeight = 256;
            bitmap.DecodePixelWidth = 256;
            bitmap.EndInit();
            myPushPin.Source = bitmap;

            myPushPin.Width = 20;
            myPushPin.Height = 20;
            myPushPin.RenderTransform = new RotateTransform(rotate, 7.5, 7.5);
            return myPushPin;


        }

        //Deletion of a certain flight by the id of a selected flight
        public void deleteFlight(string id)
        {
            List<Image> list = new List<Image>();
            foreach (var item in showAllFlight.Children)
            {
                if (item is Image)
                    list.Add(item as Image);
            }
            
            Image toDelete = list.Find(e => (string)e.Tag == id); // Finding the flight by its id
            showAllFlight.Children.Remove(toDelete); // remove the flight
            OnPropertyChanged("showAllFlight"); // updating
        }

        // Drawing the route of the flight
        void addNewPolyLine(List<Trail> route, FlightData flight)
        {
            //Clearing the map
            routeFlight.Children.Clear();
            map.Children.Remove(routeFlight);

            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
            polyline.StrokeThickness = 1;
            polyline.Opacity = 0.7;
            polyline.Locations = new LocationCollection();

            //Going over the entire trail and adding a line by location
            foreach (var item in route)
                polyline.Locations.Add(new Location(item.lat, item.lng));

            Pushpin pinOrigin = new Pushpin { ToolTip = flight.Source };
            pinOrigin.Location = new Location(route.First().lat, route.First().lng);
            routeFlight.Children.Add(pinOrigin);
            routeFlight.Children.Add(polyline);

            //Adding a picture to the current plane - in bold color
            Image myPushPin = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"C:\Users\מעין זוהר\Source\Repos\Project_flight3\UI\icon\choose_airport.png");
            bitmap.DecodePixelHeight = 256;
            bitmap.DecodePixelWidth = 256;
            bitmap.EndInit();
            myPushPin.Source = bitmap;
            myPushPin.Width = 20;
            myPushPin.Height = 20;
            myPushPin.RenderTransform = new RotateTransform(flight.DirectionFly, 7.5, 7.5);
            Location l = new Location(route.Last().lat, route.Last().lng);
            routeFlight.AddChild(myPushPin, l, PositionOrigin.Center);

            map.Children.Add(routeFlight);
            //Showing all flights
            showFlights();

        }

        //Double click event on the list of flights
        public void listView_MouseDoubleClick(FlightData selectedFlight)
        {
            FlightDetails flight = model.getFlightData(selectedFlight.SourceId);

            //Drawing the plane's route line, deleting the plane and placing a new plane is highlighted

            if (flight != null && flight.Trail != null)
            {
                var trail = (from t in flight.Trail orderby t.ts select t).ToList<Trail>();
                addNewPolyLine(trail, selectedFlight);

                deleteFlight(selectedFlight.Id);
                chooseFlightID = selectedFlight.Id;

                model.addFlightToDB(flight);

                frame.Content = new DetailsPage(flight);
            }
            else
            {
                throw new Exception("There is a problem reading flight data. Try again");
            }

        }

        //Checking if it is a holiday and returning the appropriate value
        public string ifBeforeHoliday()
        {
            DateTime today = DateTime.Now;
            string value = model.IfErevHolliday(today.Year, today.Month, today.Day);
            if (value != "no holliday")
                value.Remove(0, 5); //to download the word "Erav"
            return value;
        }
    }
}
