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
    /// Interaction logic for AddLineWindow.xaml
    /// </summary>
    public partial class AddLineWindow : Window
    {
        IBL blObject;
        public AddLineWindow()
        {
            InitializeComponent();
            blObject = BLFactory.GetBL("1");
            cbArea.ItemsSource = Enum.GetValues(typeof(Area));
            cbfirst.ItemsSource = cblast.ItemsSource = blObject.GetAllStation();

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (cbfirst.SelectedItem == null || cblast.SelectedItem == null || cbArea.SelectedItem == null)
            {
                MessageBox.Show("Please select stations and area!");
                return;
            }
            try
            {
                blObject.AddLine(tbNum.Text, cbfirst.SelectedItem as BusStationBO, cblast.SelectedItem as BusStationBO, (BO.Area)cbArea.SelectedItem);
                this.Close();
            }
            catch (BadConsecutiveStationsKeysException)
            {

                tbNum.Visibility = Visibility.Hidden;
                tbTime.Visibility = Visibility.Visible;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addButton2_Click(object sender, RoutedEventArgs e)
        {
            uint validTime;
            double validDist;
            if (!uint.TryParse(tbTime.Text, out validTime) || !double.TryParse(tbdist.Text, out validDist))
            {
                MessageBox.Show("Please enter time and distance in the correct format!");
                tbTime.Text = tbdist.Text = "";
                return;
            }
            blObject.AddLine(tbNum.Text, cbfirst.SelectedItem as BusStationBO, cblast.SelectedItem as BusStationBO, (BO.Area)cbArea.SelectedItem, validDist, TimeSpan.FromMinutes(validTime));
            this.Close();
        }
    }
}
