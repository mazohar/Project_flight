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
    public partial class DetailsPage
    {
        DetailsPageVM DetailsPageVM;
        public DetailsPage(FlightDetails flight)
        {
            DetailsPageVM = new DetailsPageVM(flight);
            InitializeComponent();
            DataContext = DetailsPageVM;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }
    }
}