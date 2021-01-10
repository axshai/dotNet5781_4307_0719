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
    /// Interaction logic for LineArrivalTimes.xaml-Shows arrival times of a particular line to a particular station
    /// </summary>
    public partial class LineArrivalTimesWindow : Window
    {
        public LineArrivalTimesWindow(LineInStationBO line)
        {
            InitializeComponent();
            DataContext = line;
        }
    }
}
