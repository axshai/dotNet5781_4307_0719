using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_4307_0719
{

    class Program
    {
        //  static List<Bus> buses = new List<Bus>();
        static void Main(string[] args)
        {
            List<Bus> buses = new List<Bus>();

            CHOICE choice;
            bool success;

            do
            {
                do
                {
                    Console.WriteLine(" pick your choice:ADD, FIND, REFUEL, CHECKUP,  EXIT=-1 ");
                    string kelet = Console.ReadLine();
                    success = Enum.TryParse(kelet, out choice);
                    if (!success)
                    {
                        Console.WriteLine("Try again");
                    }
                }
                while (success == false);
                
                switch (choice)
                {
                    case CHOICE.ADD:
                        string licenseNumber;
                        DateTime onRoad;
                        Console.WriteLine("Please enter a license number and start date of activity");
                       
                        licenseNumber = Console.ReadLine();
                        
                        success = DateTime.TryParse(Console.ReadLine(), out onRoad);
                        if (success)
                        {
                            try
                            {
                                Bus bus = new Bus(onRoad, licenseNumber);
                                buses.Add(bus);
                               
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                        break;
                    case CHOICE.FIND:
                        break;
                    case CHOICE.REFUEL:
                        break;
                    case CHOICE.CHECKUP:
                        break;
                    case CHOICE.EXIT:
                        break;
                    default:
                        break;
                }

            } while (choice != CHOICE.EXIT);

        }
    }
}
    

