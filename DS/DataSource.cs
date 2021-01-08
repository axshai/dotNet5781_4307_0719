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
              
                LineArea = Area.CENTER,
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
            
                LineArea = Area.SHFELA,
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
            
                LineArea = Area.SOUTH,
                Id = DSConfig.BusLineCounter,
                IsExists = true

            });
            BusLines.Add(new BusLineDO
            {
                LineNumber = 516.ToString(),
              
                LineArea = Area.SOUTH,
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
            BusStations.Add(new BusStationDO
            {
                StationKey = 596061,
                StationName = "holnadya/hufman",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 626364,
                StationName = "baruch/hashem",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });


            BusStations.Add(new BusStationDO
            {
                StationKey = 656667,
                StationName = "einod/milvado",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 686970,
                StationName = "hashem/melech",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 717273,
                StationName = "lionel/messi",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });

            BusStations.Add(new BusStationDO //כאן אפשר לראשון (התחלה לשני
            {
                StationKey = 747576,
                StationName = "morenu/verabenu",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 777879,
                StationName = "rabi/nachman",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 808182,
                StationName = "yuosi/malul",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey =838485,
                StationName = "tate/alipop",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 868788,
                StationName = "ana/houshna",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 899091,
                StationName = "walla/mara",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 929394,
                StationName = "afilo/bhstara",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 959697,
                StationName = "shlimi/lalaush",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO //**//
            {
                StationKey = 102030,
                StationName = "hakol/tuv",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey =405060,
                StationName = "ken/lo",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 708090,
                StationName = "ken/lo",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey =100,
                StationName = "yuyu/uouo",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 101,
                StationName = "yaya/tore",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 102,
                StationName = "danielo/tam",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 103,
                StationName = "avarhn/avino",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 104,
                StationName = "yeild/process",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 105,
                StationName = "ref/xelmnt",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 105,
                StationName = "ref/xelmnt",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 106,
                StationName = "c#/c++",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 107,
                StationName = "payton/java",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 108,
                StationName = "aliali/halilu",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 109,
                StationName = "br/mizva",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 110,
                StationName = "yuonil/levngi",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 111,
                StationName = "chips/adama",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 112,
                StationName = "nh/kore",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 113,
                StationName = "hop/top",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 114,
                StationName = "yata/vysd",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 115,
                StationName = "ncdcd/bgf",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });

            ///
            BusStations.Add(new BusStationDO
            {
                StationKey = 120,
                StationName = "itamar/shay",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.CENTER,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 121,
                StationName = "itaminc/itamina",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 122,
                StationName = "nhy/olo",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 123,
                StationName = "falmgo/oil",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 124,
                StationName = "palomjuo/teq",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 125,
                StationName = "tatq/maloe",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 126,
                StationName = "rere/uouo",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 127,
                StationName = "levai/opo",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 128,
                StationName = "hanaal/levio",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 129,
                StationName = "aba/baba",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 130,
                StationName = "nana/banan",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SHFELA,
                IsExists = true
            });

            //
            BusStations.Add(new BusStationDO
            {
                StationKey = 170,
                StationName = "mbgra/jupfa",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 171,
                StationName = "makra/jipfa",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 172,
                StationName = "rehovoy/bnibarlk",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });

            BusStations.Add(new BusStationDO
            {
                StationKey = 173,
                StationName = "aligoali/golai",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,

                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 174,
                StationName = "yayahi/lali",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 175,
                StationName = "avoy/holoam",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 176,
                StationName = "gata/opl",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 177,
                StationName = "polgr/kastro",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 178,
                StationName = "renoar/polgo",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 179,
                StationName = "lioip/hgbk",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 180,
                StationName = "hzki/eliezer",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
                IsExists = true
            });
            BusStations.Add(new BusStationDO
            {
                StationKey = 181,
                StationName = "the/endbh",
                Longitude = 34,
                Latitude = 32,
                StationArea = Area.SOUTH,
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
                Station1Key = 262728,
                Station2Key = 293031,
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
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 456,
                Station2Key = 596061,
                Distance = 10,
                TravelTime = TimeSpan.FromMinutes(13)
            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 596061,
                Station2Key = 626364,
                Distance = 6,
                TravelTime = TimeSpan.FromMinutes(7)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 626364,
                Station2Key = 656667,
                Distance = 15,
                TravelTime = TimeSpan.FromMinutes(20)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 656667,
                Station2Key = 686970,
                Distance = 20,
                TravelTime = TimeSpan.FromMinutes(35)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key =686970,
                Station2Key = 717273,
                Distance = 30,
                TravelTime = TimeSpan.FromMinutes(5)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO //
            {
                Station1Key = 789,
                Station2Key = 747576,
                Distance = 30,
                TravelTime = TimeSpan.FromMinutes(45)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 747576,
                Station2Key = 777879,
                Distance = 60,
                TravelTime = TimeSpan.FromMinutes(75)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 717273,
                Station2Key = 747576,
                Distance = 60,
                TravelTime = TimeSpan.FromMinutes(75)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 777879,
                Station2Key = 808182,
                Distance = 10,
                TravelTime = TimeSpan.FromMinutes(12)
            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 808182,
                Station2Key = 838485,
                Distance = 12,
                TravelTime = TimeSpan.FromMinutes(14)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 838485,
                Station2Key = 868788,
                Distance = 10,
                TravelTime = TimeSpan.FromMinutes(11)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key =868788,
                Station2Key = 899091,
                Distance = 60,
                TravelTime = TimeSpan.FromMinutes(75)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 899091,
                Station2Key = 929394,
                Distance = 15,
                TravelTime = TimeSpan.FromMinutes(17)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 929394,
                Station2Key = 959697,
                Distance = 16,
                TravelTime = TimeSpan.FromMinutes(18)


            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 141516,
                Station2Key = 100,
                Distance = 16,
                TravelTime = TimeSpan.FromMinutes(18)


            });
          
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 100,
                Station2Key = 101,
                Distance = 100,
                TravelTime = TimeSpan.FromMinutes(150)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 101,
                Station2Key = 102,
                Distance = 50,
                TravelTime = TimeSpan.FromMinutes(60)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 102,
                Station2Key = 103,
                Distance = 10,
                TravelTime = TimeSpan.FromMinutes(9)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 103,
                Station2Key = 104,
                Distance = 10,
                TravelTime = TimeSpan.FromMinutes(9)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 104,
                Station2Key = 105,
                Distance = 98,
                TravelTime = TimeSpan.FromMinutes(100)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 105,
                Station2Key = 106,
                Distance = 15,
                TravelTime = TimeSpan.FromMinutes(16)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 106,
                Station2Key = 107,
                Distance = 15,
                TravelTime = TimeSpan.FromMinutes(18)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 107,
                Station2Key = 108,
                Distance = 18,
                TravelTime = TimeSpan.FromMinutes(20)


            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO ////////////
            {
                Station1Key = 171819,
                Station2Key = 707172,
                Distance = 18,
                TravelTime = TimeSpan.FromMinutes(20)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 202122,
                Station2Key = 100,
                Distance = 10,
                TravelTime = TimeSpan.FromMinutes(23)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key =100,
                Station2Key =808182,
                Distance = 19,
                TravelTime = TimeSpan.FromMinutes(30)


            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 868788,
                Station2Key =111,
                Distance = 2,
                TravelTime = TimeSpan.FromMinutes(1)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 111,
                Station2Key = 112,
                Distance = 5,
                TravelTime = TimeSpan.FromMinutes(7)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 112,
                Station2Key = 113,
                Distance = 20,
                TravelTime = TimeSpan.FromMinutes(30)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 113,
                Station2Key = 114,
                Distance = 10,
                TravelTime = TimeSpan.FromMinutes(11)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 114,
                Station2Key = 115,
                Distance = 2,
                TravelTime = TimeSpan.FromMinutes(1)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 120,
                Station2Key = 121,
                Distance = 14,
                TravelTime = TimeSpan.FromMinutes(17)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 121,
                Station2Key = 122,
                Distance = 14,
                TravelTime = TimeSpan.FromMinutes(17)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 122,
                Station2Key = 123,
                Distance = 19,
                TravelTime = TimeSpan.FromMinutes(21)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 123,
                Station2Key = 124,
                Distance = 20,
                TravelTime = TimeSpan.FromMinutes(23)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 124,
                Station2Key = 125,
                Distance = 27,
                TravelTime = TimeSpan.FromMinutes(30)


            });
               AllConsecutiveStations.Add(new ConsecutiveStationsDO
                 {
                     Station1Key = 125,
                     Station2Key = 126,
                     Distance = 14,
                     TravelTime = TimeSpan.FromMinutes(17)


                 });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 126,
                Station2Key = 127,
                Distance = 14,
                TravelTime = TimeSpan.FromMinutes(17)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 127,
                Station2Key = 128,
                Distance = 30,
                TravelTime = TimeSpan.FromMinutes(40)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 128,
                Station2Key = 129,
                Distance = 19,
                TravelTime = TimeSpan.FromMinutes(21)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 129,
                Station2Key = 130,
                Distance = 14,
                TravelTime = TimeSpan.FromMinutes(17)


            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 262728,
                Station2Key = 120,
                Distance = 30,
                TravelTime = TimeSpan.FromMinutes(42)


            });
            //323334
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 323334,
                Station2Key = 127,
                Distance = 3,
                TravelTime = TimeSpan.FromMinutes(4)


            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 130,
                Station2Key = 120,
                Distance = 30,
                TravelTime = TimeSpan.FromMinutes(42)
            });

            //
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 383940,
                Station2Key = 232425,
                Distance = 30,
                TravelTime = TimeSpan.FromMinutes(42)
            });

            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 323334,
                Station2Key =122,
                Distance = 30,
                TravelTime = TimeSpan.FromMinutes(42)
            });


            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 170,
                Station2Key = 171,
                Distance = 30,
                TravelTime = TimeSpan.FromMinutes(42)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 171,
                Station2Key = 172,
                Distance = 30,
                TravelTime = TimeSpan.FromMinutes(42)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 172,
                Station2Key = 173,
                Distance = 57,
                TravelTime = TimeSpan.FromMinutes(65)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 173,
                Station2Key = 174,
                Distance = 10,
                TravelTime = TimeSpan.FromMinutes(13)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 174,
                Station2Key = 175,
                Distance = 13,
                TravelTime = TimeSpan.FromMinutes(26)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 175,
                Station2Key = 176,
                Distance = 70,
                TravelTime = TimeSpan.FromMinutes(90)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 176,
                Station2Key = 177,
                Distance = 50,
                TravelTime = TimeSpan.FromMinutes(60)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 177,
                Station2Key = 178,
                Distance = 13,
                TravelTime = TimeSpan.FromMinutes(14)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 178,
                Station2Key = 179,
                Distance = 34,
                TravelTime = TimeSpan.FromMinutes(45)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 179,
                Station2Key = 180,
                Distance = 50,
                TravelTime = TimeSpan.FromMinutes(60)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key =444546,
                Station2Key = 171,
                Distance = 40,
                TravelTime = TimeSpan.FromMinutes(50)
            });
            //
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 505152,
                Station2Key = 170,
                Distance = 50,
                TravelTime = TimeSpan.FromMinutes(60)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 565758,
                Station2Key = 170,
                Distance = 50,
                TravelTime = TimeSpan.FromMinutes(60)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 172,
                Station2Key = 176,
                Distance = 6,
                TravelTime = TimeSpan.FromMinutes(12)
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 180,
                Station2Key = 181,
                Distance = 6,
                TravelTime = TimeSpan.FromMinutes(12)
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
                LineId = 1,
                StationKey = 596061,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 626364,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 656667,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 686970,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 717273,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 747576,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 777879,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 808182,
                Serial = 10,
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
                LineId = 2,
                StationKey = 747576,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 777879,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 808182,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey =838485,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 868788,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 899091,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey =929394,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 959697,
                Serial = 10,
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
                LineId = 3,
                StationKey = 100,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 101,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 102,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 103,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 104,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 105,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 106,
                Serial = 9,
                IsExist = true
            });

            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 107,
                Serial = 10,
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
                LineId = 4,
                StationKey = 100,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 808182,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 838485,
                Serial = 4,
                IsExist = true
            });

            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey =868788,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 111,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 112,
                Serial = 7,
                IsExist = true
            });

            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 113,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 114,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 115,
                Serial = 10,
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
                LineId = 5,
                StationKey = 120,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 121,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 122,
                Serial = 5,
                IsExist = true
            });

            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 123,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 124,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 125,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 126,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 127,
                Serial = 10,
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
                LineId = 6,
                StationKey = 127,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 128,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 129,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 130,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 120,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 121,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 122,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 123,
                Serial = 10,
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
                LineId = 7,
                StationKey = 232425,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 262728,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey =293031,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 323334,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 122,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 123,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 124,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 125,
                Serial = 10,
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
                LineId = 8,
                StationKey = 171,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 172,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 173,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 174,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 175,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 176,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 177,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 178,
                Serial = 10,
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
                LineId = 9,
                StationKey = 170,
                Serial = 3,
                IsExist = true
            });

            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 171,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 172,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 173,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 174,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 175,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 176,
                Serial = 9,
                IsExist = true
            });

            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 177,
                Serial = 10,
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

            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 170,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 171,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 172,
                Serial = 5,
                IsExist = true
            }); 
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 176,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 177,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 178,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 179,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 180,
                Serial = 10,
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
