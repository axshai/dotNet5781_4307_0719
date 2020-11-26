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
using System.Text.RegularExpressions;
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

        private void tbdistance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string distance = tbdistance.Text;
                toDrive.Drive(int.Parse(distance));
                this.Close();
            }
           
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}