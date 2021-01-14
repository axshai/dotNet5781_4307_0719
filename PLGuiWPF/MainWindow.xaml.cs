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
        BLApi.IBL mybl = BLApi.BLFactory.GetBL("BLImp");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void managButton_Click(object sender, RoutedEventArgs e)
        {

            ManagMenuWindow managWindow1 = new ManagMenuWindow();
            managWindow1.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            //(sender as MediaElement).Visibility = Visibility.Hidden;
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            (new SeetingsWindow()).Show();
        }
    }
}