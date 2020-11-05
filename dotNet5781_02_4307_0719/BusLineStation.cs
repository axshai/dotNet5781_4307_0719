using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class BusLineStation : BusStation
    {
        public BusLineStation(string code, double latit, double longit, string address = "", double previousLatit = -200, double previousLongit = -200) : base(code, latit, longit, address)
        {
            Distance = DistanceCalculate(previousLatit, previousLongit);
            Random r = new Random(DateTime.Now.Millisecond);
            if (previousLatit != -200)
                TimeTravel = r.NextDouble() * 20;
            else
                TimeTravel = 0;
        }

        public double Distance { get; set; }
        public double TimeTravel { get; set; }

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
            result += "\nlast distance :" + Distance;
            if (TimeTravel != 0)
                result += "  Travel time from previous station : " + TimeTravel;
            return result;
        }
    }
}
