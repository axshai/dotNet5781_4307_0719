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
        BackgroundWorker updateStatus;//thread for check if the bus is dangerous

        public ObservableCollection<Bus> Buses { get; set; }//list of all buses
        Button refBut;
        private void initializatione(ObservableCollection<Bus> Buses) // initializatione 10 buses
        {
            Random r = new Random(DateTime.Now.Millisecond);  //for the License number
            for (int i=0; i<7; i++) //initializatione 7 buses
            {
             Buses.Add(new Bus(DateTime.Now.AddMonths(-2 * i), r.Next(1000000, 9999999).ToString() + i));//add bus
                Buses[Buses.Count() - 1].TotalKm=(i+1)*100;//initializatione the curnet bus--totalKM
                Buses[Buses.Count() - 1].LastTreatment = DateTime.Now.AddMonths(-i);//initializatione the curnet bus-- LastTreatment
                Buses[Buses.Count() - 1].KmofTreatment = r.Next(50, Buses[Buses.Count() - 1].TotalKm);//initializatione the curnet bus-- KmofTreatment
                Buses[Buses.Count() - 1].DoRefuel();//do reful to the curnet bus
            }
            //One bus will be after the next treatment date
            Buses.Add(new Bus(DateTime.Now.AddMonths(-2*7),"12345677")); //We will add the eighth bus
            Buses[Buses.Count() - 1].TotalKm =800;
            Buses[Buses.Count() - 1].KmofTreatment =800;
            Buses[Buses.Count() - 1].DoRefuel();
            //One bus will be close to the next treatment passenger
            Buses.Add(new Bus(DateTime.Now.AddMonths(-2*8), "12345678"));//We will add the ninth bus
            Buses[Buses.Count() - 1].LastTreatment = DateTime.Now.AddMonths(-1);
            Buses[Buses.Count() - 1].TotalKm = 25000;
            Buses[Buses.Count() - 1].KmofTreatment =19950;
            Buses[Buses.Count() - 1].DoRefuel();
            //One bus will be with little fuel
            Buses.Add(new Bus(DateTime.Now.AddMonths(-2 * 9), "12345679"));
            Buses[Buses.Count() - 1].LastTreatment = DateTime.Now.AddMonths(-1);//We will add the tenth bus
            Buses[Buses.Count() - 1].TotalKm = 25000;
            Buses[Buses.Count() - 1].KmofTreatment =200;
            Buses[Buses.Count() - 1].Fuel = 50;

        }


        public MainWindow()
        {
            InitializeComponent();
            Buses = new ObservableCollection<Bus>();//creat list of buses
            initializatione(Buses);
            lbbuses.ItemsSource = Buses;//Determining the list as the source of the listbox
            updateStatus = new BackgroundWorker();//c
            updateStatus.DoWork += UpdateStatus_DoWork;
            updateStatus.RunWorkerAsync();
        }
           
            
       

        private void UpdateStatus_DoWork(object sender, DoWorkEventArgs e)//The function checks for each bus on the list if it becomes dangerous every 10 minutes
        {
            while (true)
            {
                foreach(Bus b in Buses)
                {
                    if (b.State == STATUS.READY)
                        b.DangerTest();
                }
                Thread.Sleep(600000);
            }
        }

        //-------------------------------------------Functions associated with timer thread:------------------------------------------------

        private void TimeCounter_DoWork(object sender, DoWorkEventArgs e)//work of timer
        {
            Bus toReful = e.Argument as Bus;
            int i = 0;
            while (!toReful.IsReadyOrDangroeus)
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
            //refBut = sender as Button;
            Bus toRefuel = fxElt.DataContext as Bus;
            
            if (!toRefuel.IsReadyOrDangroeus)//If the bus is in the middle of another operation
                MessageBox.Show("can not make refuel now");
            else
            {
                refuling = new BackgroundWorker();//Registration for the functions of the refueling and timer and updateStatus threads
                refuling.DoWork += refuling_DoWork;
                refuling.RunWorkerCompleted += refuling_RunWorkerCompleted;
                refuling.RunWorkerAsync(toRefuel);
            }
        }


        private void refuling_DoWork(object sender, DoWorkEventArgs e)//work of refuling
        {
            Bus toRefuel = e.Argument as Bus;
            timeCounter = new BackgroundWorker();//Creating a process for the timer
            timeCounter.DoWork += TimeCounter_DoWork;
            timeCounter.ProgressChanged += TimeCounter_ProgressChanged;
            timeCounter.RunWorkerCompleted += TimeCounter_RunWorkerCompleted;
            toRefuel.State = STATUS.INREFUEL;
            timeCounter.RunWorkerAsync(toRefuel);//Turn on the timer
            Thread.Sleep(REFTIME);//Wait for the time required and after that - refuel
            toRefuel.DoRefuel();
            if (!toRefuel.DangerTest())
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
            
            if (!selcted.IsReadyOrDangroeus)//If the bus is in the middle of another operation
                MessageBox.Show("can not make drive now");

            else if (selcted.DangerTest())//if the bus is dangerous
                MessageBox.Show("The bus is dangerous to travel!");
           
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