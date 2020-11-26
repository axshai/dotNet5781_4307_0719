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

namespace dotNet5781_03B_4307_0791
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class drivewindow : Window
    {
        Bus toDrive;

        public drivewindow(Bus b1)
        {
            toDrive = b1;
            InitializeComponent();
        }

        private void drivethebus_Click(object sender, RoutedEventArgs e)
        {
            string distance = tbdistance.Text;
            toDrive.Drive(int.Parse(distance));
            this.Close();

        }

    }
}