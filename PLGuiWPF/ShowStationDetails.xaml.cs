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
namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for ShowStationDetails.xaml
    /// </summary>
    public partial class ShowStationDetails : Window
    {
        BusStationBO displaydStation;

        public ShowStationDetails(BusStationBO stationShow)
        {
           
            InitializeComponent();

            displaydStation = stationShow;
             this.DataContext = displaydStation;
           
            

        }

        private void editTimeDist_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
