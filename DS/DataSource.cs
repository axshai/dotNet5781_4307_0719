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
            InitAllLists();
        }

        
        public static List<BusDO> Buses;
        public static List<BusInTravelDO> BusesInTravel;
        public static List<BusLineDO> BusLines;
        public static List<BusLineScheduleDO> BusLineSchedules;
        public static List<BusStationDO> BusStations;
        public static List<ConsecutiveStationsDO> AllConsecutiveStations;
        public static List<LineStation> LineStations;
        public static List<PassengerTravelDO> PassengerTravels;
        public static List<UserDO> Users;

        static void InitAllLists()
        {
            throw new NotImplementedException();
        }
    }
}
