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
        BackgroundWorker timeWorker;
        TimeSpan now2;
        int simulatSpeed;
        public ShowStationDetails(BusStationBO stationShow, bool isSimulateRun, TimeSpan now,int speed)
        {
            InitializeComponent();
            bl = BLFactory.GetBL("1");
            currentStation = stationShow;
            this.DataContext = currentStation;
            if (isSimulateRun)
            {
                simulatSpeed = speed;
                now2 = now;
                //Lbsimulation.DataContext = bl.GetLinesInTrips(stationShow, w1.timeNow);
                timeWorker = new BackgroundWorker();
                timeWorker.DoWork += TimeWorker_DoWork;
                timeWorker.RunWorkerAsync();
                timeWorker.WorkerReportsProgress = true;
                timeWorker.ProgressChanged += TimeWorker_ProgressChanged;
                timeWorker.WorkerSupportsCancellation = true;
            }
            else
            {
                Lbsimulation.Visibility = Visibility.Hidden;
                this.Height -= 200;
            }

        }

        private void TimeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            now2 = now2.Add(TimeSpan.FromSeconds(1));
            Lbsimulation.ItemsSource = bl.GetLinesInWayToStation(currentStation, now2);
            lastBusControl.DataContext = bl.GetLastLineInStation(currentStation, now2);
        }

        private void TimeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(1000/ simulatSpeed);
                timeWorker.ReportProgress(1);
            }
        }

        private void editTimeDist_Click(object sender, RoutedEventArgs e)
        {
            ConsecutiveStationBO b1 = (sender as Button).DataContext as ConsecutiveStationBO;
            EditTimeAndDistWindow wnd = new EditTimeAndDistWindow(b1);
            wnd.ShowDialog();
            this.DataContext = bl.GetBusStation((this.DataContext as BusStationBO).StationKey);
        }

        private void dgLines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LineArrivalTimesWindow wnd1 = new LineArrivalTimesWindow(dgLines.SelectedItem as LineInStationBO);
            wnd1.ShowDialog();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if(timeWorker!=null)
            timeWorker.CancelAsync();
        }

        
    }
}
