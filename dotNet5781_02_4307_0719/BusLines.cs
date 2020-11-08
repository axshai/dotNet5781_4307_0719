using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{

    class BusLines : IEnumerable
    {
        private List<BusLineRoute> lines = new List<BusLineRoute>();
        public BusLines()
        {
            Lines = new List<BusLineRoute>();
        }

        public List<BusLineRoute> Lines { get; set; }

        public void AddOrRemove(string NumberOfLine, string firstStatCode, int choice)
        {

            if (choice == 0)
            {
                if (lines.Exists(line => line.BusLine == NumberOfLine))
                {
                    lines.Remove(lines.Find(line => line.BusLine == NumberOfLine));
                }
                else
                {
                    Console.WriteLine("The Line is not exist");
                }

                Lines.Remove(this[NumberOfLine, firstStatCode]);
            }
            else if (choice == 1)
            {
                List<BusLineRoute> lines1 = lines.FindAll(line => line.BusLine == NumberOfLine);
                if (lines1.Count() > 1)
                {
                    Console.WriteLine("There are identical lines");
                }
                else
                {
                    Console.WriteLine("Enter an area");
                    string area=Console.ReadLine();
                    if (lines1.Count() == 1)
                    string area = Console.ReadLine();
                    if (Lines1.Count() < 1 || area == Lines1[0].Region.ToString())
                    {
                        BusLineRoute NewLine = new BusLineRoute(NumberOfLine, area);
                        Lines.Add(NewLine);
                    }
                    else
                    {
                        if(area!=)




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

        public IEnumerator GetEnumerator()
        {
            return lines.GetEnumerator();
        }


        //
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
