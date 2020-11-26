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
using System.Collections.ObjectModel;

namespace dotNet5781_03B_4307_0791
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private ObservableCollection<Bus> listOfBuses;
        public AddWindow(ObservableCollection <Bus> Buses)
        {
            InitializeComponent();
            listOfBuses = Buses;
        }

        private void AddBusButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addBus();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void addBus()
        {
            DateTime startActiv;
            bool validDate = DateTime.TryParse(tbDate.Text, out startActiv);
            if (!validDate)
                throw new FormatException("Invalid date!");
            string license1, license = tbLicense.Text;
            if (license.Length == 7)
            {
                license1 = license.Insert(2, "-");
                license1 = license1.Insert(6, "-");
            }
            else
            {
                license1 = license.Insert(3, "-");
                license1 = license1.Insert(6, "-");
            }
            foreach (Bus bus in listOfBuses)
                if (bus.License == license1)
                    throw new Exception("There is already a bus with the same license number!");//*
            listOfBuses.Add(new Bus(DateTime.Parse(tbDate.Text), license));
            
        }
    }
}
