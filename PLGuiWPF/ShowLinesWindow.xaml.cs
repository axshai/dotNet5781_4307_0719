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
    /// Interaction logic for ShowLinesWindow.xaml-show all lines in system
    /// </summary>
    public partial class ShowLinesWindow : Window
    {
        IBL blObject;
        Button prev;
        /// <summary>
        /// CTOR
        /// </summary>
        public ShowLinesWindow(Button b)
        {
            InitializeComponent();
            blObject = BLFactory.GetBL("1");
            dgLines.ItemsSource = blObject.GetAllLines();
            prev = b;
        }

        #region events
        /// <summary>
        /// Clicking the delete Line button-to delete a line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            BusLineBO line = dgLines.SelectedItem as BusLineBO;
            blObject.DeleteLine(line.Id);
            dgLines.ItemsSource = blObject.GetAllLinesBy(line1 => line1.LineNumber.StartsWith(tbsearch.Text)).ToList();
        }

        /// <summary>
        /// Clicking on specific line/row in the datagrid-to see the line deatails
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgLines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgLines.SelectedItem == null)
                return;
            BusLineBO line = dgLines.SelectedItem as BusLineBO;
            ShowLineDetails ws1 = new ShowLineDetails(line);
            ws1.ShowDialog();
            dgLines.ItemsSource = blObject.GetAllLinesBy(line1 => line1.LineNumber.StartsWith(tbsearch.Text)).ToList();
        }

        /// <summary>
        ///  Clicking the add Line button-to add new line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddLineWindow wnd = new AddLineWindow();
            wnd.ShowDialog();
            dgLines.ItemsSource = blObject.GetAllLinesBy(line1 => line1.LineNumber.StartsWith(tbsearch.Text)).ToList();
        }

        /// <summary>
        /// text box TextChanged-when searchimg after line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgLines.ItemsSource = blObject.GetAllLinesBy(line1 => line1.LineNumber.StartsWith(tbsearch.Text)).ToList();
        }
       

        /// <summary>
        /// Window_Closing eevent-when the window closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            prev.IsEnabled = true;//Allow clicking on the button you came from(in the previous window)
        }
        #endregion
    }
}
