using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class BusLineRoute : IComparable//Single bus line
    {
        /// <summary>
        /// BusLineRoute ctor-creat list of his stations
        /// </summary>
        /// <param name="lineNumber">number of the line</param>
        /// <param name="area">Area of ​​activity</param>
        /// <param name="first">his first station</param>
        /// <param name="last">his lirst station</param>
        public BusLineRoute(string lineNumber, string area,BusStation first, BusStation last)
        {
            Area a1;
            bool check = Enum.TryParse(area.Replace(" ", "").ToUpper(), out a1);
            if (!check)
                throw new ArgumentException("There is no such area in the system");
            BusLine = lineNumber;
            Stations = new List<BusLineStation>();
            Region = a1;
            FirstStation = new BusLineStation(first);
            LastStation = new BusLineStation(last, first.Latitude, first.Longitude);
        }

        private List<BusLineStation> stations;//List for The stations of the line
        public List<BusLineStation> Stations //List for The stations of the line-property
        {
            get { List<BusLineStation> getList = stations; return getList; }
            set { stations = value; }
        }

        private string busLine;//the number of the line
        public string BusLine////the number of the line-property
        {
            set
            {
                uint numberAsInt;
                bool check;
                check = uint.TryParse(value, out numberAsInt);//Check that the line contain only digits
                if (!check)
                {
                    throw new FormatException("A line number can contain only digits!");
                }
                busLine = value;
            }
            get
            {
                return busLine;
            }
        }

        public BusLineStation FirstStation//the first station of the line (The property here is a kind of doll with behind it you approach the list)
        {
            set
            {
               Stations.Insert(0, value);
                if (Stations.Count() > 1)
                {
                    Stations[1].Distance = Stations[1].DistanceCalculate(value.Latitude, value.Longitude);//Make the station that was first become second (calculate distance and time from it to new)
                    Stations[1].TimeTravel = 1;//Causes time lottery - see BusLineStation class
                }
            }
            get => Stations[0];
        }

        public BusLineStation LastStation//the last station of the line (The property here is a kind of doll with behind it you approach the list)
        {
            set { Stations.Add(value); }
            get => Stations[Stations.Count() - 1];
        }

        public Area Region { set; get; }//the area of the line-property

        /// <summary>
        /// The function checks whether the line passes through a particular station
        /// </summary>
        /// <param name="stationNumber">The requested station</param>
        /// <returns>A Boolean variable that announces whether the line passes through the station</returns>
        public bool CheckStation(string stationNumber)
        {
            return Stations.Exists(station => station.BusStationKey == stationNumber);
        }

        /// <summary>
        /// The function calculates the distance between 2 stations
        /// </summary>
        /// <param name="station1"></param>
        /// <param name="station2"></param>
        /// <returns>double-The distance between the station</returns>
        public double DistanceCalculate(BusLineStation station1, BusLineStation station2)///
        {
            return station1.DistanceCalculate(station2.Latitude, station2.Longitude);
        }
        /// <summary>
        /// The function calculates travel time between two stations
        /// </summary>
        /// <param name="station1"></param>
        /// <param name="station2"></param>
        /// <returns>double-The travel time between the stations</returns>
        public double TimeCalculate(string station1, string station2)
        {
            double sum = 0;
            int index1 = this.Stations.FindIndex(station => station.BusStationKey == station1);
            int index2 = this.Stations.FindIndex(station => station.BusStationKey == station2);
            if (index1 == -1 || index2 == -1)//If one of the stations does not exist
                throw new ArgumentException("one or more of the Stations isnt in the line");
            int FirstIndex = index1 < index2 ? index1 : index2;
            int LastIndex = index1 > index2 ? index1 : index2;
            for (int i = FirstIndex + 1; i <= LastIndex; i++)//Sum the travel time between each 2 stations between The 2 stations
                sum += Stations[i].TimeTravel;
            return sum;
        }
        /// <summary>
        /// The function returns a subline with a first and last stop as requested
        /// </summary>
        /// <param name="station1">first station of the subline</param>
        /// <param name="station2">last station of the subline</param>
        /// <returns>BusLineRoute-the subline</returns>
        public BusLineRoute subLine(string station1, string station2)
        {
            int index1 = this.Stations.FindIndex(station => station.BusStationKey == station1);
            int index2 = this.Stations.FindIndex(station => station.BusStationKey == station2);
            if (index1 == -1 || index2 == -1)//If one of the stations does not exist
                throw new ArgumentException("one or more of the Stations isnt in the line");
            int FirstIndex = index1 < index2 ? index1 : index2;
            int LastIndex = index1 > index2 ? index1 : index2;
            BusStation first = new BusStation(Stations[FirstIndex].BusStationKey, Stations[FirstIndex].Latitude, Stations[FirstIndex].Longitude);
            BusStation last = new BusStation(Stations[LastIndex].BusStationKey, Stations[LastIndex].Latitude, Stations[LastIndex].Longitude);
            BusLineRoute newLine = new BusLineRoute(BusLine, Region.ToString(),new BusStation(first.BusStationKey,first.Latitude,first.Longitude), new BusStation(last.BusStationKey, last.Latitude, last.Longitude));//Creating the new bus line-We assume that the number of the sub-line is equal to the large one
            for (int i = FirstIndex+1,j=1; i <= LastIndex; i++,j++)
            {
                newLine.Stations.Insert(j, Stations[i]);
               
            }
            newLine.Stations.RemoveAt(newLine.Stations.Count() - 1);
            return newLine;
        }
        /// <summary>
        /// The function calculates total travel time on a bus line
        /// </summary>
        /// <returns> double-the travel time</returns>
        public double TotalTime()
        {
            return FirstStation == null ? 0 : TimeCalculate(FirstStation.BusStationKey, LastStation.BusStationKey);
        }
        /// <summary>
        /// The function removes or adds a stop to a bus line
        /// </summary>
        /// <param name="choice">Instruction whether to remove(choice=0) or add(choice=1)</param>
        /// <param name="l1">Line Collection-to Make sure the station number does not already exist in case of addition</param>
        /// <param name="station2">"ready" Station to add(in the begining)-a default value in case we add at the user's request</param>
        public void AddOrRemove(int choice, BusLines l1, BusStation station2 = null)
        {
            if (choice == 0)//remove station
            {
                Console.WriteLine("enter station number");
                string keyOfCurrent = Console.ReadLine();
                if (!Stations.Exists(station => station.BusStationKey == keyOfCurrent))
                    Console.WriteLine("this Station not exist");
                else
                {
                    int indexofnext = Stations.FindIndex(station => station.BusStationKey == keyOfCurrent);
                    if (Stations.Count() > 2)
                    {

                        Stations.Remove(Stations.Find(station => station.BusStationKey == keyOfCurrent));
                        if (indexofnext != (Stations.Count()))//If we did not delete the last station
                        {
                            Stations[indexofnext].TimeTravel = indexofnext;//Calculate the travel time between the two stations that are now adjacent(or Place at the station which is now the first the time 0)-see BusLineStation class
                            if (indexofnext != 0)//If we did not delete the first one
                                Stations[indexofnext].Distance = Stations[indexofnext].DistanceCalculate(Stations[indexofnext - 1].Latitude, Stations[indexofnext - 1].Longitude);//Calculate the distance between the two stations that are now adjacent
                            else//If we delete the first one-
                                Stations[indexofnext].Distance = 0;//Place at the station which is now the first the distance 0
                        }
                    }
                    else //if If less than two stations remain
                    {
                        Console.WriteLine("A line must contain at least 2 stations");
                    }
                }
            }

            else if (choice == 1)//add station
            {
                string key = "";
                string previous = "";
                double latit = 0;
                double longit = 0;
                if (station2 == null)//If we want to receive the station details from the user
                {
                    Console.WriteLine("Enter number from previous station-or enter -1 to add first station");//Ask for the previous station number so we know where to add the new one
                    previous = Console.ReadLine();
                    if (previous != "-1" && !Stations.Exists(station => station.BusStationKey == previous))
                        Console.WriteLine("There is no such station");
                    else
                    {
                        Console.WriteLine("Enter details about the station: number of station, latitude, longitude");
                        key = Console.ReadLine();
                        latit = double.Parse(Console.ReadLine());
                        longit = double.Parse(Console.ReadLine());

                    }
                }
                else//If the function received a "ready" station
                {
                    key = station2.BusStationKey;
                    latit = station2.Latitude;
                    longit = station2.Longitude;
                    previous = "-1";
                }
                
                foreach (BusLineRoute line in l1)//Check that there is no such station number in a different location
                {
                    foreach (BusLineStation station1 in line.Stations)
                    {
                        if (station1.BusStationKey == key && (station1.Latitude != latit || station1.Longitude != longit))
                        {
                            throw new ArgumentException("There is such a station number");
                        }
                    }
                }
                if (Stations.Exists(station1 => station1.BusStationKey == key && station1.Latitude == latit && station1.Longitude == longit))//Check that the line does not already pass through this station
                {

                    throw new ArgumentException("There is the same station");
                }



                if (previous == "-1")//If we wants to add a first stop
                {
                    BusStation newStation = new BusStation(key, latit, longit);
                    BusLineStation newStation1 = new BusLineStation(newStation);
                    FirstStation = newStation1;
                }

                else//If we dont want to add a first stop
                {
                    //Find the previous station — and calculate the time and distance from the stations that have now become adjacent
                    BusLineStation preStation = Stations.Find(station => station.BusStationKey == previous);
                    BusStation newStation = new BusStation(key, latit, longit);
                    BusLineStation newStation1 = new BusLineStation(newStation, preStation.Latitude, preStation.Longitude);
                    if (Stations.IndexOf(preStation) < Stations.Count() - 1)//If he did not add a last station
                    {
                        Stations.Insert(Stations.IndexOf(preStation) + 1, newStation1);
                        Stations[Stations.IndexOf(newStation1) + 1].Distance = Stations[Stations.IndexOf(newStation1) + 1].DistanceCalculate(latit, longit);
                        Stations[Stations.IndexOf(newStation1) + 1].TimeTravel = 1;
                    }
                    else//If he add a last station
                    {
                        LastStation = newStation1;
                    }

                }
            }
            else
            {
                Console.WriteLine("only 0 or 1!");
            }
        }
        /// <summary>
        /// BusLineRoute-toString:Prints the details of all the atations of the line,his area and his number
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "line number: " + BusLine + " Area: " + Region + "\nStations:";
            foreach (BusLineStation station in Stations)
            {
                result += "\n" + station;
            }
            return result;
        }
        /// <summary>
        /// Realization of the interface IComparable
        /// </summary>
        /// <param name="obj">Another object for comparison</param>
        /// <returns>int-The result of the comparison</returns>
        public int CompareTo(object obj)
        {
            return this.TotalTime().CompareTo(((BusLineRoute)obj).TotalTime());//Compare by travel time

        }
    }
}

