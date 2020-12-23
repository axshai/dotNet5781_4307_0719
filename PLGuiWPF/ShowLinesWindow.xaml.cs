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
    /// Interaction logic for ShowLinesWindow.xaml
    /// </summary>
    public partial class ShowLinesWindow : Window
    {
        ObservableCollection<BusLineBO> lines;//list of all lines
        BusLineBO currentDisplayBusLine;
        IBL myBL = BLFactory.GetBL("1");
        public ShowLinesWindow()
        {
            InitializeComponent();
            lines = new ObservableCollection<BusLineBO>(myBL.GetAllLines());
            cbLines.ItemsSource = lines;
           
        }

        private void lbLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbLines.SelectedValue as BusLineBO).LineNumber);
        }

        private void ShowBusLine(string index)
        {
            currentDisplayBusLine = lines.First();
            
            lbLines.DataContext = currentDisplayBusLine.Stations;//show the stations of the selcted line
            tbArea.Text = currentDisplayBusLine.Region.ToString();//shoe the area of the selcted line
        }
    }
}
