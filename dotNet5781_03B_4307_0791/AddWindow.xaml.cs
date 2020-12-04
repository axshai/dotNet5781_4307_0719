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
        private ObservableCollection<Bus> listOfBuses;//list of all lines
        public AddWindow(ObservableCollection <Bus> Buses)
        {
            InitializeComponent();
            listOfBuses = Buses;
        }

        private void AddBusButton_Click(object sender, RoutedEventArgs e)//Click on the buttom to add a bus
        {
            try
            {
                addBus();
            }
            catch (DuplicateWaitObjectException ex)//Exception that can occur
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            finally
            {
                this.Close();
            }
        }

        private void addBus()//add the bus
        {
            DateTime startActiv;
            bool validDate = DateTime.TryParse(tbDate.Text, out startActiv);//Checking the correctness of the date
            if (!validDate)
                throw new FormatException("Invalid date!");
            
            string license1, license = tbLicense.Text;//Convert the input string to a license number
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
           
            foreach (Bus bus in listOfBuses)//Check that there is no such bus in the list
                if (bus.License == license1)
                    throw new DuplicateWaitObjectException ("There is already a bus with the same license number!");//*
            
            listOfBuses.Add(new Bus(DateTime.Parse(tbDate.Text), license));//add the new bus
            
        }

        
    }
}
