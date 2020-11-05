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
            BusLine = lineNumber;
            Stations = new List<BusLineStation>();
            Region = a1;

        }

        public List<BusLineStation> Stations { get; set; }

        private string busLine;
        public string BusLine
        { get; set; }

        private BusLineStation firstStation;
        public BusLineStation FirstStation
        {
            set { firstStation = Stations[0]; }
            get => Stations[0];
        }

        private BusLineStation lastStation;
        public BusLineStation LastStation
        {
            set { lastStation = Stations[0]; }
            get => Stations[Stations.Count - 1];
        }


        public Area Region { set; get; }


        public bool CheckStation(BusLineStation station)
        {
            return Stations.Contains(station);
        }

        public double DistanceCalculate(BusLineStation station1, BusLineStation station2)//
        {
            return station1.DistanceCalculate(station2.Latitude, station2.Longitude);
        }

        public double TimeCalculate(BusLineStation station1, BusLineStation station2)//
        {
            double sum = 0;
            int index1 = this.Stations.IndexOf(station1);
            int index2 = this.Stations.IndexOf(station2);
            if (index1 == -1 || index2 == -1)
                throw new Exception("one or more of the Stations isnt in the line");
            int FirstIndex = index1 > index2 ? index1 : index2;
            int LastIndex = index1 < index2 ? index1 : index2;
            for (int i = FirstIndex + 1; i <= LastIndex; i++)
                sum += Stations[i].TimeTravel;
            return sum;
        }

        public BusLineRoute subLine(BusLineStation station1, BusLineStation station2)
        {

            int index1 = this.Stations.IndexOf(station1);
            int index2 = this.Stations.IndexOf(station2);
            if (index1 == -1 || index2 == -1)
                throw new Exception("one or more of the Stations isnt in the line");
            int FirstIndex = index1 > index2 ? index1 : index2;
            int LastIndex = index1 < index2 ? index1 : index2;
            //לשאול את המשתמש
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
            double sum = 0;
            foreach (BusLineStation station in Stations)
            {
                sum += station.TimeTravel;
            }
            return sum;
        }

        public void AddOrRemove(int choice, BusLineStation toremoveoradd, BusLineStation privuse = null)
        {
            if (choice == 0)
            {
                if (!Stations.Contains(toremoveoradd))
                    Console.WriteLine("this Station not exist");
                else
                {
                    Stations.Remove(toremoveoradd);

                }
            }
            else if (choice == 1)
            {
                
                if (privuse != null&&!Stations.Contains(privuse))
                    Console.WriteLine("the privuse Station not exist");
                else if(privuse != null)
                {
                    int index=Stations.IndexOf(privuse);
                    Stations.Insert(index + 1, privuse);
                }
                else
                {
                    Stations.Insert(0, privuse);
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
                result += " " + station;
            }
            return result;
        }

        public int CompareTo(object obj)
        {
            return this.TotalTime().CompareTo(((BusLineRoute)obj).TotalTime());
        }
    }
}
