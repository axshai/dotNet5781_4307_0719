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
using System.Collections.ObjectModel;

namespace dotNet5781_03B_4307_0791
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Bus> Buses { get; set; }
        public MainWindow()
        {
            Buses = new ObservableCollection<Bus>();
            Buses.Add(new Bus(DateTime.Parse("03/03/2020"), "12445678"));//*
            Buses[0].DoRefuel();//*

            InitializeComponent();
            lbbuses.ItemsSource = Buses;


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


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addBus = new AddWindow(Buses);
            addBus.Show();



        }

        private void lbbuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
