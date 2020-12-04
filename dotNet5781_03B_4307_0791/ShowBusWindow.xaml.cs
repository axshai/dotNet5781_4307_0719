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
        const int REFTIME = 12000;
        const int CARETIME =144000;
        List<Bus> busshow = new List<Bus>();
        Bus bus;
        public ShowBusWindow(Bus myshowbus)
        {
            bus = myshowbus;
            InitializeComponent();
            busshow.Add(bus);
            lbbuseshow.ItemsSource = busshow;
            process = new BackgroundWorker();
            timeCounter = new BackgroundWorker();
            process.DoWork += Process_DoWork;
            timeCounter.DoWork += TimeCounter_DoWork;
            timeCounter.ProgressChanged += TimeCounter_ProgressChanged;
            timeCounter.RunWorkerCompleted += TimeCounter_RunWorkerCompleted;
           

        }

        private void TimeCounter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           bus.TimerText = "00:00:00";
        }

        private void TimeCounter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int time = ((string)e.UserState)== "12000"? REFTIME: CARETIME;
            bus.TimerText = (DateTime.Now.AddMilliseconds(time) - DateTime.Now.AddSeconds(e.ProgressPercentage)).ToString().Substring(0, 8);
        }

        private void TimeCounter_DoWork(object sender, DoWorkEventArgs e)
        {
            
            int i = 0;
            while (!bus.IsReady)
            {

                TimeCounter_ProgressChanged(this, new ProgressChangedEventArgs(i, e.Argument));
                i++;
                Thread.Sleep(1000);

            }
        }

        private void Process_DoWork(object sender, DoWorkEventArgs e)
        {
            
            if (int.Parse(e.Argument as string) == 1)
            {
                bus.State = STATUS.INCARE;
                timeCounter.RunWorkerAsync(CARETIME.ToString());
                Thread.Sleep(CARETIME);
                bus.DoHandle();
            }
            else 
            {
                bus.State = STATUS.INREFUEL;
                timeCounter.RunWorkerAsync(REFTIME.ToString());
                Thread.Sleep(REFTIME);
                bus.DoRefuel();
            }
            bus.State = STATUS.READY;

        }

        private void Refuelbutton_Click(object sender, RoutedEventArgs e)
        {

            if (!bus.IsReady)
                MessageBox.Show("can not make refuel now,please wait");
            else
            {
                process.RunWorkerAsync("0");
               
            }
        }


        private void maintenanceButton_Click(object sender, RoutedEventArgs e)
        {
            if (!bus.IsReady)
                MessageBox.Show("can not make maintenance now,please wait");
            else
            {
                process.RunWorkerAsync("1");
               
            }
        }
    }
}