using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BusStationBO
    {
        public IEnumerable<BusLineBO> ListOfLines { get; set; }

        public string StationName { get; set; }
        public int StationKey { get; set; }

        public override string ToString()
        { return "key: " + StationKey + " name: " + StationName; }
    }
}
