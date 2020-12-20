using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public class BusStationDO
    {

      
        public int StationKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string StationName { get; set; }
        public bool IsExists { get; set; }
        public override string ToString()
        {
            string result = "StationKey: " + StationKey.ToString() + "\nLatitude: " + Latitude.ToString() + "\nLongitude" + Longitude.ToString() + "\nStationName: " + StationName + "\nIsExists? " + IsExists.ToString();

            return result;
        }
    }
}
