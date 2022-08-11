using Entities;
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
using System.Windows.Shapes;
using UI.ViewModels;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for HistoryFlightsWindow1.xaml
    /// </summary>
    public partial class HistoryFlightsWindow1 : Window
    {
        HistoryFlightsWindowVM vm = new HistoryFlightsWindowVM();
        public HistoryFlightsWindow1()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            DateTime from = fromDate.SelectedDate.Value;
            DateTime to = toDate.SelectedDate.Value.AddDays(1);
            List<FlightDB> flights = vm.GetFlightsFromDB();
            foreach (var item in flights)
            {
                if (item.DateToday < from || item.DateToday > to)
                    flights.Remove(item);
            }
            listViewHistory.ItemsSource = flights;*/
        }
    }
}
