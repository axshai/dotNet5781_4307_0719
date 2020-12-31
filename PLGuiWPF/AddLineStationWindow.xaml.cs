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
    /// Interaction logic for AddLineStationWindow.xaml
    /// </summary>
    public partial class AddLineStationWindow : Window
    {
        BusLineBO current;
        IBL bl;
        //if (!(valid = uint.TryParse(value, out toNum)))//Check that the license number includes only digits
        TimeSpan validTime;
        double validDist;
        public AddLineStationWindow(BusLineBO line)
        {
            InitializeComponent();
            current = line;
            this.DataContext = current;
            cbIndex.SelectedIndex = cbStations.SelectedIndex = 0;
            bl = BLFactory.GetBL("1");
        }



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
            catch (Exception ex)
            {
                showPrev();
            }
        }

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

            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "No details on time and distance between this stations end next station":
                        showNext();
                        break;
                    default:
                        showPrev();
                        break;
                }

            }

        }

        private void showNext()
        {
            m1.Visibility = m2.Visibility = cbIndex.Visibility = cbStations.Visibility = firstButton.Visibility = Visibility.Hidden;
            n1.Visibility = n2.Visibility = tbndist.Visibility = tbntime.Visibility = nextButton.Visibility = Visibility.Visible;
        }

        private void showPrev()
        {
            m1.Visibility = m2.Visibility = cbIndex.Visibility = cbStations.Visibility = firstButton.Visibility = Visibility.Hidden;
            n1.Visibility = n2.Visibility = tbndist.Visibility = tbntime.Visibility = nextButton.Visibility = Visibility.Hidden;
            p1.Visibility = p2.Visibility = tbpdist.Visibility = tbptime.Visibility = prevButton.Visibility = Visibility.Visible;
        }


    }
}
