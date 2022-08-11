using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using Entities;
using Microsoft.Maps.MapControl.WPF;
using static Entities.FlightM;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        IBL bl = new BLImp();
        //private Stopwatch stopWatch;
        private bool isTimerRun;
        BackgroundWorker timerworker;
        MapLayer routeFlight;
        MapLayer showAllFlight;

        public MainWindow()
        {
            InitializeComponent();

            routeFlight = new MapLayer();
            showAllFlight = new MapLayer();
            map.Children.Add(routeFlight);
            map.Children.Add(showAllFlight);

            timerworker = new BackgroundWorker();
            timerworker.DoWork += Worker_DoWork;
            timerworker.ProgressChanged += Worker_ProgressChanged;
            timerworker.WorkerReportsProgress = true;
            isTimerRun = true;
            timerworker.RunWorkerAsync();

            showFlights();

            string holiday = ifBeforeHoliday();
            if (holiday != null)
                holidatLabel.Content = holiday + " will apply soon";



        }

        private void showFlights()
        {
            Location BGA = new Location(32.009444, 34.876944);
            var flightKeys = bl.getFlights();
            listViewFlightIn.ItemsSource = flightKeys["Incoming"];
            listViewFlightOut.ItemsSource = flightKeys["Outgoing"];
            showAllFlight.Children.Clear();
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
        }


        Image addAirPlane(int rotate)
        {
            Image myPushPin = new Image();
            myPushPin.Style = (Style)Resources["styleImage"];
            myPushPin.Width = 20;
            myPushPin.Height = 20;
            myPushPin.RenderTransform = new RotateTransform(rotate, 7.5, 7.5);
            return myPushPin;
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
            
        }

        private void listViewFlightIn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedFlight = listViewFlightIn.SelectedItem as FlightData;
            listView_MouseDoubleClick(selectedFlight);

        }

        private void listViewFlightOut_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedFlight = listViewFlightOut.SelectedItem as FlightData;
            listView_MouseDoubleClick(selectedFlight);
        }

        private void listView_MouseDoubleClick(FlightData selectedFlight)
        {
            FlightDetails flight = bl.getFlightData(selectedFlight.SourceId);

            if (flight != null && flight.Trail !=null)
            {
                var trail = (from t in flight.Trail orderby t.ts select t).ToList<Trail>();
                addNewPolyLine(trail, selectedFlight);

                //bl.addFlightToDB(flight);

                frame.Visibility = Visibility.Visible;
                //frame.Content = new DetailsPage(bl, flight);
                frame.Content = new DetailsPage1(flight);
            }
            else
            {
                MessageBox.Show("There is a problem reading flight data. Try again");

            }

        }

        private string ifBeforeHoliday()
        {
            DateTime today = DateTime.Now;
            today = new DateTime(2022, 8, 4);
            string value = bl.IfErevHolliday(today.Year, today.Month, today.Day);
            return value.Remove(0, 5);
        }

        private void DataPickerClick(object sender, MouseButtonEventArgs e)
        {
            DateTime t = DataPickerDate.SelectedDate.Value;
            string value = bl.IfErevHolliday(t.Year, t.Month, t.Day);
            value = value.Remove(0, 5);

        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            showFlights();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isTimerRun)
            {
                timerworker.ReportProgress(1);
                Thread.Sleep(10000);
            }
        }

        private void historyFlights_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            HistoryFlightsWindow historyFlightsWindow = new HistoryFlightsWindow(bl);
            historyFlightsWindow.Left = this.Left;
            historyFlightsWindow.Top = this.Top;
            historyFlightsWindow.Show();

        }
    }
}
