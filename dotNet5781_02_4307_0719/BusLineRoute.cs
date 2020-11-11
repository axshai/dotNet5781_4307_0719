using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class BusLineRoute : IComparable
    {

        public BusLineRoute(string lineNumber, string area)
        {
            Area a1;
            
                bool check = Enum.TryParse(area.Replace(" ", "").ToUpper(), out a1);//*
            if (!check)
                throw new ArgumentException("There is no such area in the system");
            else
            {
                BusLine = lineNumber;
                Stations = new List<BusLineStation>();
                Region = a1;
            }

        }

        public List<BusLineStation> Stations { get; set; }

        private string busLine;
        public string BusLine
        {
            set
            {
                uint numberAsInt;
                bool check;
                check = uint.TryParse(value, out numberAsInt);

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

        private BusLineStation firstStation;
        public BusLineStation FirstStation
        {
            set
            {
                if (Stations.Count() > 0)
                {
                    Stations.Insert(0, value);
                    Stations[1].Distance = Stations[1].DistanceCalculate(value.Latitude, value.Longitude);
                    Stations[1].TimeTravel = 1;
                }
                else
                    Stations.Add(value);

            }
            get => Stations.Count() == 0 ? null : Stations[0];
        }

        private BusLineStation lastStation;
        public BusLineStation LastStation
        {
            set { Stations.Add(value); }
            get => Stations.Count() == 0 ? null : Stations[Stations.Count() - 1];
        }


        public Area Region { set; get; }


        public bool CheckStation(string stationNumber)
        {
            return Stations.Exists(station => station.BusStationKey == stationNumber);
        }

        public double DistanceCalculate(BusLineStation station1, BusLineStation station2)///
        {
            return station1.DistanceCalculate(station2.Latitude, station2.Longitude);
        }

        public double TimeCalculate(string station1, string station2)////
        {
            double sum = 0;
            int index1 = this.Stations.FindIndex(station => station.BusStationKey == station1);
            int index2 = this.Stations.FindIndex(station => station.BusStationKey == station2);
            if (index1 == -1 || index2 == -1)
                throw new ArgumentException("one or more of the Stations isnt in the line");
            int FirstIndex = index1 < index2 ? index1 : index2;
            int LastIndex = index1 > index2 ? index1 : index2;
            for (int i = FirstIndex + 1; i <= LastIndex; i++)
                sum += Stations[i].TimeTravel;
            return sum;
        }

        public BusLineRoute subLine(string station1, string station2)
        {

            int index1 = this.Stations.FindIndex(station => station.BusStationKey == station1);
            int index2 = this.Stations.FindIndex(station => station.BusStationKey == station2);
            if (index1 == -1 || index2 == -1)
                throw new ArgumentException("one or more of the Stations isnt in the line");
            int FirstIndex = index1 < index2 ? index1 : index2;
            int LastIndex = index1 > index2 ? index1 : index2;
            BusLineRoute newLine = new BusLineRoute(BusLine + 0, Region.ToString());
            for (int i = FirstIndex; i <= LastIndex; i++)
            {
                newLine.Stations.Add(this.Stations[i]);
                newLine.Stations[0].Distance = newLine.Stations[0].TimeTravel = 0;
            }
            return newLine;
        }

        public double TotalTime()
        {
            return TimeCalculate(FirstStation.BusStationKey, LastStation.BusStationKey);
        }

        public void AddOrRemove(int choice, BusLines l1)
        {
            if (choice == 0)
            {
                Console.WriteLine("enter station number");
                string keyOfCurrent = Console.ReadLine();
                if (!Stations.Exists(station => station.BusStationKey == keyOfCurrent))
                    Console.WriteLine("this Station not exist");
                else
                {
                    int indexofnext = Stations.FindIndex(station => station.BusStationKey == keyOfCurrent);
                    Stations.Remove(Stations.Find(station => station.BusStationKey == keyOfCurrent));
                    if (indexofnext != (Stations.Count()))
                    {
                        Stations[indexofnext].TimeTravel = indexofnext;
                        if (indexofnext != 0)
                            Stations[indexofnext].Distance = Stations[indexofnext].DistanceCalculate(Stations[indexofnext - 1].Latitude, Stations[indexofnext - 1].Longitude);
                        else
                            Stations[indexofnext].Distance = 0;
                    }
                }
            }
            else if (choice == 1)
            {
                Console.WriteLine("Enter number from previous station-or enter -1 to add first station");
                string previous = Console.ReadLine();
                if (previous != "-1" && !Stations.Exists(station => station.BusStationKey == previous))
                    Console.WriteLine("There is no such station");
                else
                {
                    Console.WriteLine("Enter details about the station: number of station, latitude, longitude");
                    string key = Console.ReadLine();
                    double latit = double.Parse(Console.ReadLine());
                    double longit = double.Parse(Console.ReadLine());
                    foreach (BusLineRoute line in l1)
                    {
                        foreach (BusLineStation station1 in line.Stations)
                        {
                            if (station1.BusStationKey == key && (station1.Latitude != latit || station1.Longitude != longit))
                            {
                                throw new ArgumentException("There is such a station number");
                            }
                        }
                    }
                    if (Stations.Exists(station1 => station1.BusStationKey == key && station1.Latitude == latit && station1.Longitude == longit))
                    {

                        throw new ArgumentException("There is the same station");
                    }



                    if (previous == "-1")
                    {
                        BusStation newStation = new BusStation(key, latit, longit);
                        BusLineStation newStation1 = new BusLineStation(newStation);
                        FirstStation = newStation1;
                    }
                    else
                    {
                        BusLineStation preStation = Stations.Find(station => station.BusStationKey == previous);
                        BusStation newStation = new BusStation(key, latit, longit);
                        BusLineStation newStation1 = new BusLineStation(newStation, "", preStation.Latitude, preStation.Longitude);
                        if (Stations.IndexOf(preStation) < Stations.Count() - 1)
                        {
                            Stations.Insert(Stations.IndexOf(preStation) + 1, newStation1);
                            Stations[Stations.IndexOf(newStation1) + 1].Distance = Stations[Stations.IndexOf(newStation1) + 1].DistanceCalculate(latit, longit);
                            Stations[Stations.IndexOf(newStation1) + 1].TimeTravel = 1;
                        }
                        else
                        {
                            LastStation = newStation1;
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("only 0 or 1");
            }
        }

        public override string ToString()
        {
            string result = "line number: " + BusLine + " Area: " + Region + "\nStations:";
            foreach (BusLineStation station in Stations)
            {
                result += "\n" + station;
            }
            return result;
        }

        public int CompareTo(object obj)
        {
            return this.TotalTime().CompareTo(((BusLineRoute)obj).TotalTime());
        }
    }
}

