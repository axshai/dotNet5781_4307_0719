using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class ConsecutiveStationsDO
    {


        public override string ToString()
        {

            string result = "Station1Key: " + Station1Key.ToString() + "\nStation2Key: " + Station2Key.ToString() + "\nDistance: " + Distance.ToString()  + "\nTravelTime:  " + TravelTime.ToString();
                
            return result;
        }
        public int Station1Key { get; set; }
        public int Station2Key { get; set; }
        public double Distance { get; set; }
        public TimeSpan TravelTime { get; set; }

    }
}
