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

namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for SeetingsWindow.xaml
    /// </summary>
    public partial class SeetingsWindow : Window
    {
        TimeSpan StartTime;
        public SeetingsWindow()
        {
            StartTime = TimeSpan.Zero;
            InitializeComponent();
        }

        private void simulatorButton_Click(object sender, RoutedEventArgs e)
        {
            
            tbspeed.IsEnabled =false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }
    }
}