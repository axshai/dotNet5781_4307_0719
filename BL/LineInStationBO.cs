using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineInStationBO
    {
        public Area Area{get; set;}
        public string LineNumber { get; set; }
        public int Id { get; set; }
        public string Destination { get; set; }
        public IEnumerable<TimeSpan> ArrivalTimes { get; set; }
        public override string ToString()
        {
            return "i am" + LineNumber + " Id  ";
        }
    }
}
