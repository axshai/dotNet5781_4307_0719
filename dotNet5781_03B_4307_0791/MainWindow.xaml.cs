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
using System.Threading;
using System.ComponentModel;

namespace dotNet5781_03B_4307_0791
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BackgroundWorker retuling;

        public ObservableCollection<Bus> Buses { get; set; }
        Button refBut;
        
        public MainWindow()
        {
            InitializeComponent();
            Buses = new ObservableCollection<Bus>();
            Buses.Add(new Bus(DateTime.Parse("03/03/2020"), "12445678"));//*
            //Buses.Add(new Bus(DateTime.Parse("07/03/2020"), "22445679"));//*
            Buses[0].DoRefuel();//*
            lbbuses.ItemsSource = Buses;
            retuling = new BackgroundWorker();
            retuling.DoWork += Retuling_DoWork;
            retuling.RunWorkerCompleted += Retuling_RunWorkerCompleted;

        }
       
        private void Refuelbutton_Click(object sender, RoutedEventArgs e)
        {

           var fxElt = sender as FrameworkElement;
           refBut = sender as Button;
          
           Bus toRefuel = fxElt.DataContext as Bus;
            if (!toRefuel.IsReady)
                MessageBox.Show("can not make refuel now");
            else
            {
                refBut.IsEnabled = false;
                retuling.RunWorkerAsync(toRefuel);
            }
        }

       
        private void Retuling_DoWork(object sender, DoWorkEventArgs e)
        {
            Bus toRefuel = e.Argument as Bus;
            toRefuel.State = STATUS.INREFUEL;
            Thread.Sleep(10000);
            toRefuel.DoRefuel();
            toRefuel.State = STATUS.READY;
        }

        private void Retuling_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            refBut.IsEnabled = true;
        }

        private void DriveButtom_Click(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;

            Bus selcted = fxElt.DataContext as Bus;
            if (!selcted.IsReady)
                MessageBox.Show("can not make drive now");
            else
            {
                
                drivewindow w1 = new drivewindow(sender, selcted);
                w1.Show();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addBus = new AddWindow(Buses);
            addBus.Show();



        }

        private void lbbuses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Bus showbus = lbbuses.SelectedItem as Bus;
            showbus myshowbus = new showbus(showbus);
            myshowbus.Show();
        }


      
    }
}
