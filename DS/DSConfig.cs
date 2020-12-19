using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
namespace DS
{
    public static class DSConfig
    {
        static int busInTravelCounter = 0;
        public static int BusInTravelCounter => ++busInTravelCounter;

        static int busLine = 0;
        public static int BusLineCounter => ++busLine;

        static int passengTravel = 0;
        public static int PassengTravelCounter => ++passengTravel;

    }
}
