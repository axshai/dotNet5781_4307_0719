using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BusStationBO
    {
        public IEnumerable<LineInStationBO> ListOfLines { get; set; }
        public IEnumerable<ConsecutiveStationBO> ListOfConsecutiveLineStations { get; set; }

        public string StationName { get; set; }
        public int StationKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Area Area { get; set; }
        public override string ToString()
        {
            string result ="key" + StationKey+ "arrival:\n";
            foreach (var item in ListOfLines)
            {
                result += item.LineNumber + ":  ";
                foreach (var item1 in item.ArrivalTimes)
                {
                    result += item1 + " ";
                }
                result += "\n";
            }
            return result;

        } 
    }
}
