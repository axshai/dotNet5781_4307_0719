using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotNet5781_01_4307_0719
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Bus> buses = new List<Bus>();
            CHOICE choice;
            bool success;

            do
            {
                do              // to check the input
                {
                    Console.WriteLine("pick your choice: ADD=0 ,DRIVE=1 ,REFUELORCHECKUP=2 ,SHOW=3 ,EXIT = -1");
                    string input = Console.ReadLine();          //The user chooses
                    success = Enum.TryParse(input, out choice);
                    if (!success)                                //If the selection is incorrect
                    {
                        Console.WriteLine("Try again");
                    }
                }
                while (success == false);

                switch (choice)
                {
                    case CHOICE.ADD:               //Adding a bus to the list
                        string licenseNumber;
                        DateTime onRoad;           //to the date of beginning of bus use
                        Console.WriteLine("Please enter a license number and start date of activity");

                        licenseNumber = Console.ReadLine();
                        do
                        {
                            success = DateTime.TryParse(Console.ReadLine(), out onRoad); //We will use the TryParse  Convert the date
                            if (!success)
                                Console.WriteLine("enter date again");
                        }
                        while (!success);

                        try
                        {
                            Bus bus = new Bus(onRoad, licenseNumber); //We will create a new "bus"
                            buses.Add(bus);                             //We'll add the "bus" to the list

                        }
                        catch (Exception exception)//In case the license number is incorrect
                        {
                            Console.WriteLine(exception.Message);//print "The license number is invalid"
                        }

                        break;

                    case CHOICE.DRIVE:   //Choosing a bus for travel
                        Console.WriteLine("please enter license number:");
                        licenseNumber = Console.ReadLine();        //Licensing number
                        bool flage = false;                        //Check if the bus exists      
                        foreach (Bus bus in buses)                 //using "foreach" to Check if the bus is on the list
                        {
                            if (bus.License == licenseNumber)       //If the bus exists
                            {
                                flage = true;
                                Random r = new Random(DateTime.Now.Millisecond);
                                int kmToDrive = r.Next(1500);
                                try
                                {
                                    bus.Drive(kmToDrive);
                                }
                                catch (Exception exception) //If travel is not possible
                                {
                                    Console.WriteLine(exception.Message);//print "It is not possible to make the trip"
                                }
                            }
                        }
                        if (!flage)           //The bus is not on the list
                            Console.WriteLine("The bus is not found");

                        break;

                    case CHOICE.REFUELORCHECKUP:        //Refuel or take care of the bus

                        Console.WriteLine("please enter license number:");
                        licenseNumber = Console.ReadLine();
                        flage = false;                 //Check if the bus is on the list
                        foreach (Bus bus in buses)      ////using "foreach" to Check if the bus is on the list
                        {
                            if (bus.License == licenseNumber) //The bus exists
                            {
                                flage = true;
                                Console.WriteLine("Enter 1 for refueling and 2 for handling");
                                int choose = 0;
                                do  //Input and check the validity of the input
                                {
                                    int.TryParse(Console.ReadLine(), out choose);
                                    if (choose != 1 && choose != 2)
                                        Console.WriteLine("Only 1 or 2 can be entered");
                                }
                                while (choose != 1 && choose != 2);
                                
                                if (choose == 1)    //To fuel
                                {
                                    bus.doRefuel();

                                }
                                else if (choose == 2) //handle
                                {

                                    bus.doHandle();
                                }
                            }

                        }
                        if (!flage) //In case the bus is not found
                        {
                            Console.WriteLine("The bus is not found");
                        }

                        break;

                    case CHOICE.SHOW:     //Print mileage since treatment
                        foreach (Bus bus in buses)  //using "foreach" to print for all the buses
                        {
                            bus.Show();
                        }

                        break;

                    case CHOICE.EXIT: //To Exit
                        break;

                    default:
                        break;
                }
            } while (choice != CHOICE.EXIT);
        }
    }
}


