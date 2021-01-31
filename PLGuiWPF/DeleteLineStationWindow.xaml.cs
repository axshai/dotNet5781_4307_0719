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
    /// Interaction logic for DeleteLineStationWindow.xaml-for update time and distance after delete station from line rout
    /// (As a result of deleting a station — there are two stations that have now become consecutive stations)
    /// </summary>
    public partial class DeleteLineStationWindow : Window
    {
        BusLineStationBO current;
        BusLineBO currentLine;
        IBL bl;
       /// <summary>
       /// ctor
       /// </summary>
       /// <param name="station">the station to delete</param>
       /// <param name="line">The line from which you want to remove the station</param>
        public DeleteLineStationWindow(BusLineStationBO station,BusLineBO line)
        {
            InitializeComponent();
            bl = BLFactory.GetBL("1");
            current = station;
            currentLine = line;
            tbheader.Text = line.StationList.ToList()[line.StationList.ToList().IndexOf(station) + 1].StationKey.ToString();//the station to update time and distance from the privous-one after the deleted station
        }
        /// <summary>
        /// press on delete button-after that he enter time and distance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            //Check input correctness:
            TimeSpan validTime;
            double validDist;
            if (!TimeSpan.TryParse(tbtime.Text, out validTime) || !double.TryParse(tbdist.Text, out validDist))
            {
                MessageBox.Show("Please enter time and distance in the correct format!");
                tbtime.Text = tbdist.Text = "";
                return;
            }
           //delete the station from the line rout
            bl.DeleteLineStation(currentLine, current.StationKey, double.Parse(tbdist.Text), TimeSpan.Parse(tbtime.Text) );
            this.Close();
        }
    }
}
