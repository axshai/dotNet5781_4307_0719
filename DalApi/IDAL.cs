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

        #region Line
        /// <summary>
        /// The function returns all existing lines
        /// </summary>
        /// <returns>A collection(IEnumerable) of lines</returns>
        IEnumerable<BusLineDO> GetAllLines();

        /// <summary>
        /// The function receives a line id and returns the appropriate BusLineDO
        /// </summary>
        /// <param name="id">ID of the wandet line</param>
        /// <returns>BusLineDO-the wanted line</returns>
        BusLineDO GetLine(int id);

        /// <summary>
        /// The function deletes a line from the system
        /// </summary>
        /// <param name="id">the id of the line to delete</param>
        public void DeleteLine(int id);

        /// <summary>
        /// The function updates Specific fields in existing line in the system
        /// </summary>
        /// <param name="id">the id of the line to update</param>
        /// <param name="toUpdate">Update operation</param>
        void UpdateLine(int id, Action<BusLineDO> toUpdate);

        /// <summary>
        /// The function updates an existing line in the system
        /// </summary>
        /// <param name="line">The updated line</param>
        void UpdateLine(BusLineDO line);

        /// <summary>
        /// A function adds a line to the system
        /// </summary>
        /// <param name="line">the line to add</param>
        /// <returns>id of the new line</returns>
        int AddLine(BusLineDO line);
       
        /// <summary>
        /// The function returns all lines that Answers on condition
        /// </summary>
        /// <param name="predicate">the condition</param>
        /// <returns>A collection(IEnumerable) of lines</returns>
        IEnumerable<BusLineDO> GetAllLinesBy(Predicate<BusLineDO> predicate);
        #endregion

        #region LineStation
        /// <summary>
        /// the function returns all line stations that Answers on condition
        /// </summary>
        /// <param name="predicate">the condition</param>
        /// <returns>A collection(IEnumerable) of LineStations</returns>
        IEnumerable<LineStationDO> GetAllLineStationsBy(Predicate<LineStationDO> predicate);

        /// <summary>
        /// The function updates Specific fields in existing line station in the system
        /// </summary>
        /// <param name="lineKey">The id of line to which the station belongs</param>
        /// <param name="stationKey">the key of the station</param>
        /// <param name="toUpdate">Update operation</param>
        void UpdateLineStation(int lineKey, int stationKey, Action<LineStationDO> toUpdate);

        /// <summary>
        /// the function returns a wamted linestation
        /// </summary>
        /// <param name="stationKey">the Key of the station</param>
        /// <param name="lineId">The id of line to which the station belongs</param>
        /// <returns>the wanted station</returns>
        LineStationDO GetLineStation(int stationKey,int lineId);
        
        /// <summary>
        /// A function adds a lineStation to the system
        /// </summary>
        /// <param name="station">the new LineStation</param>
        void AddLineStation(LineStationDO station);

        /// <summary>
        /// The function deletes a line station from the system
        /// </summary>
        /// <param name="lineKey">The id of line to which the station belongs</param>
        /// <param name="stationKey">the Key of the station</param>
        void DeleteLineStation(int lineKey, int stationKey);
        #endregion

        #region BusStation
        void AddBusStation(BusStationDO station);
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
        void UpdateSchedule(int lineId, TimeSpan start, Action<BusLineScheduleDO> toUpdate);
        void DeleteSchedule(int lineId, TimeSpan start);
        void AddSchedule(BusLineScheduleDO toadd);
        #endregion

    }

}
