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
using BLApi;
using BO;

namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for EditTimeAndDistWindow.xaml-for change time and/or distance between Consecutive stations
    /// </summary>
    public partial class EditTimeAndDistWindow : Window
    {
        IBL mybl;
        ConsecutiveStationBO currentStation;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="consecutiveStationBO">the stations to edit</param>
        public EditTimeAndDistWindow(BO.ConsecutiveStationBO consecutiveStationBO)
        {
            
            InitializeComponent();
            currentStation = consecutiveStationBO;
            mybl = BLFactory.GetBL("1");
        }
       
        /// <summary>
        /// when the user press on the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            int test;
            double test1;
            //Check input correctness:
            if (!(int.TryParse(tbtime.Text, out test) && double.TryParse(tbdist.Text, out test1) && test > 0 && test1 > 0))
                MessageBox.Show("Please enter time and distance in the correct format!");
            else
            {
                mybl.UpdateConsecutiveStation(currentStation.PrevStationKey, currentStation.StationKey, double.Parse(tbdist.Text), TimeSpan.FromMinutes(test));
                this.Close();
            }
        }
    }
}
