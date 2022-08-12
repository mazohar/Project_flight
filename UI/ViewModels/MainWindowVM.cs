﻿using System;
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
    class MainWindowVM : INotifyPropertyChanged
    {
        MainWindowM model = new MainWindowM();


        public MainWindowVM(Map _map)
        {
            var flightKeys = model.getFlights();
            flightIn = new ObservableCollection<FlightData>(flightKeys["Incoming"]);
            flightOut = new ObservableCollection<FlightData>(flightKeys["Outgoing"]);
            //map = new Map();
            map = _map;
            routeFlight = new MapLayer();
            showAllFlight = new MapLayer();
            map.Children.Add(routeFlight);
            map.Children.Add(showAllFlight);

            holiday = ifBeforeHoliday() + " will apply soon";

            frame = new Frame();
        }

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
                OnPropertyChanged("flightOut");

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
                OnPropertyChanged("flightOut");

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
                OnPropertyChanged("flightOut");

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
                OnPropertyChanged("flightOut");

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
                holiday = ifBeforeHoliday() + " will apply soon";
                OnPropertyChanged("holiday");

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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
                foreach (var flight in i.Value)
                {
                    Location l = new Location(flight.Lat, flight.Long);
                    Image myPushPin = addAirPlane(flight.DirectionFly);
                    myPushPin.ToolTip = flight.Id;
                    showAllFlight.AddChild(myPushPin, l, PositionOrigin.Center);
                }
            }
            map.Children.Add(showAllFlight);

            /*
             * var PlaneLocation = new Location { Latitude = lat, Longitude = lon };
            MapLayer mapLayer = new MapLayer();
           
            mapLayer.AddChild(ImagePinMap, PlaneLocation, origin);
           
           

            map.Children.Add(mapLayer);
            */

        }

        Image addAirPlane(int rotate)
        {
            Image myPushPin = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"C:\Users\renan\Source\Repos\Project_flight\UI\icon\airplane-mode.png");
            bitmap.DecodePixelHeight = 256;
            bitmap.DecodePixelWidth = 256;
            bitmap.EndInit();
            myPushPin.Source = bitmap;

            myPushPin.Width = 20;
            myPushPin.Height = 20;
            myPushPin.RenderTransform = new RotateTransform(rotate, 7.5, 7.5);
            return myPushPin;

            /*
            RotateTransform rotateTransform = new RotateTransform(Angle);
            image.RenderTransform = rotateTransform;
            image.Height = 20;
            image.Width = 20;
            ImagePinMap = image;
            ImagePinMap.ToolTip = flightM.FlightCode;
            if (flightM.FlightCode == "")
                ImagePinMap.ToolTip = "Data Problem";

            var PlaneLocation = new Location { Latitude = lat, Longitude = lon };
            MapLayer mapLayer = new MapLayer();

            mapLayer.AddChild(ImagePinMap, PlaneLocation, origin);



            map.Children.Add(mapLayer);
            */


        }

        void addNewPolyLine(List<Trail> route, FlightData flight)
        {
            routeFlight.Children.Clear();
            map.Children.Remove(routeFlight);

            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
            polyline.StrokeThickness = 1;
            polyline.Opacity = 0.7;
            polyline.Locations = new LocationCollection();
            foreach (var item in route)
                polyline.Locations.Add(new Location(item.lat, item.lng));

            Pushpin pinOrigin = new Pushpin { ToolTip = flight.Source };
            pinOrigin.Location = new Location(route.First().lat, route.First().lng);
            routeFlight.Children.Add(pinOrigin);
            routeFlight.Children.Add(polyline);
            map.Children.Add(routeFlight);
            showFlights();

        }

        public void listView_MouseDoubleClick(FlightData selectedFlight)
        {
            FlightDetails flight = model.getFlightData(selectedFlight.SourceId);

            if(flight != null && flight.Trail != null)
            {
                var trail = (from t in flight.Trail orderby t.ts select t).ToList<Trail>();
                addNewPolyLine(trail, selectedFlight);

                model.addFlightToDB(flight);

                frame.Content = new DetailsPage1(flight);
            }
            else
            {
                throw new Exception("There is a problem reading flight data. Try again");
            }

        }

        public string ifBeforeHoliday()
        {
            DateTime today = DateTime.Now;
            today = new DateTime(2022, 8, 4);
            string value = model.IfErevHolliday(today.Year, today.Month, today.Day);
            return value.Remove(0, 5);
        }
    }
}
