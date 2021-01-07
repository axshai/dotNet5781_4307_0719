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
namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for AddLineStationWindow.xaml-to add new station to the line
    /// </summary>
    public partial class AddLineStationWindow : Window
    {
        BusLineBO current;
        IBL bl;
        TimeSpan validTime;
        double validDist;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="line"></param>
        public AddLineStationWindow(BusLineBO line)
        {
            InitializeComponent();
            current = line;
            this.DataContext = current;
            cbIndex.SelectedIndex = cbStations.SelectedIndex = 0;
            bl = BLFactory.GetBL("1");
        }

        #region events
        /// <summary>
        /// add button click=when the user try to add the new station to the rout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbStations.SelectedItem == null)
                {
                    MessageBox.Show("No station selected");
                    return;
                }
                bl.AddLineStation(current.Id, (cbStations.SelectedItem as BusStationBO).StationKey, (int)cbIndex.SelectedItem);
                this.Close();
            }

            catch (BadConsecutiveStationsKeysException ex)//if have no deatails(time and distance) about the Stations that became consecutive as a result of adding the station
            {
                if (ex.Station1key == (cbStations.SelectedItem as BusStationBO).StationKey)
                {
                    ShowNext();
                }
                else
                    ShowPrev();

            }

        }

        /// <summary>
        /// When the user enter details about the time and distance between our station and the one before of it-press on button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TimeSpan.TryParse(tbptime.Text, out validTime) || !double.TryParse(tbpdist.Text, out validDist))
            {
                MessageBox.Show("Please enter time and distance in the correct format!");
                tbptime.Text = tbpdist.Text = "";
                return;
            }
            bl.AddLineStation(current.Id, (cbStations.SelectedItem as BusStationBO).StationKey, (int)cbIndex.SelectedItem, PrevDistance: double.Parse(tbpdist.Text), PrevTime: TimeSpan.Parse(tbptime.Text));
            this.Close();
        }

        /// <summary>
        /// When the user enter details about the time and distance between our station and the one after of it-press on button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TimeSpan.TryParse(tbntime.Text, out validTime) || !double.TryParse(tbndist.Text, out validDist))
            {
                MessageBox.Show("Please enter time and distance in the correct format!");
                tbntime.Text = tbndist.Text = "";
                return;
            }
            try
            {
                bl.AddLineStation(current.Id, (cbStations.SelectedItem as BusStationBO).StationKey, (int)cbIndex.SelectedItem, NextTime: TimeSpan.Parse(tbntime.Text), nextDistance: double.Parse(tbndist.Text));
                this.Close();
            }
            catch (BadConsecutiveStationsKeysException)
            {
                ShowPrev();//If there are still no details about the distance between her and the one before her
            }
        }

        #endregion

        #region Functions for screen replacement
        /// <summary>
        /// Show the controls for the option of adding time and distance information between the new station and the one after it
        /// </summary>
        private void ShowNext()
        {
            m1.Visibility = m2.Visibility = cbIndex.Visibility = cbStations.Visibility = firstButton.Visibility = Visibility.Hidden;
            n1.Visibility = n2.Visibility = tbndist.Visibility = tbntime.Visibility = nextButton.Visibility = Visibility.Visible;
        }
       
        /// <summary>
        /// Show the controls for the option of adding time and distance information between the new station and the one before it
        /// </summary>
        private void ShowPrev()
        {
            m1.Visibility = m2.Visibility = cbIndex.Visibility = cbStations.Visibility = firstButton.Visibility = Visibility.Hidden;
            n1.Visibility = n2.Visibility = tbndist.Visibility = tbntime.Visibility = nextButton.Visibility = Visibility.Hidden;
            p1.Visibility = p2.Visibility = tbpdist.Visibility = tbptime.Visibility = prevButton.Visibility = Visibility.Visible;
        }
        
        #endregion

    }
}
