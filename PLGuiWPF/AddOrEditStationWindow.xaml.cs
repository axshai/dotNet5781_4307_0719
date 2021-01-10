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
   /// add new station to system or edit exist station deatails
   /// </summary>
    public partial class AddOrEditStationWindow : Window
    {
        IBL bl;
        BusStationBO current;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="station">station to edit-null if the user press on "add station" button in the previous window</param>
        public AddOrEditStationWindow(BusStationBO station = null)
        {
            InitializeComponent();
            cbArea.ItemsSource = Enum.GetValues(typeof(Area));
            bl = BLFactory.GetBL("1");
            current = station;
            if (station != null)//if the user press on "edit station" button in the previous windeow-Adjust the graphics of a window to such an option
            {
                tblname.Text = "station key:";
                tbKey.Text = current.StationKey.ToString(); ;
                tbKey.IsReadOnly = true;
                tbKey.BorderThickness = new Thickness(0,0,0,0);
                tblarea.Visibility = cbArea.Visibility = Visibility.Hidden;//in edit Does not allow changing area of ​​station
                addButton.Content = "EDIT";

            }
        }
      
        /// <summary>
        /// event of press on the add/edit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (current != null)////if the user press on "edit station" button in the previous windeow-fo to edit func
            {
                edit();
                return;
            }
            //if the user want to edit new station:
          
            //Check input correctness:
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
           //try to add the new station:
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
       
        /// <summary>
        /// Function for editing station details
        /// </summary>
        private void edit()
        {
            //Check input correctness:
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
           //try to edit the station deatails
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

