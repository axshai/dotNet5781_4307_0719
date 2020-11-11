using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5781_02_4307_0719
{
    class BusLines : IEnumerable
    {
        public BusLines()
        {
            Lines = new List<BusLineRoute>();
        }

        public List<BusLineRoute> Lines { get; set; }

        public void AddOrRemove(string NumberOfLine, string firstStatCode = "-2", String area = "")
        {

            if (firstStatCode != "-2")
            {
                Lines.Remove(this[NumberOfLine, firstStatCode]);
            }

            else
            {
                List<BusLineRoute> Lines1 = Lines.FindAll(line => line.BusLine == NumberOfLine);
                if (Lines1.Count() > 1)
                {
                    Console.WriteLine("There are identical Lines");
                }
                else
                {
                    if (area == "")
                    {
                        Console.WriteLine("Enter an area");
                        area = Console.ReadLine();
                    }
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

        public BusLines SortedList()
        {
            BusLines newList = new BusLines();
            newList.Lines.Sort();
            return newList;
        }

        public IEnumerator GetEnumerator()
        {
            return Lines.GetEnumerator();
        }

        public BusLineRoute this[string index, string firstStation]
        {
            set
            {
                if (firstStation != "-1")
                {
                    if (!Lines.Exists(line => line.BusLine == index && line.FirstStation != null && line.FirstStation.BusStationKey == firstStation))
                        throw new ArgumentOutOfRangeException("The line does not exist");
                    Lines[Lines.FindIndex(line => line.BusLine == index && line.FirstStation.BusStationKey == firstStation)] = value;
                }
                else
                {
                    if (!Lines.Exists(line => line.BusLine == index && line.FirstStation != null && line.FirstStation.BusStationKey == firstStation))
                        throw new ArgumentOutOfRangeException("The line does not exist");
                    Lines[Lines.FindIndex(line => line.BusLine == index && line.FirstStation == null)] = value;
                }
            }
            get
            {
                if (firstStation != "-1")
                {
                    if (!Lines.Exists(line => line.BusLine == index && line.FirstStation != null && line.FirstStation.BusStationKey == firstStation))
                        throw new ArgumentOutOfRangeException("The line does not exist");
                    return Lines[Lines.FindIndex(line => line.BusLine == index && line.FirstStation.BusStationKey == firstStation)];
                }
                else
                {
                    if (!Lines.Exists(line => line.BusLine == index && line.FirstStation == null))
                        throw new ArgumentOutOfRangeException("The line does not exist");
                    return Lines[Lines.FindIndex(line => line.BusLine == index && line.FirstStation == null)];
                }
            }
        }
        public override string ToString()
        {
            string result = "";
            foreach (BusLineRoute line in Lines)
            {
                result += line + "\n";

            }
            return result;
        }

    }
}
