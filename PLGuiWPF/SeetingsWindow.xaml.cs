using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SeetingsWindow.xaml
    /// </summary>
    public partial class SeetingsWindow : Window
    {
        Button prev;
        public SeetingsWindow(Button b)
        {
            InitializeComponent();
            prev = b;
        }

        private void simulatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (tbspeed.IsEnabled)
                tbspeed.IsEnabled = false;
            else
                tbspeed.IsEnabled = true; ;
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            prev.IsEnabled = true;
        }

        private void tbspeed_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}