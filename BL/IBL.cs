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

        #region lines functions
        /// <summary>
        /// The function returns all the lines that exist in the system — with their stations and schedules
        /// </summary>
        /// <returns>IEnumerableBusLineBO-all the lines in the system</returns>
        IEnumerable<BusLineBO> GetAllLines();

        /// <summary>
        /// The function returns all lines that Answers on condition
        /// </summary>
        /// <param name="predicate">the condition</param>
        /// <returns>IEnumerable of the lines</returns>
        IEnumerable<BusLineBO> GetAllLinesBy(Predicate<BusLineBO> predicate);

        /// <summary>
        /// Function adds a new line to the system
        /// </summary>
        /// <param name="number">line number</param>
        /// <param name="first">his first station</param>
        /// <param name="last">his last station</param>
        /// <param name="area">his area</param>
        /// <param name="distance">Distance between these stations - if not present in the system</param>
        /// <param name="time">time between these stations - if not present in the system</param>
        void AddLine(string number, BusStationBO first, BusStationBO last, BO.Area area, double? distance = null, TimeSpan? time = null);

        /// <summary>
        ///The function receives a line id and delete it from the data source 
        /// </summary>
        /// <param name="id">>the id of the wanted line</param>
        void DeleteLine(int id);

        /// <summary>
        /// The function receives a line id and returns it as BusLineBO
        /// </summary>
        /// <param name="id">>the id of the wanted line</param>
        /// <returns></returns>
        BusLineBO GetLine(int id);

        /// <summary>
        /// The function updates a name for a line
        /// </summary>
        /// <param name="id">the line id</param>
        /// <param name="name">name of the kine</param>
        void updateLine(int id, string name);
        #endregion

        #region Schedules functions
        /// <summary>
        /// The function receives a line schedule and removes it from the system
        /// </summary>
        /// <param name="toDelete">the schedule to delete</param>
        void DeleteSchedule(BusLineScheduleBO toDelete);

        /// <summary>
        /// The function updates the frequency of a line schedule
        /// </summary>
        /// <param name="toUpdate">the schedule to delete update</param>
        /// <param name="newFreq">the new frequency</param>
        void UpdateSchedule(BusLineScheduleBO toUpdate, int newFreq);

        /// <summary>
        /// The function adds a line schedule
        /// </summary>
        /// <param name="lineId">Line ID</param>
        /// <param name="begin1">Start time</param>
        /// <param name="end1">end time</param>
        /// <param name="freq">frequency</param>
        void AddSchedule(int lineId, TimeSpan begin, TimeSpan end, int freq);
        #endregion

        #region BusStation functions
        /// <summary>
        ///The function receives a station and adds it to the database
        /// </summary>
        /// <param name="toAdd">the new station</param>
        void AddBusStation(BusStationBO toAdd);

        /// <summary>
        /// The function returns all the stations that exist in the system — with the lines that pass in this stataion
        /// </summary>
        /// <returns>IEnumerable of the stations</returns>
        IEnumerable<BusStationBO> GetAllStation();

        /// <summary>
        /// The function returns all stations that Answers on condition
        /// </summary>
        /// <param name="predicate">the condition</param>
        /// <returns>IEnumerable of the stations</returns>
        IEnumerable<BusStationBO> GetAllStationBy(Predicate<BusStationBO> predicate);

        /// <summary>
        /// The function returns a desired bus station
        /// </summary>
        /// <param name="stationKey">the key of the wandet station</param>
        /// <returns> BusStationBO-the wanted station</returns>
        BusStationBO GetBusStation(int stationKey);

        /// <summary>
        /// The function receives a station and delete it to the database
        /// </summary>
        /// <param name="toDel">the station to delete</param>
        void DeleteBusStation(BusStationBO toDel);

        /// <summary>
        /// The function receives a station and update its Fields
        /// </summary>
        /// <param name="toUpdate">station to update</param>
        void updateBusStation(BusStationBO toUpdate);
        #endregion

        #region BusLineStation function
        /// <summary>
        /// The function receives details about a line station and adds it to the system
        /// </summary>
        /// <param name="lineId">the line id</param>
        /// <param name="stationKey">key of the station</param>
        /// <param name="index">place in the rout</param>
        /// <param name="PrevDistance">Distance from prev station-null in the first call to the function-when we hope that this data already exixst in the system </param>
        /// <param name="PrevTime">time from prev station-null in the first call to the function-when we hope that this data already exixst in the system </param>
        /// <param name="nextDistance">Distance from next station-null in the first call to the function-when we hope that this data already exixst in the system</param>
        /// <param name="NextTime">time from next station-null in the first call to the function-when we hope that this data already exixst in the system</param>
        void AddLineStation(int lineId, int stationKey, int index, double? PrevDistance = null, TimeSpan? PrevTime = null, double? nextDistance = null, TimeSpan? NextTime = null);

        /// <summary>
        /// The function deletes from the system line station 
        /// </summary>
        /// <param name="line">the  line</param>
        /// <param name="stationKey">the station key</param>
        /// <param name="distance">Distance between the two stations that have become consecutive as a result of the deletion-if does not yet exist in the system</param>
        /// <param name="time">time between the two stations that have become consecutive as a result of the deletion-if does not yet exist in the system</param>
        void DeleteLineStation(BusLineBO line, int stationKey, double? distance = null, TimeSpan? time = null);
        #endregion

        #region ConsecutiveStations functions
        /// <summary>
        /// The function updates time and distance between consecutive stations
        /// </summary>
        /// <param name="stationKey1">the first station key</param>
        /// <param name="stationKey2">the second station key</param>
        /// <param name="distance">new distance</param>
        /// <param name="time">new time</param>
        void UpdateConsecutiveStation(int stationKey1, int stationKey2, double distance, TimeSpan time);
        #endregion

        void StartSimulator(TimeSpan startTime, int Rate, Action<TimeSpan> updateTime);
        void StopSimulator();
        

    }
}
