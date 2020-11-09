using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class Program
    {
        static void Add(BusLines listOfLines, string lineOrStation, string lineNumber, string first)
        {
            if (lineOrStation == "0")
            {
                listOfLines.AddOrRemove(lineNumber);
            }
            else if (lineOrStation == "1")
            {

                first = Console.ReadLine();
                listOfLines[lineNumber, first].AddOrRemove(1, listOfLines);
            }

        }




        static void Main(string[] args)
        {
            BusLines listOfLines = new BusLines();
            CHOICE choice;
            bool success;
            string input;
            string input1;
            string lineOrStation;
            string first;
            string lineNumber;
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
                        lineOrStation = Console.ReadLine();
                        Console.WriteLine("enter the number of the line");
                        lineNumber = Console.ReadLine();
                        first = "";
                        if (lineNumber == "1")
                        {
                            Console.WriteLine("enter the number of the fisrt station");
                            first = Console.ReadLine();
                        }
                        try
                        {
                            Add(listOfLines, lineOrStation, lineNumber, first);
                        }

                        catch (FormatException ex)
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
                        Console.WriteLine("enter 0 to delete line, 1 to delete station:");
                        lineOrStation = Console.ReadLine();
                        Console.WriteLine("enter the number of the line");
                        lineNumber = Console.ReadLine();
                        Console.WriteLine("enter the number of the fisrt station");
                        first = Console.ReadLine();
                        try
                        {
                            if (lineOrStation == "0")
                            {
                                listOfLines.AddOrRemove(lineNumber, first);
                            }
                            else if (lineOrStation == "1")
                            {
                                listOfLines[lineNumber, first].AddOrRemove(0, listOfLines);
                            }
                        }

                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case CHOICE.FIND:
                        Console.WriteLine(@"Enter 0 to Look for a line passing through the station    
                          or 1 to   Printing the options for travel between 2 stations");
                        input1 = Console.ReadLine();
                        if (input1 == "0")
                        {
                            Console.WriteLine("Enter the number of station");
                            input = Console.ReadLine();
                            foreach (BusLineRoute line in listOfLines)
                            {
                                if (line.CheckStation(input))
                                {
                                    Console.WriteLine(line);
                                }


                            }
                        }
                        else if (input1 == "1")
                        {
                            Console.WriteLine("Enter the station numbers");
                            input = Console.ReadLine();
                            input1 = Console.ReadLine();
                            List<BusLineRoute> subLines = new List<BusLineRoute>();
                            foreach (BusLineRoute line in listOfLines)
                            {
                                try
                                {
                                    subLines.Add(line.subLine(input, input1));
                                }
                                catch (ArgumentException)
                                {

                                }
                            }
                            BusLines sublinesSort = new BusLines();
                            sublinesSort.Lines = subLines;
                            Console.WriteLine(sublinesSort.SortedList());
                        }
                        break;
                    case CHOICE.PRINT:
                        List<BusLineStation> Allstations = new List<BusLineStation>();
                        foreach (BusLineRoute line in listOfLines)
                        {
                            foreach (BusLineStation station1 in line.Stations)
                            {
                                if (!Allstations.Contains(station1)) 
                                {

                                    foreach (BusLineRoute line1 in listOfLines)
                                    {
                                        if (line1.CheckStation(station1.BusStationKey))
                                        {
                                            Console.WriteLine(line1);
                                        }
                                    }
                                    Allstations.Add(station1);
                                }
                            }

                        }


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