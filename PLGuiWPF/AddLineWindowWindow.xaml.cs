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
    /// Interaction logic for AddLineWindow.xaml-to add new line to the system
    /// </summary>
    public partial class AddLineWindow : Window
    {
        IBL blObject;
        /// <summary>
        /// ctor
        /// </summary>
        public AddLineWindow()
        {
            InitializeComponent();
            blObject = BLFactory.GetBL("1");
            cbArea.ItemsSource = Enum.GetValues(typeof(Area));
            cbfirst.ItemsSource = cblast.ItemsSource = blObject.GetAllStation();

        }

        #region events
        /// <summary>
        /// event when the user press on the add buttom-his first try to add the new line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            catch (BadConsecutiveStationsKeysException)//it we have no details about the time and distance between the 2 stations of the new line
            {

                tbNum.Visibility = Visibility.Hidden;
                tbTime.Visibility = Visibility.Visible;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///event when the user press on the add buttom2- the second try of the user to add the line-when we got details about the time and distance between the 2 stations of the new line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion
    }
}
