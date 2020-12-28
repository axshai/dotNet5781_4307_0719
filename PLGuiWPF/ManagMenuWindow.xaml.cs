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
using System.Collections.ObjectModel;
namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for ManagMenuWindow.xaml
    /// </summary>
    public partial class ManagMenuWindow : Window
    {           
        IBL myBL = BLFactory.GetBL("BLImp");
        ObservableCollection<BusLineBO> lines;//list of all lines
        
        public ManagMenuWindow()
        { 
            InitializeComponent();
            lines = new ObservableCollection<BusLineBO>(myBL.GetAllLines());
            lbLines.ItemsSource = lines;
            lbLines.Visibility = Visibility.Collapsed;
            closeButton.Visibility = Visibility.Collapsed;


        }

        private void Buttonshowline_Click(object sender, RoutedEventArgs e)
        {
            (new ShowLinesWindow()).Show();

            lbLines.Visibility = Visibility.Visible;
            closeButton.Visibility = Visibility.Visible;
        }

        private void Buttoncloseline_Click(object sender, RoutedEventArgs e)
        {
            lbLines.Visibility = Visibility.Collapsed;
            closeButton.Visibility = Visibility.Collapsed;

        }

        private void ButtonshowStation_Click(object sender, RoutedEventArgs e)
        {
            ShowStationWindow ShowStation = new ShowStationWindow();
            ShowStation.Show();
        }
    }
}
