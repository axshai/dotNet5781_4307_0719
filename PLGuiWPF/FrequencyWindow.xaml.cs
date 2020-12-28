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
using BLApi;
namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for FrequencyWindow.xaml
    /// </summary>
    public partial class FrequencyWindow : Window
    {
        BusLineScheduleBO current;
        public FrequencyWindow(BusLineScheduleBO schedule)
        {
            InitializeComponent();
            current = schedule;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            IBL b1 = BLFactory.GetBL("1");
            uint toNum;
            if (!uint.TryParse(tbFreq.Text, out toNum))
            {
                MessageBox.Show("Enter digits only!");
                tbFreq.Text = "";
            }
            else
            {
                try
                {
                    b1.UpdateSchedule(current, int.Parse(tbFreq.Text));
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A bus does not leave the station more than once a minute!");
                    tbFreq.Text = "";
                }
            }
        }
    }
}
