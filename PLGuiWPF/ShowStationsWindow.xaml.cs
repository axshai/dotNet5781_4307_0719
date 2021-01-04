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
    public partial class ShowStationsWindow : Window
    {

        IBL blObject;
       
        public ShowStationsWindow()
        {
            InitializeComponent();
            blObject = BLFactory.GetBL("1");
            dgStations.ItemsSource = blObject.GetAllStation();
           

        }

        private void dgStations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowStationDetails w1 = new ShowStationDetails(dgStations.SelectedItem as BusStationBO);
            w1.ShowDialog();
           // dgStations.ItemsSource = blObject.GetAllStation();



        }

       
    }
}
