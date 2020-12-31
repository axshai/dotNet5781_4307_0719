using BLApi;
using BO;
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

namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for ShowStationWindow.xaml
    /// </summary>
    public partial class ShowStationWindow : Window
    {

        IBL blObject;
        List<BusStationBO> stations;
        public ShowStationWindow()
        {
            InitializeComponent();
            blObject = BLFactory.GetBL("1");
            stations = blObject.GetAllStation().ToList();
            dgStations.ItemsSource = stations;

        }

        private void dgStations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BusStationBO Station = dgStations.SelectedItem as BusStationBO;
            ShowStationDetails show = new ShowStationDetails(Station);



        }
    }
}
