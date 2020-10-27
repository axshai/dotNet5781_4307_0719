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
                do              //// to check the Kelet
                {
                    Console.WriteLine("pick your choice: ADD,DRIVE,REFUELORCHECKUP,SHOW,EXIT = -1");
                    string kelet = Console.ReadLine();          //The user chooses
                    success = Enum.TryParse(kelet, out choice);
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
                        DateTime onRoad;           //to the date of adding the bus
                        Console.WriteLine("Please enter a license number and start date of activity");

                        licenseNumber = Console.ReadLine();

                        success = DateTime.TryParse(Console.ReadLine(), out onRoad); //We will use the TryParse  represent the date
                        if (success)         //If the date conversion was successful
                        {
                            try    //In case the license number is incorrect
                            {
                                Bus bus = new Bus(onRoad, licenseNumber); //We will create a new "bus"
                                buses.Add(bus);                             //We'll add the "bus" to the list

                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);//print "The license number is invalid"
                            }
                        }
                        else //If the date conversion was not successful
                        {
                            while (!success)
                            {
                                Console.WriteLine("try again");
                                success = DateTime.TryParse(Console.ReadLine(), out onRoad); //We will use the TryParse  represent the date
                            }
                            try    //In case the license number is incorrect
                            {
                                Bus bus = new Bus(onRoad, licenseNumber); //We will create a new "bus"
                                buses.Add(bus);                             //We'll add the "bus" to the list

                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);//print "The license number is invalid"
                            }
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
                                int kmToDrive = r.Next(1400);
                                try                          //If travel is not possible
                                {
                                    bus.Drive(kmToDrive);
                                   
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine(exception.Message);//print "It is not possible to make the trip"
                                }
                            }
                        }
                        if(!flage)           //The bus is not on the list
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
                                int choose;
                                int.TryParse(Console.ReadLine(), out choose);
                                while(choose!=1&& choose != 2)      //If the choice is not 1 and not 2
                                {
                                    Console.WriteLine("Try again");
                                    int.TryParse(Console.ReadLine(), out choose);
                                }
                                if (choose == 1)     //To fuel
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
                    case CHOICE.SHOW:     //Print the bus facts
                        foreach (Bus bus in buses)  //using "foreach" to print t
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


