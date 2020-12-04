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
using System.Text.RegularExpressions;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
namespace dotNet5781_03B_4307_0791
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class drivewindow : Window
    {
        BackgroundWorker driving;//thread for driving
        BackgroundWorker timeCounter;//thread for time Counter(time to end of the prossec)
        Bus toDrive;//bus to make the drive
        object driveBut;//the drive buttom in the main windeo-(to not enable click in the drive)
        int speed;
        int distance;
        
        public drivewindow(object sender, Bus b1)//ctor
        {
            InitializeComponent();
            toDrive = b1;
            driveBut = sender;
            speed = new Random(DateTime.Now.Millisecond).Next(20, 50);//Speed ​​lottery
            driving = new BackgroundWorker();
            timeCounter = new BackgroundWorker();
            driving.DoWork += Driving_DoWork;
            driving.RunWorkerCompleted += Driving_RunWorkerCompleted;
            timeCounter.DoWork += TimeCounter_DoWork;
            timeCounter.ProgressChanged += TimeCounter_ProgressChanged;
            timeCounter.RunWorkerCompleted += TimeCounter_RunWorkerCompleted;
           
        }
       
        private void TimeCounter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//When the timer finishes running
        {
            toDrive.TimerText = "00:00:00";//show 00:00:00
        }

        private void TimeCounter_ProgressChanged(object sender, ProgressChangedEventArgs e)//During the process
        {

            toDrive.TimerText = (DateTime.Now.AddSeconds(6*(distance / speed)) - DateTime.Now.AddSeconds(e.ProgressPercentage)).ToString().Substring(0, 8);//Update the timer
        }

        private void TimeCounter_DoWork(object sender, DoWorkEventArgs e)//work of timer
        {
           
            int i=0;
            while (!toDrive.IsReady)
            {
                TimeCounter_ProgressChanged(this, new ProgressChangedEventArgs(i, new object()));//Update every second
                i++;
                Thread.Sleep(1000);
            }
        }


        private void Driving_DoWork(object sender, DoWorkEventArgs e)//to drivind-work of drivimg prosses
        {
            string distance2 = (string)e.Argument;
            distance = int.Parse(distance2);
            toDrive.State = STATUS.INDRIVE;//update the status
            toDrive.Drive(distance);//make drive
            timeCounter.RunWorkerAsync(distance);//begin timer thread
            Thread.Sleep(6000 * (distance / speed));//sleep until drive will finish

        }

        private void Driving_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//That the drive was over
        {
            toDrive.State = STATUS.READY;//update the status
            (driveBut as Button).IsEnabled = true;//Enable click on the button
            if (e.Error != null)//If the trip was unsuccessful (as a result of the bus danger)
                MessageBox.Show(e.Error.Message);
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)//Enables typing of digits only
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbdistance_KeyDown(object sender, KeyEventArgs e)//when the usur Press on a key
        {
            if (e.Key == Key.Enter)//if he  Press enter
            {
                string distance = tbdistance.Text;

                (driveBut as Button).IsEnabled = false;//not eEnable press on the button during the drive
                driving.RunWorkerAsync(distance);//begin the drive thread

                this.Close();//close the window

            }
        }
    }
}
