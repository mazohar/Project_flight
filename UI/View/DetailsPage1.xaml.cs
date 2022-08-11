using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using UI.ViewModels;
using Entities;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for DetailsPage1.xaml
    /// </summary>
    public partial class DetailsPage1
    {
        DetailsPageVM DetailsPageVM;
        public DetailsPage1(FlightDetails flight)
        {
            DetailsPageVM = new DetailsPageVM(flight);
    
            InitializeComponent();
            //DetailsPageVM = new DetailsPageVM(flight);
            DataContext = DetailsPageVM;



            //bl = _bl;
            //Weather weatherDes = bl.GetWeather(flight.DestinationLat, flight.DestinationLong);
            //Weather weatherOrigin = bl.GetWeather(flight.SourceLat, flight.SourceLong);
            //flightCode.Content = flight.FlightCode;
            //airLine.Content = flight.AirLainName;
            //var uriSource = new Uri(flight.PictureOfAirPlane);
            //pictureAirPLane.Source = new BitmapImage(uriSource);
            //originCode.Content = flight.SourceCode;
            //originName.Content = flight.SourceName;
            //desCode.Content = flight.DestinationCode;
            //desName.Content = flight.DestinationName;
            //originTime.Content = flight.TimeOfFly.ToString("HH:mm");
            //desTime.Content = flight.TimeOfFArrive.ToString("HH:mm");
            //tempOrigin.Content = weatherOrigin.Temp + "°";
            //feelOrigin.Content = weatherOrigin.FeelLikeTemp + "°";
            //tempDes.Content = weatherDes.Temp + "°";
            //feelDes.Content = weatherDes.FeelLikeTemp + "°";
            //stateOrigin.Content = weatherOrigin.State;
            //stateDes.Content = weatherDes.State;

            //bool isLate = flight.TimeOfFArrive < DateTime.Now;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }
    }
}