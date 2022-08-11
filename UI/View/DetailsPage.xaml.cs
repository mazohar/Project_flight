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
using BL;
using Entities;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for details.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        IBL bl;
        public DetailsPage(IBL _bl, FlightDetails flight)
        {
            InitializeComponent();
            bl = _bl;
            Weather weatherDes = bl.GetWeather(flight.DestinationLat, flight.DestinationLong);
            Weather weatherOrigin = bl.GetWeather(flight.SourceLat, flight.SourceLong);
            flightCode.Content = flight.FlightCode;
            airLine.Content = flight.AirLainName;
            var uriSource = new Uri(flight.PictureOfAirPlane);
            pictureAirPLane.Source = new BitmapImage(uriSource);
            originCode.Content = flight.SourceCode;
            originName.Content = flight.SourceName;
            desCode.Content = flight.DestinationCode;
            desName.Content = flight.DestinationName;
            originTime.Content = flight.TimeOfFly;
            desTime.Content = flight.TimeOfFArrive;
            tempOrigin.Content = weatherOrigin.Temp + "°";
            feelOrigin.Content = weatherOrigin.FeelLikeTemp + "°";
            tempDes.Content = weatherDes.Temp + "°";
            feelDes.Content = weatherDes.FeelLikeTemp + "°";
            stateOrigin.Content = weatherOrigin.State;
            stateDes.Content = weatherDes.State;

            //bool isLate = flight.TimeOfFArrive < DateTime.Now;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }
    }
}
