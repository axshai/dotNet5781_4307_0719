using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class BusLineStation 
    {
        private const int FIRST_TIME = 0;
        private const int TIME_CALCULATION = 1;

        public string BusStationKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public BusLineStation(BusStation station , double previousLatit = -200, double previousLongit = -200) 
        {
            BusStationKey = station.BusStationKey;
            Latitude = station.Latitude;
            Longitude = station.Longitude;
            Distance = DistanceCalculate(previousLatit, previousLongit);
            if (previousLatit != -200)
                TimeTravel = TIME_CALCULATION;
            else
                TimeTravel = FIRST_TIME;
        }

        public double Distance { get; set; }

        private double timeTravel;
        public double TimeTravel
        {
            set
            {
                if (value == FIRST_TIME)
                    timeTravel = value;
                else
                {
                    Random r = new Random(DateTime.Now.Millisecond);
                    timeTravel = double.Parse((r.NextDouble() * 20).ToString().Substring(0,4));
                }
            }

            get { return timeTravel; }
        }

        public double DistanceCalculate(double previousLatit = -200, double previousLongit = -200)
        {
            if (previousLatit != -200)
            {
                return double.Parse(Math.Sqrt(Math.Pow((Latitude - previousLatit), 2) + Math.Pow((Longitude - previousLongit), 2)).ToString().Substring(0,4));
            }
            else
                return 0;
        }

        public override string ToString()
        {
            String result = new BusStation(BusStationKey,Latitude,Longitude).ToString();
            if (Distance != 0)
                result += " last distance: " +Distance+" km";
            if (TimeTravel != 0)
                result += "  Travel time from previous station : " + TimeTravel+ " minutes";
            return result;
        }
    }
}
