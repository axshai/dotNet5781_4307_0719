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
    /// Interaction logic for ShowLinesWindow.xaml
    /// </summary>
    public partial class ShowLinesWindow : Window
    {
        IBL blObject;
        List<BusLineBO> lines;
        public ShowLinesWindow()
        {
            InitializeComponent();
            blObject = BLFactory.GetBL("1");
            lines = blObject.GetAllLines().ToList();
            dgLines.ItemsSource = lines;
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            //BusLineBO line = dgLines.SelectedItem as BusLineBO;
            //blObject.Deleteline(line.Id);
        }


        private void dgLines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BusLineBO line = dgLines.SelectedItem as BusLineBO;
            ShowLineDetails ws1 = new ShowLineDetails(line);
            ws1.Show();
            dgLines.ItemsSource = blObject.GetAllLines().ToList();
        }
    }
}
