using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class BusLines
    {
        public BusLines()
        {
            Lines = new List<BusLineRoute>();
        }

        public List<BusLineRoute> Lines { get; set; }

        public void AddOrRemove(string NumberOfLine, string firstStatCode, int choice)
        {

            if (choice == 0)
            {
                Lines.Remove(this[NumberOfLine, firstStatCode]);
            }

            else if (choice == 1)
            {
                List<BusLineRoute> Lines1 = Lines.FindAll(line => line.BusLine == NumberOfLine);
                if (Lines1.Count() > 1)
                {
                    Console.WriteLine("There are identical Lines");
                }
                else
                {
                    Console.WriteLine("Enter an area");
                    string area = Console.ReadLine();
                    if (Lines1.Count() < 1 || area == Lines1[0].Region.ToString())
                    {
                        BusLineRoute NewLine = new BusLineRoute(NumberOfLine, area);
                        Lines.Add(NewLine);
                    }
                    else
                    {
                        Console.WriteLine("The area contradicts the line in the opposite path");
                    }
                }
            }
        }

        public List<BusLineRoute> BusInStation(string stationNumber)
        {
            List<BusLineRoute> buses = Lines.FindAll(line => line.Stations.Exists(station => station.BusStationKey == stationNumber));
            if (buses.Count == 0)
                throw new ArgumentException("There are no Lines passing through the station");
            return buses;
        }

        public List<BusLineRoute> SortedList(string stationNumber)
        {
            List<BusLineRoute> newList = Lines;
            newList.Sort();
            return newList;
        }

        public BusLineRoute this[string index, string firstStation]
        {
            set
            {
                if (!Lines.Exists(line => line.BusLine == index && line.FirstStation.BusStationKey == firstStation))
                    throw new Exception("The line does not exist");
                Lines[Lines.FindIndex(line => line.BusLine == index && line.FirstStation.BusStationKey == firstStation)] = value;
            }
            get
            {
                if (!Lines.Exists(line => line.BusLine == index && line.FirstStation.BusStationKey == firstStation))
                    throw new Exception("The line does not exist");
                return Lines[Lines.FindIndex(line => line.BusLine == index && line.FirstStation.BusStationKey == firstStation)];
            }
        }

    }
}

