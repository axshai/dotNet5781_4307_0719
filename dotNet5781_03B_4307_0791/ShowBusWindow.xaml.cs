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

    /// <sumary>
    /// Interaction logic for showbus.xaml
    /// </summary>
    public partial class ShowBusWindow : Window
    {
        
        BackgroundWorker process;
        BackgroundWorker timeCounter;
        const int REFTIME = 12000;//time for reful
        const int CARETIME =144000;//time for care
        List<Bus> busshow = new List<Bus>();//the "list" of buses
        Bus bus;
        public ShowBusWindow(Bus myshowbus)//We will get a bus builder for the show
        {
           // InitializeComponent();
            bus = myshowbus; 
            busshow.Add(bus);
           // lbbuseshow.ItemsSource = busshow;//We will tie the List Box
            process = new BackgroundWorker(); //create new process
            timeCounter = new BackgroundWorker();
            process.DoWork += Process_DoWork; //Write the function for the event
            process.RunWorkerCompleted += Process_RunWorkerCompleted;//Write the function for the event
            timeCounter.DoWork += TimeCounter_DoWork;//Write the function for the event
            timeCounter.ProgressChanged += TimeCounter_ProgressChanged;//Write the function for the event
            timeCounter.RunWorkerCompleted += TimeCounter_RunWorkerCompleted;//Write the function for the event 
        }

       

        private void TimeCounter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//At the end of the treatment / refueling
        {
           bus.TimerText = "";
        }

        private void TimeCounter_ProgressChanged(object sender, ProgressChangedEventArgs e)//Update the countdown timer
        {
            int time = ((string)e.UserState)== "12000"? REFTIME: CARETIME;//We will check whether it is a treatment or refueling
            bus.TimerText = (DateTime.Now.AddMilliseconds(time) - DateTime.Now.AddSeconds (e.ProgressPercentage)).ToString().Substring(0, 8);//We will update the "clock"
        }

        private void TimeCounter_DoWork(object sender, DoWorkEventArgs e)//Countdown clock in case of refueling or handling
        {
            
            int i = 0;
            while (!bus.IsReadyOrDangroeus)//while it is not a "dangerous" bus
            {

               TimeCounter_ProgressChanged(this, new ProgressChangedEventArgs(i, e.Argument));
               i++;
               Thread.Sleep(1000);

            }
        }

        private void Process_DoWork(object sender, DoWorkEventArgs e)// process (to case of refueling or handling)
        {
            
            if (int.Parse(e.Argument as string) == 1)//to handling
            {
                bus.State = STATUS.INCARE;//We will update the status of the treatment
                timeCounter.RunWorkerAsync(CARETIME.ToString());
                Thread.Sleep(CARETIME);
                bus.DoHandle();//do  handling
            }
            else //to reafuling
            {
                bus.State = STATUS.INREFUEL;//We will update the status of the reful
                timeCounter.RunWorkerAsync(REFTIME.ToString());
                Thread.Sleep(REFTIME); //Bus delay for reaful
                bus.DoRefuel(); // reful the bus
            }
           

        }

        private void Process_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//the reful or  treatment Completed
        {
           if(!bus.DangerTest())
                bus.State = STATUS.READY;
        }

        private void Refuelbutton_Click(object sender, RoutedEventArgs e)// "Refuelbutton event"
        {

            if (!bus.IsReadyOrDangroeus)
                MessageBox.Show("can not make refuel now,please wait");
            else
            {
                process.RunWorkerAsync("0"); //strat the process for thr "reful event"
               
            }
        }


        private void maintenanceButton_Click(object sender, RoutedEventArgs e)//"maintenancebutton  event"
        {
            if (!bus.IsReadyOrDangroeus)
                MessageBox.Show("can not make maintenance now,please wait");
            else
            {
                process.RunWorkerAsync("1");//strat the process for thr "maintenance event"

            }
        }
    }
}