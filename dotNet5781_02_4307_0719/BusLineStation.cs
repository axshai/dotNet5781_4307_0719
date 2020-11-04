using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class BusLineStation:BusStation

    {

          public BusLineStation(string code, double latit, double longit , string address = "" ,double previousLatit=-200, double previousLongit=-200, double time=0) :base ( code, latit,  longit,address)
        {
            Updatdistance(previousLatit, previousLongit);
            TimeTravel = time;
        }

        public void Updatdistance(double previousLatit=-200, double previousLongit = -200)
        {
            if (previousLatit != -200)
            {
                Distance = Math.Sqrt(Math.Pow((Latitude - previousLatit), 2) + Math.Pow((Longitude - previousLongit), 2));
            }
            else 
                Distance = 0;
        }



        public double Distance { get; set; }
        private double timeTravel;
        public double TimeTravel
        {
            set
            {
                if (value < 0) throw new Exception("time must be Positive");
                else
                    timeTravel = value;
            }

            get
            {
                return timeTravel;
            }

        }

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
