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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.ViewModels;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControlDetails : UserControl
    {
        DetailsPageVM DetailsPageVM;
        public FlightDetails flight { get; set; }
        public UserControlDetails()
        {
            DetailsPageVM = new DetailsPageVM(flight);

            InitializeComponent();
            DataContext = DetailsPageVM;
        }
    }
}
