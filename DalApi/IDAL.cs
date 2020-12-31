using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
namespace DalApi
{
    public interface IDAL
    {
        #region Bus
        IEnumerable<BusDO> GetAllBuses();
        IEnumerable<BusDO> GetAllBusesBy(Predicate<BusDO> predicate);
        BusDO GetBus(int licenseNum);
        void AddBus(BusDO bus);
        void UpdateBus(BusDO bus);
        void UpdateBus(int id, Action<BusDO> toUpdate); //method that knows to updt specific fields in Person
        void DeleteBus(int licenseNum);
        #endregion
        
        #region Line
        IEnumerable<BusLineDO> GetAllLines();
        BusLineDO GetLine(int id);
        public void DeleteLine(int id);
        void UpdateLine(int id, Action<BusLineDO> toUpdate);
        void UpdateLine(BusLineDO line);
        int AddLine(BusLineDO line);
        IEnumerable<BusLineDO> GetAllLinesBy(Predicate<BusLineDO> predicate);


        #endregion


        #region LineStation
        IEnumerable<LineStationDO> GetAllLineStationsBy(Predicate<LineStationDO> predicate);
        void UpdateLineStation(int lineKey, int stationKey, Action<LineStationDO> toUpdate);
        LineStationDO GetLineStation(int stationKey,int lineId);
        void AddLineStation(LineStationDO station);
        void DeleteLineStation(int lineKey, int stationKey);
        #endregion

        #region BusStation
        IEnumerable<BusStationDO> GetAllStations();
        BusStationDO GetBusStation(int key);
        void DeleteBusStation(int key);
        void UpdateBusStation(BusStationDO station);

        #endregion

        #region ConsecutiveStations
        ConsecutiveStationsDO GetConsecutiveStations(int stationKey1, int stationKey2);
        void AddConsecutiveStations(ConsecutiveStationsDO stations);
        void UpdateConsecutiveStations(int stationKey1, int stationKey2, Action<ConsecutiveStationsDO> toUpdate);
        #endregion

        #region BusLineSchedule
        IEnumerable<BusLineScheduleDO> GetAllSchedulesBy(Predicate<BusLineScheduleDO> predicate);
        void UpdateSchedule(int lineId, TimeSpan start,int newFreq, TimeSpan? begin=null, TimeSpan? end=null);
        void DeleteSchedule(int lineId, TimeSpan start);
        void AddSchedule(BusLineScheduleDO toadd);
        #endregion

       




    }


}
