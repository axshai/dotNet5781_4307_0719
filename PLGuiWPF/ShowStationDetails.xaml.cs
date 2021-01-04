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
    /// Interaction logic for ShowStationDetails.xaml
    /// </summary>
    public partial class ShowStationDetails : Window
    {
        IBL bl;

        public ShowStationDetails(BusStationBO stationShow)
        {
           
            InitializeComponent();
            bl = BLFactory.GetBL("1");
           
             this.DataContext = stationShow;
           
            

        }

        private void editTimeDist_Click(object sender, RoutedEventArgs e)
        {
            ConsecutiveStationBO b1=(sender as Button).DataContext as ConsecutiveStationBO;
            EditTimeAndDistWindow wnd = new EditTimeAndDistWindow(b1);
            wnd.ShowDialog();
            this.DataContext = bl.GetBusStation((this.DataContext as BusStationBO).StationKey);
        }

        private void dgLines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LineArrivalTimesWindow wnd1 = new LineArrivalTimesWindow(dgLines.SelectedItem as LineInStationBO);
            wnd1.ShowDialog();
        }
    }
}
