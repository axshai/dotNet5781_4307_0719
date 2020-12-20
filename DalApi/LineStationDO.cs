using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public class LineStationDO
    {
        public override string ToString()
        {
            string result = "LineNumber: " + LineNumber + "\nStationKey: " + StationKey.ToString() + "\nSerial: " + Serial.ToString();
            return result;
        }
        public string LineNumber { get; set; }
        public int StationKey { get;set; }
        public int Serial { get; set; }

    }
}
