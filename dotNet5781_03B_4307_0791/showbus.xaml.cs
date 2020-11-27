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

namespace dotNet5781_03B_4307_0791
{
    /// <sumary>
    /// Interaction logic for showbus.xaml
    /// </summary>
    public partial class showbus : Window
    {
        List<Bus> busshow = new List<Bus>();
        Bus b1;
        public showbus(Bus myshowbus)
        {
            b1 = myshowbus;
            InitializeComponent();
            busshow.Add(b1);
            lbbuseshow.ItemsSource = busshow;
            
            
        }
        private void DriveButtom_Click(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;
            Bus selcted = fxElt.DataContext as Bus;
            drivewindow w1 = new drivewindow(selcted);
            w1.Show();

        }
        private void Refuelbutton_Click(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;
            Bus toRefuel = fxElt.DataContext as Bus;
            toRefuel.DoRefuel();
            MessageBox.Show("Refueling performed");
        }


    }
}
