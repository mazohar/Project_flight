using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BL;
using Entities;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for HistoryFlightsWindow.xaml
    /// </summary>
    public partial class HistoryFlightsWindow : Window
    {
        IBL bl;
        public HistoryFlightsWindow()
        {
            InitializeComponent();
        }

        public HistoryFlightsWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime from = fromDate.SelectedDate.Value;
            DateTime to = toDate.SelectedDate.Value.AddDays(1);
            ObservableCollection<FlightDB> flights = bl.GetFlightsFromDB();
            foreach(var item in flights)
            {
                if (item.DateToday < from || item.DateToday > to)
                    flights.Remove(item);
            }
            listViewHistory.ItemsSource = flights;
        }
    }
}
