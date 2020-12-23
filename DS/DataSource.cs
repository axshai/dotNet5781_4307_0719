using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
namespace DS
{



    public static class DataSource
    {

        static DataSource()
        {
            Buses = new List<BusDO>();
            BusesInTravel = new List<BusInTravelDO>();
            BusLines = new List<BusLineDO>();
            BusLineSchedules = new List<BusLineScheduleDO>();
            BusStations = new List<BusStationDO>();
            AllConsecutiveStations = new List<ConsecutiveStationsDO>();
            LineStations = new List<LineStationDO>();
            PassengerTravels = new List<PassengerTravelDO>();
            Users = new List<UserDO>();
            InitBusLines();
            InitBusStations();
            InitConsecutiveStations();
            InitLineStations();
            InitBusLineSchedules();
        }



        public static List<BusDO> Buses;
        public static List<BusInTravelDO> BusesInTravel;
        public static List<BusLineDO> BusLines;
        public static List<BusLineScheduleDO> BusLineSchedules;
        public static List<BusStationDO> BusStations;
        public static List<ConsecutiveStationsDO> AllConsecutiveStations;
        public static List<LineStationDO> LineStations;
        public static List<PassengerTravelDO> PassengerTravels;
        public static List<UserDO> Users;

        private static void InitBusLines()
        {
            BusLines.Add(new BusLineDO
            {
                LineNumber = 66.ToString(),
                FirstStationKey = 123,
                LastStationKey = 456,
                LineArea = Area.CENTER,
                Id = DSConfig.BusLineCounter,
                IsExists = true


            });

            BusLines.Add(new BusLineDO
            {
                LineNumber = 82.ToString(),
                FirstStationKey = 456,
                LastStationKey = 789,
                LineArea = Area.CENTER,
                Id = DSConfig.BusLineCounter,
                IsExists = true

            });
        }

        private static void InitBusStations()
        {
            BusStations.Add(new BusStationDO
            {
                StationKey = 123,
                StationName = "frankfurter",
                Longitude = 34,
                Latitude = 32,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 456,
                StationName = "rotchild",
                Longitude = 38,
                Latitude = 36,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 789,
                StationName = "herzel",
                Longitude = 37,
                Latitude = 37,
                IsExists = true
            });
        }

        private static void InitConsecutiveStations()
        {
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 123,
                Station2Key = 456,
                Distance = 10,
                TravelTime = TimeSpan.FromMinutes(3)

            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 456,
                Station2Key = 789,
                Distance = 8,
                TravelTime = TimeSpan.FromMinutes(2)

            });
        }

        private static void InitLineStations()
        {
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 123,
                Serial = 1,
                IsExist=true
            });

            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 456,
                Serial = 2,
                IsExist = true
            });

            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 456,
                Serial = 1,
                IsExist = true
            });

            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 789,
                Serial = 2,
                IsExist = true
            });
        }

        private static void InitBusLineSchedules()
        {
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("10:00:00"),
                EndActivity = TimeSpan.Parse("12:00:00"),
                LineId = 1,
                frequency = 5,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("12:00:00"),
                EndActivity = TimeSpan.Parse("14:00:00"),
                LineId = 1,
                frequency = 10,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("12:00:00"),
                EndActivity = TimeSpan.Parse("15:00:00"),
                LineId = 2,
                frequency = 10,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("15:00:00"),
                EndActivity = TimeSpan.Parse("17:00:00"),
                LineId = 2,
                frequency = 7,
                IsExists = true

            });
        }

    }
}
