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
using System.Threading;
using System.ComponentModel;
namespace dotNet5781_03B_4307_0791
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class drivewindow : Window
    {
        BackgroundWorker driving;
        Bus toDrive;
        object driveBut;
        public drivewindow(object sender, Bus b1)
        {
            InitializeComponent();
            toDrive = b1;
            driveBut = sender;
            driving = new BackgroundWorker();
            driving.DoWork += Driving_DoWork;
            driving.RunWorkerCompleted += Driving_RunWorkerCompleted;
        }

        private void Driving_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toDrive.State = STATUS.READY;
            (driveBut as Button).IsEnabled = true;
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);
        }

        private void tbdistance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string distance = tbdistance.Text;

                (driveBut as Button).IsEnabled = false;
                driving.RunWorkerAsync(distance);
                this.Close();

            }
        }

        private void Driving_DoWork(object sender, DoWorkEventArgs e)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int speed = r.Next(20, 50);
            string dista = (string)e.Argument;
            int dista2 = int.Parse(dista);
            toDrive.State = STATUS.INDRIVE;
            toDrive.Drive(dista2);
            Thread.Sleep(1000*(dista2/speed));
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}