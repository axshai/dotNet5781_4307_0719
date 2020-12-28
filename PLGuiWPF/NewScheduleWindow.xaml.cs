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
using BLApi;
using BO;
namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for NewScheduleWindow.xaml
    /// </summary>
    public partial class NewScheduleWindow : Window
    {
        IBL b1;
        BusLineBO currentLine;
        public NewScheduleWindow(BusLineBO line)
        {
            InitializeComponent();
            b1 = BLFactory.GetBL("1");
            currentLine = line;
        }

        private void tbStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)//if he  Press enter
            {
                addSched();

            }
        }

        private void tbEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)//if he  Press enter
            {
                addSched();

            }
        }

        private void tbFreq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)//if he  Press enter
            {
                addSched();

            }
        }

        private void addSched()
        {
            uint toNum;
            TimeSpan toTime;
            if (!TimeSpan.TryParse(tbStart.Text, out toTime) || !TimeSpan.TryParse(tbEnd.Text, out toTime))
            {
                MessageBox.Show("Please enter times in the correct format!!(00:00:00)");
               
            }
            else if (!uint.TryParse(tbFreq.Text, out toNum))
            {
                MessageBox.Show("Enter digits only!");
                tbStart.Text = tbEnd.Text = tbFreq.Text = "";
            }
            else
            {
                try
                {
                    b1.AddSchedule(currentLine.Id, TimeSpan.Parse(tbStart.Text), TimeSpan.Parse(tbEnd.Text), int.Parse(tbFreq.Text));
                    this.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    tbStart.Text = tbEnd.Text = tbFreq.Text = "";
                }
            }





        }
    }
}
