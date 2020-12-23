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
            string result = "LineId: " + LineId + "\nStationKey: " + StationKey.ToString() + "\nSerial: " + Serial.ToString();
            return result;
        }
        public int LineId { get; set; }
        public int StationKey { get;set; }
        public int Serial { get; set; }
        public bool IsExist { get; set; }

    }
}
