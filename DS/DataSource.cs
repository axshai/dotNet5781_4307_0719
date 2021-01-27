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
            BusesInTravel = new List<BusInTravelDO>();
            BusLines = new List<BusLineDO>();
            BusLineSchedules = new List<BusLineScheduleDO>();
            BusStations = new List<BusStationDO>();
            AllConsecutiveStations = new List<ConsecutiveStationsDO>();
            LineStations = new List<LineStationDO>();
            
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
                Id = 1,
                LineNumber = "11",
                LineArea = Area.NORTH,
                IsExists = true
            });
            BusLines.Add(new BusLineDO
            {
                Id = 2,
                LineNumber = "22",
                LineArea = Area.SOUTH,
                IsExists = true
            });
            BusLines.Add(new BusLineDO
            {
                Id = 3,
                LineNumber = "33",
                LineArea = Area.SHFELA,
                IsExists = true
            });
            BusLines.Add(new BusLineDO
            {
                Id = 4,
                LineNumber = "47",
                LineArea = Area.CENTER,
                IsExists = true
            });
            BusLines.Add(new BusLineDO
            {
                Id = 5,
                LineNumber = "15",
                LineArea = Area.JERUSALEM,
                IsExists = true
            });
            BusLines.Add(new BusLineDO
            {
                Id = 6,
                LineNumber = "426",
                LineArea = Area.GENERAL,
                IsExists = true
            });
            BusLines.Add(new BusLineDO
            {
                Id = 7,
                LineNumber = "346",
                LineArea = Area.GENERAL,
                IsExists = true
            });
            BusLines.Add(new BusLineDO
            {
                Id = 8,
                LineNumber = "189",
                LineArea = Area.GENERAL,
                IsExists = true
            });
            BusLines.Add(new BusLineDO
            {
                Id = 9,
                LineNumber = "66",
                LineArea = Area.NORTH,
                IsExists = true
            });
            BusLines.Add(new BusLineDO
            {
                Id = 10,
                LineNumber = "947",
                LineArea = Area.GENERAL,
                IsExists = true
            });
        }
      
        private static void InitBusStations()
        {
            BusStations.Add(new BusStationDO
            {
                StationKey = 11111,
                Latitude = 33.544,
                Longitude = 32.545,
                StationName = "האומן/ברעם",
                IsExists = true,
                StationArea = Area.NORTH
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 11122,
                Latitude = 23.344,
                Longitude = 32.465,
                StationName = "יד חרוצים/תלפיות",
                IsExists = true,
                StationArea = Area.NORTH
            }
             );
            BusStations.Add(new BusStationDO
            {
                StationKey = 11133,
                Latitude = 32.455,
                Longitude = 43.455,
                StationName = "הפלמח/ההגנה",
                IsExists = true,
                StationArea = Area.NORTH
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 11144,
                Latitude = 32.354,
                Longitude = 21.875,
                StationName = "שערי יושר/הרב שקופ",
                IsExists = true,
                StationArea = Area.NORTH
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 11155,
                Latitude = 34.564,
                Longitude = 24.321,
                StationName = "קצות החושן/הרב הלר",
                IsExists = true,
                StationArea = Area.NORTH
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 11166,
                Latitude = 23.975,
                Longitude = 43.565,
                StationName = "נתיבות המשפט/ליסא",
                IsExists = true,
                StationArea = Area.NORTH
            }
             );
            BusStations.Add(new BusStationDO
            {
                StationKey = 11177,
                Latitude = 23.345,
                Longitude = 43.454,
                StationName = "בית חולים איכילוב",
                IsExists = true,
                StationArea = Area.NORTH
            }
             );
            BusStations.Add(new BusStationDO
            {
                StationKey = 11199,
                Latitude = 26.876,
                Longitude = 23.132,
                StationName = "בן גוריון/מנחם בגין",
                IsExists = true,
                StationArea = Area.NORTH
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 11100,
                Latitude = 23.454,
                Longitude = 45.332,
                StationName = "יצחק רבין/השומר הצעיר",
                IsExists = true,
                StationArea = Area.NORTH
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 22111,
                Latitude = 25.655,
                Longitude = 32.455,
                StationName = "המעפילים/הלחי",
                IsExists = true,
                StationArea = Area.SOUTH
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 22222,
                Latitude = 32.453,
                Longitude = 31.234,
                StationName = "העמל/המלאכה",
                IsExists = true,
                StationArea = Area.SOUTH
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 22333,
                Latitude = 46.432,
                Longitude = 24.765,
                StationName = "המכבים/לוחמי הגטו",
                IsExists = true,
                StationArea = Area.SOUTH
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 22444,
                Latitude = 32.455,
                Longitude = 31.455,
                StationName = "בן עזאי/ריש לקיש",
                IsExists = true,
                StationArea = Area.SOUTH
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 22555,
                Latitude = 43.355,
                Longitude = 34.864,
                StationName = "חברון/גבעת מרדכי",
                IsExists = true,
                StationArea = Area.SOUTH
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 22666,
                Latitude = 41.24,
                Longitude = 30.531,
                StationName = "חסידי בעלזא/שר שלום",
                IsExists = true,
                StationArea = Area.SOUTH
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 22777,
                Latitude = 33.333,
                Longitude = 22.222,
                StationName = "שפת אמת/בני מנחם",
                IsExists = true,
                StationArea = Area.SOUTH
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 22888,
                Latitude = 21.876,
                Longitude = 31.25,
                StationName = "זבוטינסקי/איכילוב",
                IsExists = true,
                StationArea = Area.SOUTH
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 22999,
                Latitude = 41.79,
                Longitude = 24.314,
                StationName = "הרצל/אחד העם",
                IsExists = true,
                StationArea = Area.SOUTH
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 22000,
                Latitude = 33.876,
                Longitude = 33.222,
                StationName = "מונטיפיורי/ההסתדרות",
                IsExists = true,
                StationArea = Area.SOUTH
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 11188,
                Latitude = 44.786,
                Longitude = 29.865,
                StationName = "המרכולים/יוני נתניהו",
                IsExists = true,
                StationArea = Area.NORTH
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 43331,
                Latitude = 23.456,
                Longitude = 43.767,
                StationName = "ההגנה/יגאל אלון",
                IsExists = true,
                StationArea = Area.CENTER
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 43332,
                Latitude = 45.212,
                Longitude = 33.654,
                StationName = "מרגולין/הרב פרנקל",
                IsExists = true,
                StationArea = Area.CENTER
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 43333,
                Latitude = 32.543,
                Longitude = 24.532,
                StationName = "הארבעה/מעלה לבונה",
                IsExists = true,
                StationArea = Area.CENTER
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 43334,
                Latitude = 22.655,
                Longitude = 22.333,
                StationName = "יהדות ליטא/לוחמי הגטו",
                IsExists = true,
                StationArea = Area.CENTER
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 43335,
                Latitude = 23.567,
                Longitude = 23.644,
                StationName = "מסקין/ההעצמאות",
                IsExists = true,
                StationArea = Area.CENTER
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 43336,
                Latitude = 22.222,
                Longitude = 21.222,
                StationName = "פרנקפורטר/רוטשילד",
                IsExists = true,
                StationArea = Area.CENTER
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 43337,
                Latitude = 44.443,
                Longitude = 32.232,
                StationName = "שפירא/הרב וולף",
                IsExists = true,
                StationArea = Area.CENTER
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 43338,
                Latitude = 32.263,
                Longitude = 32.389,
                StationName = "פנקס/בר כוכבא",
                IsExists = true,
                StationArea = Area.CENTER
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 23339,
                Latitude = 34.123,
                Longitude = 32.421,
                StationName = "הרב לנדא/רבי עקיבא",
                IsExists = true,
                StationArea = Area.CENTER
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 43330,
                Latitude = 43.361,
                Longitude = 22.467,
                StationName = "חבקוק/יונה הנביא",
                IsExists = true,
                StationArea = Area.CENTER
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 54321,
                Latitude = 32.733,
                Longitude = 21.354,
                StationName = "אנילביץ/בן זכאי",
                IsExists = true,
                StationArea = Area.JERUSALEM
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 54322,
                Latitude = 32.563,
                Longitude = 31.455,
                StationName = "יד חרוצים/המלאכה",
                IsExists = true,
                StationArea = Area.JERUSALEM
            }
             );
            BusStations.Add(new BusStationDO
            {
                StationKey = 54323,
                Latitude = 32.785,
                Longitude = 33.222,
                StationName = "זהב מרדכי/איתרי",
                IsExists = true,
                StationArea = Area.JERUSALEM
            }
             );
            BusStations.Add(new BusStationDO
            {
                StationKey = 54324,
                Latitude = 24.653,
                Longitude = 32.456,
                StationName = "מיזרחי/אגודת ישראל",
                IsExists = true,
                StationArea = Area.JERUSALEM
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 54325,
                Latitude = 32.465,
                Longitude = 33.556,
                StationName = "האומן/שלום שטיסל",
                IsExists = true,
                StationArea = Area.JERUSALEM
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 54326,
                Latitude = 34.755,
                Longitude = 32.246,
                StationName = "דיסקין/הרב סורוצקין",
                IsExists = true,
                StationArea = Area.JERUSALEM
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 54327,
                Latitude = 43.567,
                Longitude = 33.234,
                StationName = "יחזקאל/גולדה מאיר",
                IsExists = true,
                StationArea = Area.JERUSALEM
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 54328,
                Latitude = 22.332,
                Longitude = 22.223,
                StationName = "כיכר השבת/מאה שערים",
                IsExists = true,
                StationArea = Area.JERUSALEM
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 54329,
                Latitude = 42.445,
                Longitude = 32.467,
                StationName = "יפו/שטראוס",
                IsExists = true,
                StationArea = Area.JERUSALEM
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 54320,
                Latitude = 32.456,
                Longitude = 43.578,
                StationName = "אחד העם/יוסף נקר",
                IsExists = true,
                StationArea = Area.JERUSALEM
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 64791,
                Latitude = 43.785,
                Longitude = 43.257,
                StationName = "חיים עוזר/נפתלין",
                IsExists = true,
                StationArea = Area.SHFELA
            }
             );
            BusStations.Add(new BusStationDO
            {
                StationKey = 65432,
                Latitude = 32.466,
                Longitude = 33.657,
                StationName = "יונתן לוי/הגן הבוטני",
                IsExists = true,
                StationArea = Area.SHFELA
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 65433,
                Latitude = 23.678,
                Longitude = 43.567,
                StationName = "קרית הממשלה/הסנימטק",
                IsExists = true,
                StationArea = Area.SHFELA
            }
             );
            BusStations.Add(new BusStationDO
            {
                StationKey = 65844,
                Latitude = 23.653,
                Longitude = 22.909,
                StationName = "בן ציון גליס/ בגין",
                IsExists = true,
                StationArea = Area.SHFELA
            }
             );
            BusStations.Add(new BusStationDO
            {
                StationKey = 64545,
                Latitude = 33.333,
                Longitude = 43.444,
                StationName = "בלפור/סלומינסקי",
                IsExists = true,
                StationArea = Area.SHFELA
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 68576,
                Latitude = 41.245,
                Longitude = 40.622,
                StationName = "נחל איילון/הירקון",
                IsExists = true,
                StationArea = Area.SHFELA
            }
             );
            BusStations.Add(new BusStationDO
            {
                StationKey = 63957,
                Latitude = 39.353,
                Longitude = 38.576,
                StationName = "הזית/ירושלים",
                IsExists = true,
                StationArea = Area.SHFELA
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 63488,
                Latitude = 32.678,
                Longitude = 38.999,
                StationName = "שטמפפר/ההסתדרות",
                IsExists = true,
                StationArea = Area.SHFELA
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 68579,
                Latitude = 29.685,
                Longitude = 30.466,
                StationName = "הגרא/שטפנשט",
                IsExists = true,
                StationArea = Area.SHFELA
            }
          );
            BusStations.Add(new BusStationDO
            {
                StationKey = 61230,
                Latitude = 33.897,
                Longitude = 37.654,
                StationName = "נחלי הבשן/נחל דן",
                IsExists = true,
                StationArea = Area.SHFELA
            }
               );
            BusStations.Add(new BusStationDO
            {
                StationKey = 12432,
                Latitude = 23.662,
                Longitude = 32.289,
                StationName = "האצל/דוד רמז",
                IsExists = true,
                StationArea = Area.NORTH
            }
            );
            BusStations.Add(new BusStationDO
            {
                StationKey = 53268,
                Latitude = 43.212,
                Longitude = 23.456,
                StationName = "השושנים/ההלכה",
                IsExists = true,
                StationArea = Area.SOUTH
            }
            );
            BusStations.Add(new BusStationDO
            {
                StationKey = 64278,
                Latitude = 23.564,
                Longitude = 43.235,
                StationName = "לה גוורדיה/מרגולין",
                IsExists = true,
                StationArea = Area.CENTER
            }
             );
            BusStations.Add(new BusStationDO
            {
                StationKey = 46764,
                Latitude = 22.455,
                Longitude = 33.245,
                StationName = "היכל מנורה/יגאל אלון",
                IsExists = true,
                StationArea = Area.JERUSALEM
            }
                );
            BusStations.Add(new BusStationDO
            {
                StationKey = 63427,
                Latitude = 23.567,
                Longitude = 43.246,
                StationName = "הבורסה/גלעדי",
                IsExists = true,
                StationArea = Area.SHFELA
            }
           );
            BusStations.Add(new BusStationDO
            {
                StationKey = 85399,
                Latitude = 33.454,
                Longitude = 21.356,
                StationName = "אילת השחר/הענבל",
                IsExists = true,
                StationArea = Area.WESTBANK
            }
              );
            BusStations.Add(new BusStationDO
            {
                StationKey = 54789,
                Latitude = 33.332,
                Longitude = 22.564,
                StationName = "משה שרת/לוי אשכול",
                IsExists = true,
                StationArea = Area.WESTBANK
            }
               );
        }
        
        private static void InitConsecutiveStations()
        {
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11111,
                Station2Key = 11155,
                Distance = 3,
                TravelTime = TimeSpan.Parse("00:23:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11122,
                Station2Key = 11155,
                Distance = 2.3,
                TravelTime = TimeSpan.Parse("00:12:23"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11111,
                Station2Key = 11122,
                Distance = 3.2,
                TravelTime = TimeSpan.Parse("00:13:43"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11133,
                Station2Key = 11111,
                Distance = 2.2,
                TravelTime = TimeSpan.Parse("00:04:30"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11144,
                Station2Key = 11133,
                Distance = 5,
                TravelTime = TimeSpan.Parse("00:12:03"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11166,
                Station2Key = 11144,
                Distance = 1.3,
                TravelTime = TimeSpan.Parse("00:04:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11177,
                Station2Key = 11166,
                Distance = 2,
                TravelTime = TimeSpan.Parse("00:04:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11199,
                Station2Key = 11177,
                Distance = 3.6,
                TravelTime = TimeSpan.Parse("00:05:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11188,
                Station2Key = 11199,
                Distance = 2.1,
                TravelTime = TimeSpan.Parse("00:09:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11100,
                Station2Key = 11188,
                Distance = 5.1,
                TravelTime = TimeSpan.Parse("00:10:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 22111,
                Station2Key = 22999,
                Distance = 3,
                TravelTime = TimeSpan.Parse("00:06:23"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 22999,
                Station2Key = 22000,
                Distance = 2.1,
                TravelTime = TimeSpan.Parse("00:04:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 22222,
                Station2Key = 22111,
                Distance = 1.2,
                TravelTime = TimeSpan.Parse("00:07:03"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 22333,
                Station2Key = 22222,
                Distance = 4.8,
                TravelTime = TimeSpan.Parse("00:12:21"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 22444,
                Station2Key = 22333,
                Distance = 3.5,
                TravelTime = TimeSpan.Parse("00:07:34"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 22555,
                Station2Key = 22444,
                Distance = 3,
                TravelTime = TimeSpan.Parse("00:08:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 22666,
                Station2Key = 22555,
                Distance = 2.5,
                TravelTime = TimeSpan.Parse("00:11:11"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 22777,
                Station2Key = 22666,
                Distance = 5.1,
                TravelTime = TimeSpan.Parse("00:12:31"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 22888,
                Station2Key = 22777,
                Distance = 2.6,
                TravelTime = TimeSpan.Parse("00:03:45"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 68579,
                Station2Key = 61230,
                Distance = 3,
                TravelTime = TimeSpan.Parse("00:03:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 64791,
                Station2Key = 68579,
                Distance = 3.2,
                TravelTime = TimeSpan.Parse("00:04:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 65432,
                Station2Key = 64791,
                Distance = 4.1,
                TravelTime = TimeSpan.Parse("00:06:46"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 65433,
                Station2Key = 65432,
                Distance = 2.4,
                TravelTime = TimeSpan.Parse("00:07:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 65844,
                Station2Key = 65433,
                Distance = 1,
                TravelTime = TimeSpan.Parse("00:01:30"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 64545,
                Station2Key = 65844,
                Distance = 5.2,
                TravelTime = TimeSpan.Parse("00:13:20"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 68576,
                Station2Key = 64545,
                Distance = 3.7,
                TravelTime = TimeSpan.Parse("00:06:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 63957,
                Station2Key = 68576,
                Distance = 2,
                TravelTime = TimeSpan.Parse("00:04:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 63488,
                Station2Key = 63957,
                Distance = 2,
                TravelTime = TimeSpan.Parse("00:04:20"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 43331,
                Station2Key = 43332,
                Distance = 2,
                TravelTime = TimeSpan.Parse("00:04:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 43333,
                Station2Key = 43331,
                Distance = 3.1,
                TravelTime = TimeSpan.Parse("00:05:30"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 43334,
                Station2Key = 43333,
                Distance = 2.5,
                TravelTime = TimeSpan.Parse("00:09:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 43335,
                Station2Key = 43334,
                Distance = 3.1,
                TravelTime = TimeSpan.Parse("00:06:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 43336,
                Station2Key = 43335,
                Distance = 3.8,
                TravelTime = TimeSpan.Parse("00:06:02"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 43337,
                Station2Key = 43336,
                Distance = 4,
                TravelTime = TimeSpan.Parse("00:04:33"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 43338,
                Station2Key = 43337,
                Distance = 9.8,
                TravelTime = TimeSpan.Parse("00:12:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 23339,
                Station2Key = 43338,
                Distance = 4.7,
                TravelTime = TimeSpan.Parse("00:10:39"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 43330,
                Station2Key = 23339,
                Distance = 1.6,
                TravelTime = TimeSpan.Parse("00:01:50"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 54329,
                Station2Key = 54321,
                Distance = 3.2,
                TravelTime = TimeSpan.Parse("00:04:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 54322,
                Station2Key = 54329,
                Distance = 3.4,
                TravelTime = TimeSpan.Parse("00:03:02"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 54323,
                Station2Key = 54322,
                Distance = 2.7,
                TravelTime = TimeSpan.Parse("00:04:03"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 54324,
                Station2Key = 54323,
                Distance = 3,
                TravelTime = TimeSpan.Parse("00:08:56"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 54325,
                Station2Key = 54324,
                Distance = 1.2,
                TravelTime = TimeSpan.Parse("00:01:35"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 54326,
                Station2Key = 54325,
                Distance = 7.9,
                TravelTime = TimeSpan.Parse("00:14:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 54327,
                Station2Key = 54326,
                Distance = 4.2,
                TravelTime = TimeSpan.Parse("00:05:20"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 54328,
                Station2Key = 54327,
                Distance = 3.6,
                TravelTime = TimeSpan.Parse("00:04:40"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 54320,
                Station2Key = 54328,
                Distance = 2.4,
                TravelTime = TimeSpan.Parse("00:02:50"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11188,
                Station2Key = 54320,
                Distance = 28.6,
                TravelTime = TimeSpan.Parse("00:46:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 64545,
                Station2Key = 43336,
                Distance = 25,
                TravelTime = TimeSpan.Parse("00:50:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 65432,
                Station2Key = 63488,
                Distance = 3.4,
                TravelTime = TimeSpan.Parse("00:03:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 22444,
                Station2Key = 11100,
                Distance = 32,
                TravelTime = TimeSpan.Parse("01:00:05"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11144,
                Station2Key = 11122,
                Distance = 2.6,
                TravelTime = TimeSpan.Parse("00:03:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11111,
                Station2Key = 11144,
                Distance = 2.1,
                TravelTime = TimeSpan.Parse("00:03:04"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11155,
                Station2Key = 11133,
                Distance = 3,
                TravelTime = TimeSpan.Parse("00:06:40"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11166,
                Station2Key = 11155,
                Distance = 1.8,
                TravelTime = TimeSpan.Parse("03:23:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11100,
                Station2Key = 11199,
                Distance = 6.8,
                TravelTime = TimeSpan.Parse("00:11:32"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 11188,
                Station2Key = 11100,
                Distance = 2.9,
                TravelTime = TimeSpan.Parse("00:07:23"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 68576,
                Station2Key = 11100,
                Distance = 18.4,
                TravelTime = TimeSpan.Parse("00:35:00"),
            });
            AllConsecutiveStations.Add(new ConsecutiveStationsDO
            {
                Station1Key = 43337,
                Station2Key = 63488,
                Distance = 23,
                TravelTime = TimeSpan.Parse("00:45:00"),
            });
        }
        
        private static void InitLineStations()
        {
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 11111,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 11155,
                Serial = 10,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 11122,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 11133,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 11144,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 11166,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 11177,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 11199,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 11188,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 1,
                StationKey = 11100,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 22111,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 22999,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 22000,
                Serial = 10,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 22222,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 22333,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 22444,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 22555,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 22666,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 22777,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 2,
                StationKey = 22888,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 68579,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 61230,
                Serial = 10,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 64791,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 65432,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 65433,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 65844,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 64545,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 68576,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 63957,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 3,
                StationKey = 63488,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 43331,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 43332,
                Serial = 10,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 43333,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 43334,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 43335,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 43336,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 43337,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 43338,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 23339,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 4,
                StationKey = 43330,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 54329,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 54321,
                Serial = 10,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 54322,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 54323,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 54324,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 54325,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 54326,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 54327,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 54328,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 5,
                StationKey = 54320,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 11100,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 11188,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 54320,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 54328,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 54327,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 54326,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 54325,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 54324,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 54323,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 6,
                StationKey = 54322,
                Serial = 10,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 43333,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 43331,
                Serial = 10,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 43334,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 43335,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 43336,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 64545,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 68576,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 63957,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 63488,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 7,
                StationKey = 65432,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 11177,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 11166,
                Serial = 10,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 11199,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 11188,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 11100,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 22444,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 22555,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 22666,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 22777,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 8,
                StationKey = 22888,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 11144,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 11122,
                Serial = 10,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 11111,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 11133,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 11155,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 11166,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 11177,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 11199,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 11100,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 9,
                StationKey = 11188,
                Serial = 1,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 11188,
                Serial = 9,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 11199,
                Serial = 10,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 11100,
                Serial = 8,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 68576,
                Serial = 7,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 63957,
                Serial = 6,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 63488,
                Serial = 5,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 43337,
                Serial = 4,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 43338,
                Serial = 3,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 23339,
                Serial = 2,
                IsExist = true
            });
            LineStations.Add(new LineStationDO
            {
                LineId = 10,
                StationKey = 43330,
                Serial = 1,
                IsExist = true
            });
        }
        
        private static void InitBusLineSchedules()
        {
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("07:00:00"),
                EndActivity = TimeSpan.Parse("19:00:00"),
                frequency = 15,
                LineId = 1,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("06:00:00"),
                EndActivity = TimeSpan.Parse("14:00:00"),
                frequency = 7,
                LineId = 2,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("14:00:00"),
                EndActivity = TimeSpan.Parse("20:00:00"),
                frequency = 10,
                LineId = 2,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("20:00:00"),
                EndActivity = TimeSpan.Parse("23:30:00"),
                frequency = 15,
                LineId = 2,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("19:00:00"),
                EndActivity = TimeSpan.Parse("22:00:00"),
                frequency = 20,
                LineId = 1,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("07:30:00"),
                EndActivity = TimeSpan.Parse("15:00:00"),
                frequency = 5,
                LineId = 3,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("16:00:00"),
                EndActivity = TimeSpan.Parse("20:00:00"),
                frequency = 12,
                LineId = 3,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("05:30:00"),
                EndActivity = TimeSpan.Parse("14:00:00"),
                frequency = 7,
                LineId = 4,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("14:00:00"),
                EndActivity = TimeSpan.Parse("21:00:00"),
                frequency = 15,
                LineId = 4,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("07:35:00"),
                EndActivity = TimeSpan.Parse("10:35:00"),
                frequency = 60,
                LineId = 7,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("10:00:00"),
                EndActivity = TimeSpan.Parse("22:00:00"),
                frequency = 50,
                LineId = 6,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("09:15:00"),
                EndActivity = TimeSpan.Parse("15:15:00"),
                frequency = 30,
                LineId = 8,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("16:00:00"),
                EndActivity = TimeSpan.Parse("16:00:00"),
                frequency = 0,
                LineId = 8,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("08:30:00"),
                EndActivity = TimeSpan.Parse("16:00:00"),
                frequency = 10,
                LineId = 9,
                IsExists = true
            }
              );
            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("16:00:00"),
                EndActivity = TimeSpan.Parse("23:00:00"),
                frequency = 15,
                LineId = 9,
                IsExists = true
            }
              );

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("09:00:00"),
                EndActivity = TimeSpan.Parse("21:00:00"),
                frequency = 15,
                LineId = 5,
                IsExists = true
            }
             );

            BusLineSchedules.Add(new BusLineScheduleDO
            {
                StartActivity = TimeSpan.Parse("09:00:00"),
                EndActivity = TimeSpan.Parse("21:00:00"),
                frequency = 15,
                LineId = 10,
                IsExists = true
            }
             );
        }
    }
}
