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
using System.Collections.ObjectModel;
using System.Threading;
using System.ComponentModel;


namespace dotNet5781_03B_4307_0791
{

    /// <sumary>
    /// Interaction logic for showbus.xaml
    /// </summary>
    public partial class showbus : Window
    {

        BackgroundWorker caring;
        BackgroundWorker refuling;
        List<Bus> busshow = new List<Bus>();
        Bus b1;
        public showbus(Bus myshowbus)
        {
            b1 = myshowbus;
            InitializeComponent();
            busshow.Add(b1);
            lbbuseshow.ItemsSource = busshow;
            caring = new BackgroundWorker();
            refuling = new BackgroundWorker();
            refuling.DoWork += Refuling_DoWork;
            refuling.RunWorkerCompleted += Refuling_RunWorkerCompleted;
            caring.DoWork += Caring_DoWork;
            caring.RunWorkerCompleted += Caring_RunWorkerCompleted;
        }

        private void Refuling_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            b1.State = STATUS.READY;
        }

        private void Refuling_DoWork(object sender, DoWorkEventArgs e)
        {
            b1.State = STATUS.INREFUEL;

            Thread.Sleep(12000);
            b1.DoRefuel();
        }

        private void Caring_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            b1.State = STATUS.READY;
        }

        private void Caring_DoWork(object sender, DoWorkEventArgs e)
        {

            b1.State = STATUS.INCARE;

            Thread.Sleep(144000);
            b1.DoHandle();

        }

        private void Refuelbutton_Click(object sender, RoutedEventArgs e)
        {

            if (!b1.IsReady)
                MessageBox.Show("can not make refuel now,please wait");
            else
                refuling.RunWorkerAsync();

        }


        private void maintenanceButton_Click(object sender, RoutedEventArgs e)
        {
            if (!b1.IsReady)
                MessageBox.Show("can not make maintenance now,please wait");
            else
                caring.RunWorkerAsync();
        }
    }
}