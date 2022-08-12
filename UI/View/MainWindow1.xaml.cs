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
using System.Threading;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for MainWindow1.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {
        //private Stopwatch stopWatch;

        MainWindowVM vm;
        private bool isTimerRun;
        BackgroundWorker timerworker;
        public MainWindow1()
        {
            InitializeComponent();
            vm = new MainWindowVM(map);
            
            DataContext = vm;
            map = vm.Map;
          

            timerworker = new BackgroundWorker();
            timerworker.DoWork += Worker_DoWork;
            timerworker.ProgressChanged += Worker_ProgressChanged;
            timerworker.WorkerReportsProgress = true;
            isTimerRun = true;
            timerworker.RunWorkerAsync();

        }

        private void historyFlights_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            //HistoryFlightsWindow historyFlightsWindow = new HistoryFlightsWindow(bl);
            HistoryFlightsWindow1 historyFlightsWindow = new HistoryFlightsWindow1();

            historyFlightsWindow.Left = this.Left;
            historyFlightsWindow.Top = this.Top;
            historyFlightsWindow.Show();

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
            //var selectedFlight = listViewFlightIn.SelectedItem as FlightData;
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
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            vm.showFlights();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isTimerRun)
            {
                timerworker.ReportProgress(1);
                Thread.Sleep(10000);
            }
        }


    }
}
