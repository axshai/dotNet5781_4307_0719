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
                
                LineArea = Area.CENTER,
                Id = DSConfig.BusLineCounter,
                IsExists = true


            });


            BusLines.Add(new BusLineDO
            {
                LineNumber = 82.ToString(),
               
                LineArea = Area.CENTER,
                Id = DSConfig.BusLineCounter,
                IsExists = true

            });

            BusLines.Add(new BusLineDO
            {
                LineNumber = 83.ToString(),
               
                LineArea = Area.CENTER,
                Id = DSConfig.BusLineCounter,
                IsExists = true

            });

            BusLines.Add(new BusLineDO
            {
                LineNumber = 838.ToString(),
              
                LineArea = Area.JERUSALEM,
                Id = DSConfig.BusLineCounter,
                IsExists = true

            });

            BusLines.Add(new BusLineDO
            {
                LineNumber = 12.ToString(),
               
                LineArea = Area.SHFELA,
                Id = DSConfig.BusLineCounter,
                IsExists = true

            });

            BusLines.Add(new BusLineDO
            {
                LineNumber = 212.ToString(),
              
                LineArea = Area.SHFELA,
                Id = DSConfig.BusLineCounter,
                IsExists = true

            });
            BusLines.Add(new BusLineDO
            {
                LineNumber = 319.ToString(),
            
                LineArea = Area.NORTH,
                Id = DSConfig.BusLineCounter,
                IsExists = true

            });

            BusLines.Add(new BusLineDO
            {
                LineNumber = 434.ToString(),
             
                LineArea = Area.SOUTH,
                Id = DSConfig.BusLineCounter,
                IsExists = true

            });
            BusLines.Add(new BusLineDO
            {
                LineNumber = 512.ToString(),
            
                LineArea = Area.WESTBANK,
                Id = DSConfig.BusLineCounter,
                IsExists = true

            });
            BusLines.Add(new BusLineDO
            {
                LineNumber = 516.ToString(),
              
                LineArea = Area.WESTBANK,
                Id = DSConfig.BusLineCounter,
                IsExists = true

            });

        }

        private static void InitBusStations()
        {
            BusStations.Add(new BusStationDO
            {
                StationKey = 123,
                StationName = "frankfurter/haunter",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
                
            }) ; ;

            BusStations.Add(new BusStationDO
            {
                StationKey = 456,
                StationName = "rotchild/zev kach",
                Longitude = 38,
                Latitude = 36,
                StationArea = Area.CENTER,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 789,
                StationName = "herzel/golda meir",
                Longitude = 37,
                Latitude = 37,
                StationArea = Area.CENTER,
                IsExists = true
            });
            
            BusStations.Add(new BusStationDO
            {
                StationKey = 91011,
                StationName = "hgefen/bni akiva",
                Longitude = 32,
                Latitude = 37,
                StationArea = Area.CENTER,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 111213,
                StationName = "eli cohen/hava loazki",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 141516,
                StationName = "hzra/hapnina ",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 171819,
                StationName = "ben lakish/yosi ben yoaezr",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.JERUSALEM,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 202122,
                StationName = "rebi akiva/rav ashiy",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.JERUSALEM,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 232425,
                StationName = "ben azy/rbi meir",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 262728,
                StationName = "yona hanvie/zchrya hanvie",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 293031,
                StationName = "yoram gaon/reshut hshidur",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 323334,
                StationName = "arik aynshtein/bery sahchruf",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 353637,
                StationName = "harv ovdia/harv ychak yosef",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.NORTH,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 383940,
                StationName = "harv shach/harv alyashiv",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.NORTH,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 414243,
                StationName = "harv chaim pinto/ baba saliy",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 444546,
                StationName = "harv shtynam/rabi yehusha",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 474849,
                StationName = "ali luzon/moshe chogeg",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.WESTBANK,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 505152,
                StationName = "hpoalim/hatnk",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.WESTBANK,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 535455,
                StationName = "mizrachi/hoz 77",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.WESTBANK,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 565758,
                StationName = "hamoshava/hasidy belz",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.WESTBANK,
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
                TravelTime = TimeSpan.FromMinutes(7)

            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 456,
                Station2Key = 789,
                Distance = 8,
                TravelTime = TimeSpan.FromMinutes(3)

            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 111213,
                Station2Key = 141516,
                Distance = 15,
                TravelTime = TimeSpan.FromMinutes(20)

            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 171819,
                Station2Key = 202122,
                Distance = 20,
                TravelTime = TimeSpan.FromMinutes(25)

            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 232425,
                Station2Key = 262728,
                Distance = 20,
                TravelTime = TimeSpan.FromMinutes(25)

            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 293031,
                Station2Key = 323334,
                Distance = 5,
                TravelTime = TimeSpan.FromMinutes(2)

            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 353637,
                Station2Key = 383940,
                Distance = 20,
                TravelTime = TimeSpan.FromMinutes(25)

            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key =414243,
                Station2Key = 444546,
                Distance = 12,
                TravelTime = TimeSpan.FromMinutes(11)

            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 474849,
                Station2Key = 505152,
                Distance = 5,
                TravelTime = TimeSpan.FromMinutes(2)

            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 535455,
                Station2Key = 565758,
                Distance = 30,
                TravelTime = TimeSpan.FromMinutes(45)

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

            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 111213,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 141516,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 171819,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 202122,
                Serial = 2,
                IsExist = true
            });

            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 232425,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 262728,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 293031,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 323334,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 353637,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 383940,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 414243,
                Serial = 1,
                IsExist = true
            });

            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey =444546,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 474849,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 505152,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 535455,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 565758,
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

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("16:00:00"),
                EndActivity = TimeSpan.Parse("18:00:00"),
                LineId = 3,
                frequency = 6,
                IsExists = true

            });
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("19:00:00"),
                EndActivity = TimeSpan.Parse("22:00:00"),
                LineId = 3,
                frequency = 6,
                IsExists = true

            });


            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("06:00:00"),
                EndActivity = TimeSpan.Parse("12:00:00"),
                LineId = 4,
                frequency = 4,
                IsExists = true

            });  

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("16:00:00"),
                EndActivity = TimeSpan.Parse("18:00:00"),
                LineId = 4,
                frequency = 3,
                IsExists = true

            });


            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("06:00:00"),
                EndActivity = TimeSpan.Parse("09:00:00"),
                LineId = 5,
                frequency = 10,
                IsExists = true

            });
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("21:00:00"),
                EndActivity = TimeSpan.Parse("23:00:00"),
                LineId = 5,
                frequency = 3,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("07:00:00"),
                EndActivity = TimeSpan.Parse("08:00:00"),
                LineId = 6,
                frequency = 1,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("18:00:00"),
                EndActivity = TimeSpan.Parse("19:00:00"),
                LineId = 6,
                frequency = 1,
                IsExists = true

            }); 
            
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("07:00:00"),
                EndActivity = TimeSpan.Parse("08:00:00"),
                LineId = 7,
                frequency = 1,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("18:00:00"),
                EndActivity = TimeSpan.Parse("19:00:00"),
                LineId = 7,
                frequency = 1,
                IsExists = true

            });
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("00:00:00"),
                EndActivity = TimeSpan.Parse("06:00:00"),
                LineId = 8,
                frequency = 3,
                IsExists = true

            });


            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("12:00:00"),
                EndActivity = TimeSpan.Parse("15:00:00"),
                LineId = 9,
                frequency = 10,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("15:00:00"),
                EndActivity = TimeSpan.Parse("17:00:00"),
                LineId = 9,
                frequency = 7,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("17:00:00"),
                EndActivity = TimeSpan.Parse("18:00:00"),
                LineId = 9,
                frequency = 6,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("06:00:00"),
                EndActivity = TimeSpan.Parse("09:00:00"),
                LineId = 10,
                frequency = 10,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("10:00:00"),
                EndActivity = TimeSpan.Parse("12:00:00"),
                LineId = 10,
                frequency = 5,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("13:00:00"),
                EndActivity = TimeSpan.Parse("17:00:00"),
                LineId = 10,
                frequency = 7,
                IsExists = true

            });

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("18:00:00"),
                EndActivity = TimeSpan.Parse("19:00:00"),
                LineId = 10,
                frequency = 1,
                IsExists = true

            });




        }

     

    }
}
