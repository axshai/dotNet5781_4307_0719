using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BusLineStationBO
    {
        public int StationKey { get; set; }
        public string StationName { get; set; }
        public double DistanceFromPrev { get; set; }
        public TimeSpan TimeFromPrev { get; set; }
        
        public override string ToString()
        {
            return "StationKey: " + StationKey + " StationName " + StationName + " DistanceFromPrev " + DistanceFromPrev + " TimeFromPrev " + TimeFromPrev.ToString();
        }

    }
}
