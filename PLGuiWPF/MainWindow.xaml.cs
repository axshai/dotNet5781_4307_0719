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

namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void linesButoon_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            (new ShowLinesWindow(sender as Button)).Show();
        }

        private void stationsButoon_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            ShowStationsWindow ShowStation = new ShowStationsWindow(sender as Button);
            ShowStation.Show();
        }
    }
}