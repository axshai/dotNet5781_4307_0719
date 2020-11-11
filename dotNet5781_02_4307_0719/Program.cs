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
        static void Add(BusLines listOfLines, CHOICE lineOrStation, string lineNumber, string first)
        {
            if (lineOrStation == CHOICE.ZERO)
            {
                listOfLines.AddOrRemove(lineNumber);
            }
            else if (lineOrStation == CHOICE.ONE)
            {
                listOfLines[lineNumber, first].AddOrRemove(1, listOfLines);
            }

        }
        static void zeroOrOne(out CHOICE choice)
        {
            string input;
            bool success;
            do              // to check the input
            {
                input = Console.ReadLine();          //The user chooses
                success = Enum.TryParse(input, out choice) && (choice == CHOICE.ZERO || choice == CHOICE.ONE);
                if (!success)
                {
                    Console.WriteLine("only 0 or 1! try again.");
                }
            }
            while (success == false);
        }

       

        static void Main(string[] args)
        {
            BusLines listOfLines = new BusLines();//*
            OPERATION oper;
            CHOICE choice;
            bool success;
            string input;


            do
            {
                do              // to check the input
                {
                    Console.WriteLine("pick your choice:Add (line or station)=0, DELETE(line or station)=1\nFIND(lines or Travel options)=2, PRINT=3, EXIT = -1:");
                    input = Console.ReadLine();          //The user chooses
                    success = OPERATION.TryParse(input, out oper);
                    if (!success)                                //If the selection is incorrect
                    {
                        Console.WriteLine("Try again");
                    }
                }
                while (success == false);

                switch (oper)
                {
                    case OPERATION.ADD:
                        Console.WriteLine("enter 0 to add new line, 1 to add new station:");
                        zeroOrOne(out choice);
                        Console.WriteLine("enter the number of the line");
                        string lineNumber = Console.ReadLine();
                        string first = "";
                        if (choice == CHOICE.ONE)
                        {
                            Console.WriteLine("enter the number of the fisrt station,-1 If there are no stations yet");
                            first = Console.ReadLine();
                        }
                        try
                        {
                            Add(listOfLines, choice, lineNumber, first);
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
                    case OPERATION.DELETE:
                        Console.WriteLine("enter 0 to delete line, 1 to delete station:");
                        zeroOrOne(out choice);
                        Console.WriteLine("enter the number of the line");
                        lineNumber = Console.ReadLine();
                        Console.WriteLine("enter the number of the fisrt station,-1 If there are no stations yet");
                        first = Console.ReadLine();
                        try
                        {
                            if (choice == CHOICE.ZERO)
                            {
                                listOfLines.AddOrRemove(lineNumber, first);
                            }
                            else if (choice == CHOICE.ONE)
                            {
                                listOfLines[lineNumber, first].AddOrRemove(0, listOfLines);
                            }
                        }

                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case OPERATION.FIND:
                        Console.WriteLine("Enter 0 to Look for a line passing through a specific station");
                        Console.WriteLine("or 1 to Printing the options for travel between 2 stations");
                        zeroOrOne(out choice);
                        if (choice == CHOICE.ZERO)
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
                        else if (choice == CHOICE.ONE)
                        {
                            Console.WriteLine("Enter the station numbers");
                            string station1 = Console.ReadLine();
                            string station2 = Console.ReadLine();
                            List<BusLineRoute> subLines = new List<BusLineRoute>();
                            foreach (BusLineRoute line in listOfLines)
                            {
                                try
                                {
                                    line.subLine(station1, station2);
                                    subLines.Add(line);
                                }
                                catch (ArgumentException)
                                {

                                }
                            }
                            BusLines sublinesSort = new BusLines();
                            sublinesSort.Lines = subLines;
                            sublinesSort.SortedList();
                            foreach (BusLineRoute line in sublinesSort)
                            {
                                Console.WriteLine("line:{0,-2} Travel time:{1}", line.BusLine, line.subLine(station1, station2).TotalTime());//הקווים שעוברים בתחנות והזמן בין התחנות!
                            }
                        }
                        break;

                    case OPERATION.PRINT:
                        Console.WriteLine("enter 0 to print Print details of all lines,");
                        Console.WriteLine("1 Print for each station the numbers of the lines passing through it:");
                        zeroOrOne(out choice);
                        if (choice == CHOICE.ZERO)
                            Console.Write(listOfLines);
                        else
                        {
                            List<BusLineStation> allStations = new List<BusLineStation>();
                            foreach (BusLineRoute line in listOfLines)
                            {
                                foreach (BusLineStation station in line.Stations)
                                {
                                    if (!allStations.Exists(station1 => station1.BusStationKey == station.BusStationKey))
                                    {
                                        Console.Write("station number:{0,-6} lines numbers: ", station.BusStationKey);
                                        foreach (BusLineRoute line1 in listOfLines)
                                        {
                                            if (line1.CheckStation(station.BusStationKey))
                                            {
                                                Console.Write(line1.BusLine + " ");
                                            }
                                        }
                                        allStations.Add(station);
                                        Console.WriteLine();
                                    }

                                }
                            }
                        }
                        break;

                    case OPERATION.EXIT:
                        break;
                    default:
                        Console.WriteLine("try again");
                        break;
                }

            } while (oper != OPERATION.EXIT);

        }
    }
}