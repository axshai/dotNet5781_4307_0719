using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    public class BusLineStation//Bus line station
    {
        private const int FIRST_TIME = 0;//Constant that representing time from previous station if this is the first station (0)
        private const int TIME_CALCULATION = 1;//Constant used for time lottery from previous station

        public string BusStationKey { get; set; }//station number-property
        public double Latitude { get; set; }//Latitude-property
        public double Longitude { get; set; }//Longitude-property
        /// <summary>
        /// ctor for Bus line station
        /// </summary>
        /// <param name="station">A BusStation type object that contains the station location and number</param>
        /// <param name="previousLatit">the Latitude of the previous station-For the purpose of calculating distance()-Default value if this is the first station</param>
        /// <param name="previousLongit">the Longitude of the previous station-For the purpose of calculating distance()-Default value if this is the first station</param>
        public BusLineStation(BusStation station, double previousLatit = -200, double previousLongit = -200)
        {
            BusStationKey = station.BusStationKey;
            Latitude = station.Latitude;
            Longitude = station.Longitude;
            Distance = DistanceCalculate(previousLatit, previousLongit);
            if (previousLatit != -200)//If this is not the first station
                TimeTravel = TIME_CALCULATION;//Calculating the time from the previous station (for the purpose of the exercise we raffled time)
            else//If this is  the first station
                TimeTravel = FIRST_TIME;//Time=0
        }

        public double Distance { get; set; }//Distance from previous station-property
        private double timeTravel;//Distance from previous station
        public double TimeTravel//Travel time from previous station-property
        {
            set
            {
                if (value == FIRST_TIME)//if this is the first station(value=0)
                    timeTravel = value;//timeTravel = value=0
                else
                {
                    Random r = new Random(DateTime.Now.Millisecond);//For the exercise - we raffled time (we have no real way to calculate time from a previous station)
                    timeTravel = double.Parse((r.NextDouble() * 20).ToString().Substring(0, 4));
                }
            }

            get { return timeTravel; }
        }
        /// <summary>
        /// The function receive the location of a previous station and calculates the distance between the current and previous station
        /// </summary>
        /// <param name="previousLatit">the Latitude of the previous station-Default value if this is the first station</param>
        /// <param name="previousLongit">the Longitude of the previous station-Default value if this is the first station</param>
        /// <returns>double-the distance between the current and previous station</returns>
        public double DistanceCalculate(double previousLatit = -200, double previousLongit = -200)
        {
            if (previousLatit != -200)
            {
                return double.Parse(Math.Sqrt(Math.Pow((Latitude - previousLatit), 2) + Math.Pow((Longitude - previousLongit), 2)).ToString().Substring(0, 4));
            }
            else
                return 0;
        }
        /// <summary>
        /// BusLineStation-toString:The station number, its location, time and distance from a previous station
        /// </summary>
        /// <returns>string-BusLineStation as string</returns>
        public override string ToString()
        {
            String result = new BusStation(BusStationKey, Latitude, Longitude).ToString();
            if (Distance != 0)//If this is not the first station
                result += string.Format(" last distance: {0,-4} km.", Distance);
            if (TimeTravel != 0)//If this is not the first station
                result += string.Format(" Travel time from previous station: {0,-4} minutes", TimeTravel);
            return result;
        }
    }
}
