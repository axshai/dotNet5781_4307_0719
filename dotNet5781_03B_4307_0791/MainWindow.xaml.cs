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

namespace dotNet5781_03B_4307_0791
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Bus> buses = new List<Bus>();
        public MainWindow()
        {

            buses.Add(new Bus(DateTime.Parse("03/03/2020"), "12345678"));
            buses[0].DoRefuel();
            InitializeComponent();
            lvbuses.ItemsSource = buses;
        }

        private void driveButtom_Click(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;
            Bus selcted = fxElt.DataContext as Bus;
            drivewindow w1 = new drivewindow(selcted);
            w1.Show();
           
        }
    }
}
