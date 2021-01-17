using BLApi;
using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for ShowStationWindow.xaml-show all stations in the system
    /// </summary>
    public partial class ShowStationsWindow : Window
    {

        Stopwatch watch;
        BackgroundWorker timeWorker;
        bool isTimerRun;
       IBL blObject;
        /// <summary>
        /// ctor
        /// </summary>
        public ShowStationsWindow()
        {
            InitializeComponent();
            blObject = BLFactory.GetBL("1");
            dgStations.ItemsSource = blObject.GetAllStation();
          //  watch = new Stopwatch();
           

        }

        private void TimeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            startTime.Value = startTime.Value.Add(TimeSpan.FromSeconds((int)e.ProgressPercentage));
        }

        private void TimeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           while(isTimerRun)
            {
                timeWorker.ReportProgress((int)e.Argument);
                Thread.Sleep(1000);
            }
        }

        #region events
        /// <summary>
        /// Clicking on specific station/row in the datagrid-to see the stations deatails
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgStations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgStations.SelectedItem == null)
                return;
            ShowStationDetails w1 = new ShowStationDetails(dgStations.SelectedItem as BusStationBO);
            w1.ShowDialog();
            dgStations.ItemsSource = blObject.GetAllStationBy(station1=>station1.StationKey.ToString().StartsWith(tbsearch.Text));
        }

        /// <summary>
        ///  Clicking the add station button-to add new station
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditStationWindow wnd = new AddOrEditStationWindow();
            wnd.ShowDialog();
            dgStations.ItemsSource = blObject.GetAllStationBy(station1 => station1.StationKey.ToString().StartsWith(tbsearch.Text));
        }
        /// <summary>
        /// Clicking the edit station button-to etid stations deatails
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditStationWindow wnd = new AddOrEditStationWindow((sender as Button).DataContext as BusStationBO);
            wnd.ShowDialog();
            dgStations.ItemsSource = blObject.GetAllStationBy(station1 => station1.StationKey.ToString().StartsWith(tbsearch.Text));
        }

        /// <summary>
        /// Clicking the delete station button-to delete a station
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                blObject.DeleteBusStation((sender as Button).DataContext as BusStationBO);
                dgStations.ItemsSource = blObject.GetAllStationBy(station1 => station1.StationKey.ToString().StartsWith(tbsearch.Text));
            }
            catch (BadBusStationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// text box TextChanged-when searching after station
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgStations.ItemsSource = blObject.GetAllStationBy(station1 => station1.StationKey.ToString().StartsWith(tbsearch.Text));
        }
        #endregion


        private void simulatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isTimerRun)
            {
                int speed = int.Parse(tbspeed.Text);
                timeWorker = new BackgroundWorker();
                timeWorker.DoWork += TimeWorker_DoWork;
                timeWorker.ProgressChanged += TimeWorker_ProgressChanged;
                timeWorker.WorkerReportsProgress = true;
                // watch.Restart();
                isTimerRun = true;
                tbspeed.IsEnabled = false;
                timeWorker.RunWorkerAsync(speed);

            }
            else
            {
                isTimerRun = false;
                tbspeed.IsEnabled = true;
            }
        }

       

        private void tbspeed_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
