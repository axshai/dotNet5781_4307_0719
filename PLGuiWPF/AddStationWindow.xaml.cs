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
    /// Interaction logic for AddStationWindowWindow.xaml
    /// </summary>
    public partial class AddStationWindow : Window
    {
        IBL bl;
        BusStationBO current;
        public AddStationWindow(BusStationBO station = null)
        {
            InitializeComponent();
            cbArea.ItemsSource = Enum.GetValues(typeof(Area));
            bl = BLFactory.GetBL("1");
            current = station;
            if (station != null)
            {
                tblname.Text = "station key:";
                tbKey.Text = current.StationKey.ToString(); ;
                tbKey.IsReadOnly = true;
                tblarea.Visibility = cbArea.Visibility = Visibility.Hidden;
                addButton.Content = "EDIT";

            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                edit();
                return;
            }
            uint test;
            double testd;
            if (!uint.TryParse(tbKey.Text, out test))
            {
                MessageBox.Show("Station Key can only contain digits!");
                return;
            }
            if (tbName.Text == "")
            {
                MessageBox.Show("Please enter a station name!");
                return;
            }
            if (!double.TryParse(tblat.Text, out testd) || !double.TryParse(tblong.Text, out testd))
            {
                MessageBox.Show("Longitude and latitude must be a decimal number!");
                return;
            }
            if (cbArea.SelectedItem == null)
            {
                MessageBox.Show("Please select area!");
                return;
            }
            try
            {
                bl.AddBusStation(new BusStationBO { Area = (BO.Area)cbArea.SelectedItem, Latitude = double.Parse(tblat.Text), Longitude = double.Parse(tblong.Text), StationKey = int.Parse(tbKey.Text), StationName = tbName.Text });
                this.Close();
            }
            catch (BadBusStationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void edit()
        {

            double testd;

            if (tbName.Text == "")
            {
                MessageBox.Show("Please enter a station name!");
                return;
            }
            if (!double.TryParse(tblat.Text, out testd) || !double.TryParse(tblong.Text, out testd))
            {
                MessageBox.Show("Longitude and latitude must be a decimal number!");
                return;
            }
            try
            {
                bl.updateBusStation(new BusStationBO { Area = current.Area, Latitude = double.Parse(tblat.Text), Longitude = double.Parse(tblong.Text), StationKey = current.StationKey, StationName = tbName.Text });
                this.Close();
            }
            catch (BadBusStationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

