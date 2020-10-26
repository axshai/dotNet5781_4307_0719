using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                    Console.WriteLine("pick your choice:ADD, DRIVE, REFUEL OR CHECKUP, SHOW, EXIT=-1 ");
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
                    case CHOICE.DRIVE:
                        Console.WriteLine("please enter license number:");
                        licenseNumber = Console.ReadLine();
                        bool flag = false;
                        foreach (Bus bus in buses)
                        {
                            if (bus.License == licenseNumber)///*
                            {
                                flag = true;
                                Random r = new Random(DateTime.Now.Millisecond);
                                int kmToDrive = r.Next(1500);
                                Console.WriteLine(kmToDrive);
                                try
                                {
                                    bus.drive(kmToDrive);
                                    break;
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine(exception.Message);
                                    break;
                                }
                            }
                        }
                        if (!flag)
                            Console.WriteLine("The bus is not found");
                        break;

                    case CHOICE.REFUELORCHECKUP:

                        Console.WriteLine("please enter license number:");
                        licenseNumber = Console.ReadLine();
                        flag = false;
                        foreach (Bus bus in buses)
                        {
                            if (bus.License == licenseNumber)///*
                            {
                                flag = true;
                                Console.WriteLine("Enter 1 for refueling and 2 for handling");
                                int choose;
                                int.TryParse(Console.ReadLine(), out choose);
                                if (choose == 1)
                                {
                                    bus.doRefuel();

                                }
                                else if (choose == 2)
                                {
                                    bus.doHandle();

                                }
                                break;
                            }
                        }
                        if (!flag)
                            Console.WriteLine("The bus is not found");
                        break;
                    case CHOICE.SHOW:
                        foreach (Bus bus in buses)
                        {
                           Console.WriteLine(bus.ShowDetails());
                        }
                        break;
                    default:
                        break;
                }

            } while (choice != CHOICE.EXIT);

        }
    }
}


