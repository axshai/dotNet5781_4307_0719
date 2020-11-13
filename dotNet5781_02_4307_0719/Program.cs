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
        //Add a line or station
        static void Add(BusLines listOfLines, CHOICE lineOrStation, string lineNumber, string first)
        {
            if (lineOrStation == CHOICE.ZERO)//Add line
            {
                listOfLines.AddOrRemove(lineNumber);//"AddOrRemove" Add the line
            }
            else if (lineOrStation == CHOICE.ONE)//Add station
            {
                listOfLines[lineNumber, first].AddOrRemove(1, listOfLines);//We will add to line the list of stations
            }

        }
        static void zeroOrOne(out CHOICE choice)//Input integrity check (0 or 1)
        {
            string input;
            bool success;//Check input 
            do              // to check the input
            {
                input = Console.ReadLine();          //The user chooses
                success = Enum.TryParse(input, out choice) && (choice == CHOICE.ZERO || choice == CHOICE.ONE);
                if (!success)//The choice is neither 0 nor 1
                {
                    Console.WriteLine("only 0 or 1! try again.");
                }
            }
            while (success == false);//As long as the selection is neither 0 nor 1
        }

        static BusLines initialization()//We will initialize a list of lines and stations for each line
       {

           Random r = new Random(DateTime.Now.Millisecond);//Random number for station longitude and latitude lines (and area for lines)
            BusLines listOfLines= new BusLines();
            for (int i=1;i<=10;i++)
            {
                BusStation first = new BusStation(i.ToString()+3, 33.3 - r.NextDouble() * 2.3, 35.5 - r.NextDouble() * 1.2);
                BusStation last=new BusStation(i.ToString() + 4, 33.3 - r.NextDouble() * 2.3, 35.5 - r.NextDouble() * 1.2);
                listOfLines.AddOrRemove(i.ToString(), area: r.Next(7).ToString(), fstation: first, lstation: last);
                string x = i.ToString()+3;
                for(int j=2;j>=1;j--)
                {
                    listOfLines[i.ToString(), x].FirstStation= new  BusLineStation(new BusStation(i.ToString() + j, 33.3 - r.NextDouble() * 2.3, 35.5 - r.NextDouble() * 1.2));
                   
                    x = i.ToString() + j.ToString();
                }
                
               
            }
            for (int i = 1; i <= 9; i++)
            {
                listOfLines[i.ToString(), i.ToString() + 1].FirstStation = listOfLines[(i + 1).ToString(), (i + 1).ToString() + 1].FirstStation;
            }
            listOfLines["10", "101"].FirstStation = listOfLines["1", "21"].Stations[1];
                return listOfLines;//We will return the list of initialized lines
        }

        static void Main(string[] args)
        {
            BusLines listOfLines = initialization();
            OPERATION oper; //to Menu selection
            CHOICE choice; //To select: station or line
            bool success;//Input integrity check
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
                    case OPERATION.ADD: //Add a line or station
                        Console.WriteLine("enter 0 to add new line, 1 to add new station:");
                        zeroOrOne(out choice); //Input check
                        Console.WriteLine("enter the number of the line");
                        string lineNumber = Console.ReadLine();
                        string first = "";
                        if (choice == CHOICE.ONE)//add new station
                        {
                            Console.WriteLine("enter the number of the fisrt station");
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
                        catch (ArgumentOutOfRangeException ex)// form indexer
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (ArgumentException ex)// from AddOrRemove or constructor
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case OPERATION.DELETE://to delete line or delete station
                        Console.WriteLine("enter 0 to delete line, 1 to delete station:");
                        zeroOrOne(out choice);//Input check
                        Console.WriteLine("enter the number of the line");
                        lineNumber = Console.ReadLine();
                        Console.WriteLine("enter the number of the fisrt station");
                        first = Console.ReadLine();
                        try
                        {
                            if (choice == CHOICE.ZERO)//delete line
                            {
                                listOfLines.AddOrRemove(lineNumber, first);
                            }
                            else if (choice == CHOICE.ONE)// delete station
                            {
                                listOfLines[lineNumber, first].AddOrRemove(0, listOfLines);
                            }
                        }

                        catch (ArgumentOutOfRangeException ex)//from indexer
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case OPERATION.FIND://to Look for a line or Printing the options for travel between 2 stations
                        Console.WriteLine("Enter 0 to Look for a line passing through a specific station");
                        Console.WriteLine("or 1 to Printing the options for travel between 2 stations");
                        zeroOrOne(out choice);//Input check
                        if (choice == CHOICE.ZERO) //Look for a line
                         {
                            Console.WriteLine("Enter the number of station");
                            input = Console.ReadLine();
                            int i = 0;
                            foreach (BusLineRoute line in listOfLines)
                            {
                                if (line.CheckStation(input))//We will print all the stations whose number is the input number
                                {
                                    Console.WriteLine(line);
                                    i++;
                                }
                            }
                            if(i==0)
                                Console.WriteLine("There are no lines passing through this station");
                        }
                        else if (choice == CHOICE.ONE)//Printing the options for travel between 2 stations
                        {
                            Console.WriteLine("Enter the stations numbers");
                            string station1 = Console.ReadLine();
                            string station2 = Console.ReadLine();
                            List<BusLineRoute> subLines = new List<BusLineRoute>();//We will create the list of printable stations
                            foreach (BusLineRoute line in listOfLines)
                            {
                                try
                                {
                                    subLines.Add(line.subLine(station1, station2));
                                }
                                catch (ArgumentException)
                                {
                                    
                                }
                            }
                            BusLines sublinesSort = new BusLines();
                            sublinesSort.Lines = subLines;
                            sublinesSort = sublinesSort.SortedList();
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