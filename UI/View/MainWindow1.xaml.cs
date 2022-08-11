using Entities;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using UI.ViewModels;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for MainWindow1.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {
        //private Stopwatch stopWatch;

        MainWindowVM vm;
        public MainWindow1()
        {
            InitializeComponent();
            vm = new MainWindowVM(map);
            
            DataContext = vm;
            map = vm.Map;
            //map.DataContext = vm.Map;
        }

        private void historyFlights_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            //HistoryFlightsWindow historyFlightsWindow = new HistoryFlightsWindow(bl);
            HistoryFlightsWindow1 historyFlightsWindow = new HistoryFlightsWindow1();

            historyFlightsWindow.Left = this.Left;
            historyFlightsWindow.Top = this.Top;
            historyFlightsWindow.Show();

        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedFlight = listViewFlightIn.SelectedItem as FlightData;
            f.Visibility = Visibility.Visible;
            try
            {
                vm.listView_MouseDoubleClick(selectedFlight);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
