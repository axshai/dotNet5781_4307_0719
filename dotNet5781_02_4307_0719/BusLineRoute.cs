using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class BusLineRoute
    {
        private List<BusLineStation> stations = new List<BusLineStation>();

        public int BusLine { get; set; }
        public List<BusLineStation> Stations
        {
            get;
            set;
        }
        public BusLineStation FirstStation
        {
            get => stations[0];
        }
        public BusLineStation LastStation
        {
            get => stations[stations.Count - 1];
        }

        public Area Region { get; set; }

        public BusLineStation this[int index] => stations[index];

        public override string ToString()
        {
            string result = "line number: " + BusLine + " Area: " + Region+"\nstations:";
            foreach(BusLineStation station in stations)
            {
                result += " " + station;
            }
            return result;
        }
        public bool CheckStation(BusLineStation station)
        {
            return stations.Contains(station);
        }

        public double DistanceCalculate(BusLineStation station1, BusLineStation station2)//
        {
            return station1.DistanceCalculate(station2.Latitude, station2.Longitude);
        }
        public double TimeCalculate(BusLineStation station1, BusLineStation station2)//
        {
            double sum =0;
            int index1 = this.stations.IndexOf(station1);
            int index2 = this.stations.IndexOf(station2);
            if (index1 == -1 || index2 == -1)
                throw new Exception("one or more of the stations isnt in the line");
           int FirstIndex = index1 > index2 ? index1 : index2;
            int LastIndex= index1 < index2 ? index1 : index2;
            for (int i = FirstIndex + 1; i <= LastIndex; i++)
                sum += stations[i].TimeTravel;
            return sum;
        }
    }
}
