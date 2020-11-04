using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class BusStation
    {
        private const int MIN_LAT = -90;
        private const int MAX_LAT = 90;
        private const int MIN_LON = -180;
        private const int MAX_LON = 180;

        private string busStationKey;

        public string BusStationKey
        {
            get { return busStationKey; }
            set
            {
                uint check1;
                bool check;
                check = uint.TryParse(value, out check1);
                if (value.Length<1|| value.Length >6||!check)
                {
                    throw new Exception ("enter only digits");
                }
                BusStationKey = value;
            }
        }
        private double latitude;
        public double Latitude
        {
            get { return latitude; }
            set
            {
                if (value >= MIN_LAT && value <= MAX_LAT)
                {
                    latitude = value;
                }
                else
                {
                    throw new ArgumentException( String.Format("The number must be <{0},{1}>", MIN_LAT, MAX_LAT));
                }
            }
        }

        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            set
            {
                if (value >= MIN_LON && value <= MAX_LON)
                {
                    longitude = value;
                }
                else
                {
                    throw new ArgumentException(
                            String.Format("The number must be <{0},{1}>", MIN_LON, MAX_LON));
                }
            }
        }
        public String Address { get; set; }

        public override string ToString()
        {
            String result = String.Format(
                "------Bus Station {0} ------ \n" +
                "Longitude: {1} N" +
                "Latitude: {2} E ", BusStationKey, Longitude, Latitude);

            return result;
        }
    }
}

