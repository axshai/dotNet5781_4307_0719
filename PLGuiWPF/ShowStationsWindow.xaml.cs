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
        #region Fields for the simulator
        BackgroundWorker timeWorker;
        public TimeSpan timeNow;
        int speed;
        bool isTimerRun;
        #endregion
       
        Button prev;//will be used in Window_Closing
        IBL blObject;
        /// <summary>
        /// ctor
        /// </summary>
        public ShowStationsWindow(Button b)
        {
            InitializeComponent();
            blObject = BLFactory.GetBL("1");
            dgStations.ItemsSource = blObject.GetAllStation();
            prev = b;

        }
       
        #region simulator function
       
        private void TimeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            timeNow = timeNow.Add(TimeSpan.FromSeconds((int)e.ProgressPercentage));//update the clock in the screen
            LtimeDisplay.Content = timeNow.ToString().Substring(0, 8);
        }

        private void TimeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isTimerRun)
            {
                timeWorker.ReportProgress(1);
                Thread.Sleep(1000 / (int)e.Argument);
            }
        }
      
        /// <summary>
        /// click on the start/stop button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simulatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isTimerRun)//If at the time of pressing the simulator is not activated(so The click should activate the simulator)
            {
                if (tbspeed.Text == "")//check if he enter the speed
                {
                    tbspeed.BorderBrush = Brushes.Red;
                    return;
                }
                //Adjust the window and start the thread
                startTime.Visibility = Visibility.Hidden;
                LtimeDisplay.Visibility = Visibility.Visible;
                tbspeed.BorderBrush = default;
                speed = int.Parse(tbspeed.Text);
                timeWorker = new BackgroundWorker();
                timeWorker.DoWork += TimeWorker_DoWork;
                timeWorker.ProgressChanged += TimeWorker_ProgressChanged;
                timeWorker.WorkerReportsProgress = true;
                timeNow = startTime.Value;
                isTimerRun = true;
                tbspeed.IsEnabled = false;
                timeWorker.RunWorkerAsync(speed);

            }
            else//If at the time of pressing the simulator is activated(so The click should stop the simulator)
            {
                ////Adjust the window and stop the thread
                isTimerRun = false;
                tbspeed.IsEnabled = true;
                startTime.Visibility = Visibility.Visible;
                LtimeDisplay.Visibility = Visibility.Hidden;
            }
        }

        #endregion
        
        /// <summary>
        /// Clicking on specific station/row in the datagrid-to see the stations deatails
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgStations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgStations.SelectedItem == null)
                return;
            ShowStationDetails w1 = new ShowStationDetails(dgStations.SelectedItem as BusStationBO, isTimerRun, timeNow, speed);
            w1.ShowDialog();
            dgStations.ItemsSource = blObject.GetAllStationBy(station1 => station1.StationKey.ToString().StartsWith(tbsearch.Text));
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
       
        /// <summary>
        /// A function designed to allow you to type only digits in the Simulator Speed ​​window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbspeed_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Window_Closing eevent-when the window closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            prev.IsEnabled = true;//Allow clicking on the button you came from(in the previous window)
        }
    }
}
