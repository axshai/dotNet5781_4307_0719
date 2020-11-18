using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    public class BusStation
    {
        private const int MIN_LAT = -90;  //For longitude and latitude ranges
        private const int MAX_LAT = 90;
        private const int MIN_LON = -180;
        private const int MAX_LON = 180;

        public BusStation(string code, double latit, double longit)//constructor
        {
            BusStationKey = code;
            Latitude = latit;
            Longitude = longit;
        }

        private string busStationKey; //Station number

        public string BusStationKey //"set" and "get" for Station number

        {
            get { return busStationKey; } //return the station number
            set
            {
                uint keyAsInt; // for Input test
                bool check;//for Input test
                check = uint.TryParse(value, out keyAsInt);//Input test
                if (value.Length < 1 || value.Length > 6)//The number of station must be 6 digits
                {
                    throw new ArgumentException("Station number must be between 1 and 6 digits!");
                    // if The number of station is not  6 digits
                }
                if (!check)//If the number is incorrect (Conversion to positive integer failed)
                {
                    throw new FormatException("A station number can contain only digits!");
                }
                busStationKey = value; //The station number is correct - we have been updated
            }
        }
        private double latitude;
        public double Latitude//"set" and "get" for latitude
        {
            get { return latitude; }////return the latitude
            set
            {
                if (value >= MIN_LAT && value <= MAX_LAT)//If the latitude is correct
                {
                    latitude = value;
                }
                else//If the latitude is incorrect
                {
                    throw new ArgumentException(String.Format("The number must be between <{0},{1}>", MIN_LAT, MAX_LAT));
                }
            }
        }

        private double longitude;
        public double Longitude //"set" and "get" for longitude
        {
            get { return longitude; }//return the longitude
            set
            {
                if (value >= MIN_LON && value <= MAX_LON)//If the longitude is correct
                {
                    longitude = value;
                }
                else//If the longitude is incorrect
                {
                    throw new ArgumentException(String.Format("The number must be between <{0},{1}>", MIN_LON, MAX_LON));
                }
            }
        }

       

        public override string ToString()//Override of ToString 
        {
            String result = String.Format("Bus Station Code: {0,-6}, {1,-16}°N  {2,-16}°E", BusStationKey, Latitude, Longitude); //Will contain the longitude and latitude lines in the requested format

            return result; 
        }
    }


}