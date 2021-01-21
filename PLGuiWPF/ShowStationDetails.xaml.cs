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
using BO;
using BLApi;
using System.ComponentModel;
using System.Threading;

namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for ShowStationDetails.xaml
    /// </summary>
    public partial class ShowStationDetails : Window
    {
        IBL bl;
        BusStationBO currentStation;
        BackgroundWorker timeWorker;//to simulator thread
        TimeSpan timeNow;//the time now
        int simulatSpeed;//speed of the simulatoe
        public ShowStationDetails(BusStationBO stationShow, bool isSimulateRun, TimeSpan now, int speed)
        {
            InitializeComponent();
            bl = BLFactory.GetBL("1");
            currentStation = stationShow;
            this.DataContext = currentStation;
            if (isSimulateRun)//if the simulator is run now
            {
                simulatSpeed = speed;
                timeNow = now;
                timeWorker = new BackgroundWorker();
                timeWorker.DoWork += TimeWorker_DoWork;
                timeWorker.RunWorkerAsync();
                timeWorker.WorkerReportsProgress = true;
                timeWorker.ProgressChanged += TimeWorker_ProgressChanged;
                timeWorker.WorkerSupportsCancellation = true;
            }
            else//Adjust the screen
            {
                Lbsimulation.Visibility = Visibility.Hidden;
                this.Height -= 200;
            }

        }
        #region simulator thread
        private void TimeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Get re-information on the arrival time of the buses to the station
            timeNow = timeNow.Add(TimeSpan.FromSeconds(1));
            Lbsimulation.ItemsSource = bl.GetLinesInWayToStation(currentStation, timeNow);
            lastBusControl.DataContext = bl.GetLastLineInStation(currentStation, timeNow);
        }

        private void TimeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(1000 / simulatSpeed);//Run the simulator at the appropriate speed
                timeWorker.ReportProgress(1);
            }
        }
        #endregion

        /// <summary>
        /// Function that occurs when the user clicks the Edit Time and Distance button between consecutive stations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editTimeDist_Click(object sender, RoutedEventArgs e)
        {
            ConsecutiveStationBO b1 = (sender as Button).DataContext as ConsecutiveStationBO;
            EditTimeAndDistWindow wnd = new EditTimeAndDistWindow(b1);
            wnd.ShowDialog();
            this.DataContext = bl.GetBusStation((this.DataContext as BusStationBO).StationKey);//Retrieve from the data layer the updated information for this station
        }

        /// <summary>
        /// When the user clicks on the list of lines that stop in this station
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgLines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LineArrivalTimesWindow wnd1 = new LineArrivalTimesWindow(dgLines.SelectedItem as LineInStationBO);//Show the arrival times of the bus to the station
            wnd1.ShowDialog();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (timeWorker != null)
                timeWorker.CancelAsync();
        }


    }
}
