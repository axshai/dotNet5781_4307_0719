using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace BLApi
{
    /// <summary>
    ///BL interface
    /// </summary>
    public interface IBL
    {
        //Documentation of the functions is found in "BLImp"
        #region lines functions
        IEnumerable<BusLineBO> GetAllLines();
        IEnumerable<BusLineBO> GetAllLinesBy(Predicate<BusLineBO> predicate);
        void AddLine(string number, BusStationBO first, BusStationBO last, BO.Area area, double? distance = null, TimeSpan? time = null);
        void DeleteLine(int id);
        BusLineBO GetLine(int id);
        void updateLine(int id, string name);
        #endregion

        #region Schedules functions
        void DeleteSchedule(BusLineScheduleBO toDelete);
        void UpdateSchedule(BusLineScheduleBO toUpdate, int newFreq);//ניתן לעדכן רק תדירות! כל השאר זה מפתח הישות
        void AddSchedule(int lineId, TimeSpan begin, TimeSpan end, int freq);
        #endregion

        #region BusStation functions
        void AddBusStation(BusStationBO toAdd);
        IEnumerable<BusStationBO> GetAllStation();
        IEnumerable<BusStationBO> GetAllStationBy(Predicate<BusStationBO> predicate);
        BusStationBO GetBusStation(int stationKey);
        void DeleteBusStation(BusStationBO toDel);
        void updateBusStation(BusStationBO toUpdate);
        #endregion

        #region BusLineStation function
        void AddLineStation(int lineId, int stationKey, int index, double? PrevDistance = null, TimeSpan? PrevTime = null, double? nextDistance = null, TimeSpan? NextTime = null);
        void DeleteLineStation(BusLineBO line, int stationKey, double? distance = null, TimeSpan? time = null);
        #endregion

        #region ConsecutiveStations functions
        void UpdateConsecutiveStation(int stationKey1, int stationKey2, double distance, TimeSpan time);
        #endregion
    }
}
