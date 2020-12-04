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
using System.Diagnostics;

namespace dotNet5781_03B_4307_0791
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int REFTIME = 12000;//time of refuel prosses
        BackgroundWorker refuling;//thread for reful
        BackgroundWorker timeCounter; //thread for timer


        public ObservableCollection<Bus> Buses { get; set; }//list of all buses
        Button refBut;

        public MainWindow()
        {
            InitializeComponent();
            Buses = new ObservableCollection<Bus>();//creat list of buses
            Buses.Add(new Bus(DateTime.Parse("03/03/2020"), "12445678"));//*
            //Buses.Add(new Bus(DateTime.Parse("07/03/2020"), "22445679"));//*
            Buses[0].DoRefuel();//*
            lbbuses.ItemsSource = Buses;//Determining the list as the source of the listbox
            
            //Registration for the functions of the refueling and timer threads
            refuling = new BackgroundWorker();
            timeCounter=new BackgroundWorker();
            refuling.DoWork += refuling_DoWork;
            refuling.RunWorkerCompleted += refuling_RunWorkerCompleted;
            timeCounter.DoWork += TimeCounter_DoWork;
            timeCounter.ProgressChanged += TimeCounter_ProgressChanged;
            timeCounter.RunWorkerCompleted += TimeCounter_RunWorkerCompleted;
           

        }
        //-------------------------------------------Functions associated with timer thread:------------------------------------------------

        private void TimeCounter_DoWork(object sender, DoWorkEventArgs e)//work of timer
        {
            Bus toReful = e.Argument as Bus;
            int i = 0;
            while (!toReful.IsReady)
            {
                TimeCounter_ProgressChanged(this, new ProgressChangedEventArgs(i, toReful));//Update every second
                i++;
                Thread.Sleep(1000);
            }
            e.Result = toReful;
        }

        private void TimeCounter_ProgressChanged(object sender, ProgressChangedEventArgs e)//During the process
        {

            (e.UserState as Bus).TimerText = (DateTime.Now.AddMilliseconds(REFTIME) - DateTime.Now.AddSeconds(e.ProgressPercentage)).ToString().Substring(0, 8);//Update the timer
        }


        private void TimeCounter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//When the timer finishes running
        {
            (e.Result as Bus).TimerText = "00:00:00";
        }
        //---------------------------------------------------------------------------------------------

        //-----------------------------------Functions associated with pressing a refueling button---------------------------------------------------
        private void Refuelbutton_Click(object sender, RoutedEventArgs e)//Event of pressing the refueling button
        {

            var fxElt = sender as FrameworkElement;//Extract the bus that needs to be refueled
            refBut = sender as Button;
            Bus toRefuel = fxElt.DataContext as Bus;
            
            if (!toRefuel.IsReady)//If the bus is in the middle of another operation
                MessageBox.Show("can not make refuel now");
            else
            {
                refBut.IsEnabled = false;//Do not allow the button to be pressed
                refuling.RunWorkerAsync(toRefuel);//Start refueling and timer processes
                timeCounter.RunWorkerAsync(toRefuel);
            }
        }


        private void refuling_DoWork(object sender, DoWorkEventArgs e)//work of refuling
        {
            Bus toRefuel = e.Argument as Bus;
            toRefuel.State = STATUS.INREFUEL;
            Thread.Sleep(REFTIME);
            toRefuel.DoRefuel();
            toRefuel.State = STATUS.READY;
        }

        private void refuling_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//When the refuling finishes running
        {
            refBut.IsEnabled = true;//allow the button to be pressed
        }

        //--------------------------------------------------------------------------------------------------
        
        private void DriveButtom_Click(object sender, RoutedEventArgs e)//Event of pressing the drive button
        {
            var fxElt = sender as FrameworkElement;//Extract the bus that needs to make drive
            Bus selcted = fxElt.DataContext as Bus;
           
            if (!selcted.IsReady)//If the bus is in the middle of another operation
                MessageBox.Show("can not make drive now");
            else
            {
                drivewindow w1 = new drivewindow(sender, selcted);//open the drive window
                w1.Show();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)//Event of pressing the add drive button
        {
            AddWindow addBus = new AddWindow(Buses);//open the add window
            addBus.Show();
        }

        private void lbbuses_MouseDoubleClick(object sender, MouseButtonEventArgs e)//Event of pressing on bus in the list
        {
            Bus showbus = lbbuses.SelectedItem as Bus;//Extract the bus to show
            ShowBusWindow myshowbus = new ShowBusWindow(showbus);//open the ShowBusWindow window-show bus details
            myshowbus.Show();
        }
    }
}