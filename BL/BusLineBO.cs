using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BusLineBO
    {
        public IEnumerable<BusLineStationBO> StationList { get; set; }//List of stations for the line
        public IEnumerable<BusLineScheduleBO> ScheduleList { get; set; }//List of Schedule Line
        public string LineNumber { get; set; }
        public override string ToString()
        {
            string result = LineNumber;
            result += "StationList\n";
            foreach (var item in StationList)
            {
                result += item + "\n";
            }
            result += "ScheduleList\n";
            foreach (var item in ScheduleList)
            {
                result += item + "\n";
            }

            return result;   
        }


    }
}
