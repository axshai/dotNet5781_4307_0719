using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5781_02_4307_0719
{
    class BusLines : IEnumerable//A collection of lines
    {
        /// <summary>
        /// BusLines ctor-Creates a new List of BusLineRoute
        /// </summary>
        public BusLines()
        {
            Lines = new List<BusLineRoute>();
        }

        private List<BusLineRoute> lines;//List for the lines
        public List<BusLineRoute> Lines//List for the lines-property
        {
            get { List<BusLineRoute> getList = lines; return getList; }//return same list of lines-So that the list does not change as a result of get
            set { lines = value; }
        }
        /// <summary>
        /// The function removes a line from the collection / adds new line to the collection
        /// </summary>
        /// <param name="NumberOfLine">the number of the kine to add/remove</param>
        /// <param name="firstStatCode">number of the first station in the line(To differentiate between it and the opposite line)-Default value if we want to add line</param>
        /// <param name="area">area of the new line-Default value if we want to Get it from the user or if we remove a line now</param>
        public void AddOrRemove(string NumberOfLine, string firstStatCode = "-2", String area = "",BusStation fstation=null, BusStation lstation = null)
        {

            if (firstStatCode != "-2")//If a station number is received - so you want to remove a line
            {
                Lines.Remove(this[NumberOfLine, firstStatCode]);
            }

            else//if station number isnt received-so you want to add a line
            {
                List<BusLineRoute> Lines1 = Lines.FindAll(line => line.BusLine == NumberOfLine);//List of lines with a number like this new one
                if (Lines1.Count() > 1)//If there are already two such lines
                {
                    Console.WriteLine("There are identical Lines");
                }
                else
                {
                    bool check = true;
                    Area a1;
                    string key = "";
                    double latit;
                    double longit;
                    if (area == "")//If no area is received - receive it from the user
                    {
                        Console.WriteLine("Enter an area:GENERAL, NORTH, SOUTH, CENTER, JERUSALEM, SHFELA, WESTBANK");
                        area = Console.ReadLine();
                        Console.WriteLine("Enter details about the first station (station number, latitude and longitude)");
                        key = Console.ReadLine();
                        latit = double.Parse(Console.ReadLine());
                        longit = double.Parse(Console.ReadLine());
                        fstation = new BusStation(key, latit, longit);
                        if (SameStation(fstation))
                            throw new ArgumentException("There is such a station number");
                        Console.WriteLine("Enter details about the last station (station number, latitude and longitude)");
                        key = Console.ReadLine();
                        latit = double.Parse(Console.ReadLine());
                        longit = double.Parse(Console.ReadLine());
                        lstation = new BusStation(key, latit, longit);
                        if (SameStation(lstation))
                            throw new ArgumentException("There is such a station number");
                    }
                    check = Enum.TryParse(area.Replace(" ", "").ToUpper(), out a1);
                    if (Lines1.Count() < 1 || (check && a1 == Lines1[0].Region))//If there is no such line at all or there is one and the areas match
                    {
                       
                        BusLineRoute NewLine = new BusLineRoute(NumberOfLine, area, fstation, lstation);
                        Lines.Add(NewLine);
                    }
                    else
                    {
                        Console.WriteLine("The area contradicts the line in the opposite path");
                    }
                }
            }
        }
        /// <summary>
        /// The function finds all the lines that pass through a particular station
        /// </summary>
        /// <param name="stationNumber">the number of the station</param>
        /// <returns>List of BusLineRoute-all the lines that pass through this station</returns>
        public List<BusLineRoute> BusInStation(string stationNumber)
        {
            List<BusLineRoute> buses = Lines.FindAll(line => line.Stations.Exists(station => station.BusStationKey == stationNumber));
            if (buses.Count == 0)
                throw new ArgumentException("There are no Lines passing through the station");
            return buses;
        }
        /// <summary>
        /// The function sorts the lines by travel time
        /// </summary>
        /// <returns>BusLines-sorted by travel time</returns>
        public BusLines SortedList()
        {
            BusLines newList = new BusLines();
            newList.Lines = Lines;
            newList.Lines.Sort();
            return newList;
        }
        /// <summary>
        /// Realization of the interface IEnumerable
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator GetEnumerator()
        {
            return Lines.GetEnumerator();
        }
        /// <summary>
        /// indexer-Returns an instance of a line according to line number and first station(*)
        /// </summary>
        /// <param name="index">line number</param>
        /// <param name="firstStation">number of lines first station</param>
        /// <returns>an instance of a line(BusLineRoute)</returns>
        //*The line number is not enough because there can be 2 lines with the same number
        public BusLineRoute this[string index, string firstStation]
        {
            set
            {
                if (!Lines.Exists(line => line.BusLine == index && line.FirstStation.BusStationKey == firstStation))
                    throw new ArgumentOutOfRangeException("The line does not exist");
                Lines[Lines.FindIndex(line => line.BusLine == index && line.FirstStation.BusStationKey == firstStation)] = value;

            }
            get
            {

                if (!Lines.Exists(line => line.BusLine == index && line.FirstStation.BusStationKey == firstStation))
                    throw new ArgumentOutOfRangeException("The line does not exist");
                return Lines[Lines.FindIndex(line => line.BusLine == index && line.FirstStation.BusStationKey == firstStation)];


            }
        }
        public bool SameStation(BusStation st)
        {
            foreach (BusLineRoute line in this)//Check that there is no such station number in a different location
            {
                foreach (BusLineStation station1 in line.Stations)
                {
                    if (station1.BusStationKey == st.BusStationKey && (station1.Latitude != st.Latitude || station1.Longitude != st.Longitude))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// BusLines-toString:Prints the details of all the lines in the collection
        /// </summary>
        /// <returns> BusLines as string</returns>
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
