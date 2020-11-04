using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class BusLineStation:BusStation
    {
        public double Distance { get; set; }
        public double TimeTravel { get; set; }

        public override string ToString()
        {
            String result = base.ToString();
            result += "last distance :" + Distance;
            result += "Time Travel : " + TimeTravel;
            result += "\n";

            return result;
        }
    }
}
