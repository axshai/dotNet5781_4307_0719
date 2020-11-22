using dotNet5781_02_4307_0719;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace dotNet5781_03A_4307_0791
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Random r = new Random(DateTime.Now.Millisecond);//Random number for station longitude and latitude lines (and area for lines)

            for (int i = 1; i <= 10; i++)//First loop to boot 10 lines
            {
                //Creating two new stations for the current line, we will initialize random longitude and latitude lines depending on the range
                BusStation first = new BusStation(i.ToString() + 3, 33.3 - r.NextDouble() * 2.3, 35.5 - r.NextDouble() * 1.2);
                BusStation last = new BusStation(i.ToString() + 4, 33.3 - r.NextDouble() * 2.3, 35.5 - r.NextDouble() * 1.2);
                //We will add the line to our list of lines (Currently, each line has 2 stations)
                listOfLines.AddOrRemove(i.ToString(), area: r.Next(7).ToString(), fstation: first, lstation: last);
                string x = i.ToString() + 3; //We will save the station number for the current line
                for (int j = 2; j >= 1; j--)//We will add two more stations for the current line
                {
                    listOfLines[i.ToString(), x].FirstStation = new BusLineStation(new BusStation(i.ToString() + j, 33.3 - r.NextDouble() * 2.3, 35.5 - r.NextDouble() * 1.2));

                    x = i.ToString() + j.ToString(); //We will save the station code to the first new station
                }
                //Currently, there are 10 lines and each line has 4 stations
            }
            
            for (int i = 1; i <= 9; i++)//A loop that will take care of adding to each line a station that already exists (and so there will be 9 stations that will go through at least 2 lines)
            {
                listOfLines[i.ToString(), i.ToString() + 1].FirstStation = listOfLines[(i + 1).ToString(), (i + 1).ToString() + 1].FirstStation;
            }
            //Adding an existing station where at least 2 lines will pass
            listOfLines["10", "101"].FirstStation = listOfLines["1", "21"].Stations[1];

            InitializeComponent();
            cbBusLines.ItemsSource = listOfLines;//combo-box
            cbBusLines.DisplayMemberPath = "BusLine";//choose by the line-number
            cbBusLines.SelectedIndex = 0;
           
        }

        BusLines listOfLines= new BusLines();//Create a collection of lines

        private BusLineRoute currentDisplayBusLine; //The selected line to display

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)//event of new selection in combobox
        {
            ShowBusLine((cbBusLines.SelectedValue as BusLineRoute).BusLine, (cbBusLines.SelectedValue as BusLineRoute).FirstStation.BusStationKey);//show the stations of the selected line
        }
        
        private void ShowBusLine(string index, string firstStation)
        {
            currentDisplayBusLine = listOfLines[index, firstStation];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.Stations;//show the stations of the selcted line
            tbArea.Text = currentDisplayBusLine.Region.ToString();//shoe the area of the selcted line
        }

        
    }


}
