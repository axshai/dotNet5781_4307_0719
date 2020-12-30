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
    /// Interaction logic for DeleteLineStationWindow.xaml
    /// </summary>
    public partial class DeleteLineStationWindow : Window
    {
        BusLineStationBO current;
        BusLineBO currentLine;
        IBL bl;
        public DeleteLineStationWindow(BusLineStationBO station,BusLineBO line)
        {
            InitializeComponent();
            bl = BLFactory.GetBL("1");
            current = station;
            currentLine = line;
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan validTime;
            double validDist;
            if (!TimeSpan.TryParse(tbtime.Text, out validTime) || !double.TryParse(tbdist.Text, out validDist))
            {
                MessageBox.Show("Please enter time and distance in the correct format!");
                tbtime.Text = tbdist.Text = "";
                return;
            }
            bl.DeleteLineStation(currentLine, current.StationKey, double.Parse(tbdist.Text), TimeSpan.Parse(tbtime.Text) );
            this.Close();
        }
    }
}
