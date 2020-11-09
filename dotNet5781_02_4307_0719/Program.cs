using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class Program
    {
        static void Main(string[] args)
        {
            BusLines listOfLines = new BusLines();
            CHOICE choice;
            bool success;
            string input;

            do
            {
                do              // to check the input
                {
                    Console.WriteLine("pick your choice:Add (line or station)=0, DELETE(line or station)=1, FIND(lines or Travel options)=3, PRINT=4, EXIT = -1");
                    input = Console.ReadLine();          //The user chooses
                    success = Enum.TryParse(input, out choice);
                    if (!success)                                //If the selection is incorrect
                    {
                        Console.WriteLine("Try again");
                    }
                }
                while (success == false);

                switch (choice)
                {
                    case CHOICE.ADD:
                        Console.WriteLine("enter 0 to add new line, 1 to add new station:");
                        string lineOrStation = Console.ReadLine();
                        Console.WriteLine("enter the number of the line");
                        string lineNumber = Console.ReadLine();
                        try
                        {
                            if (lineOrStation == "0")
                            {
                                listOfLines.AddOrRemove(lineNumber);
                            }
                            else if (lineOrStation == "1")
                            {
                                Console.WriteLine("enter the number of the fisrt station");
                                string first = Console.ReadLine();
                                listOfLines[lineNumber, first].AddOrRemove(1, listOfLines);
                            }
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (ArgumentException ex)
                        {                           
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case CHOICE.DELETE:
                        break;
                    case CHOICE.FIND:
                        break;
                    case CHOICE.PRINT:
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
