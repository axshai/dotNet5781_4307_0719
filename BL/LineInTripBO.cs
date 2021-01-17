using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineInTripBO
    {
        public string LineNumber { get; set; }
        public string Destination { get; set; }
        public TimeSpan timing { get; set; }

        public override string ToString()
        {
            return "LineNumber" + LineNumber + "Destination" + Destination + "timing" + timing;
        }
    }
}