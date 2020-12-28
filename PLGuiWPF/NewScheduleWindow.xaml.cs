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
    /// Interaction logic for NewScheduleWindow.xaml
    /// </summary>
    public partial class NewScheduleWindow : Window
    {
        public NewScheduleWindow()
        {
            InitializeComponent();
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
            string start = tbStart.Text;
            string end = tbStart.Text;
            string freq = tbFreq.Text;
            
        }
    }
}
