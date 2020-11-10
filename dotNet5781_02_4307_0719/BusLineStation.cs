using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class BusLineStation : BusStation
    {
        private const int FIRST_TIME = 0;
        private const int TIME_CALCULATION = 1;

        public BusLineStation(string code, double latit, double longit, string address = "", double previousLatit = -200, double previousLongit = -200) : base(code, latit, longit, address)
        {
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
                    timeTravel = r.NextDouble() * 20;
                }
            }

            get { return timeTravel; }
        }

        public double DistanceCalculate(double previousLatit = -200, double previousLongit = -200)
        {
            if (previousLatit != -200)
            {
                return Math.Sqrt(Math.Pow((Latitude - previousLatit), 2) + Math.Pow((Longitude - previousLongit), 2));
            }
            else
                return 0;
        }

        public override string ToString()
        {
            String result = base.ToString();
            if (Distance != 0)
                result += " last distance: " +Distance+" km";
            if (TimeTravel != 0)
                result += "  Travel time from previous station : " + TimeTravel+ " minutes";
            return result;
        }
    }
}
