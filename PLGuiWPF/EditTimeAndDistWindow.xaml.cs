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
    /// Interaction logic for EditTimeAndDistWindow.xaml
    /// </summary>
    public partial class EditTimeAndDistWindow : Window
    {
        IBL mybl;
        ConsecutiveStationBO currentStation;
        public EditTimeAndDistWindow(BO.ConsecutiveStationBO consecutiveStationBO)
        {
            currentStation = consecutiveStationBO;
            mybl = BLFactory.GetBL("1");
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            int test;
            double test1;
            
            if (!(int.TryParse(tbtime.Text, out test) && double.TryParse(tbdist.Text, out test1) &&test>0&&test1>0))
                MessageBox.Show("Please enter time and distance in the correct format!");
            mybl.UpdateConsecutiveStation(currentStation.PrevStationKey, currentStation.StationKey,double.Parse(tbdist.Text),TimeSpan.FromMinutes(test));
           
        }
    }
}
