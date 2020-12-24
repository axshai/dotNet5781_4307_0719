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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ShowLineDetails : Window
    {
        BusLineBO showedLine;
        public ShowLineDetails(BusLineBO currentLine)
        {
            InitializeComponent();
            showedLine = currentLine;
            dgSchedule.ItemsSource = currentLine.ScheduleList;
            dgStations.ItemsSource = currentLine.StationList;

        }
    }
}
