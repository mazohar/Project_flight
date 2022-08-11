using Microsoft.Maps.MapControl.WPF;
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

namespace UI
{
    /// <summary>
    /// Interaction logic for Try.xaml
    /// </summary>
    public partial class Try : Window
    {
        public Try()
        {
            InitializeComponent();

            MapLayer layer = new MapLayer();
            Pushpin p = new Pushpin();
            Location l = new Location(31.955494, 34.941389);
            p.Location = l;
            layer.Children.Add(p);
            Map m = new Map();
            m.Children.Add(layer);
            map.DataContext = m;
            /*ImageBrush airplane = new ImageBrush();
            airplane.ImageSource = new BitmapImage(new Uri("airplane-mode.png", UriKind.Relative));
            //airplane.Transform = new RotateTransform(45);
            p.Background = airplane;
            //Style v = (Style)Resources["airplane"];

            
            */
            





            /*
            Image airplane = new Image();
            airplane.Source = new BitmapImage(new Uri("airplane-mode.png", UriKind.Relative));
            airplane.Width = 20;
            airplane.Height = 20;
            airplane.RenderTransform = new RotateTransform(45);
            p.Resources.Add("a", airplane);

            p.Style = (Style)Resources["a"];*/
            //RotateTransform rotate = new RotateTransform();
            //rotate.Angle = 45;
            //p.RenderTransform = rotate;

            //p.RenderTransform = new RotateTransform(45);

            //map.Children.Add(p);

            /*MapLayer mapLayer = new MapLayer();
            Pushpin p = new Pushpin();
            Location l = new Location(47.620574, -122.34942);
            p.Location = l;
            map.Children.Add(p);
            Image myPushPin = new Image();
            myPushPin.Source = new BitmapImage(new Uri("YOUR IMAGE URL", UriKind.Relative));
            myPushPin.Width = 32;
            myPushPin.Height = 32;
            Location l = new Location(47.620574, -122.34942);
            mapLayer.AddChild(myPushPin, l);
            map.Children.Add(mapLayer);*/
        }
    }
}
