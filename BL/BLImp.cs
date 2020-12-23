using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using DalApi;
using BO;
namespace BL
{
    internal class BLImp : IBL
    {
        #region singelton
        static readonly BLImp instance;
        static BLImp() { }
        BLImp() { }
        public static BLImp Instance {
            get {
                if (instance == null) return new BLImp();
                return instance;
                 }
        }
        #endregion

        IDAL myDal = DLFactory.GetDL();
     
        #region private functions-help to the IBLS functions
        /// <summary>
        /// The function receives a station key and returns a list of all lines that have a stop in this station
        /// </summary>
        /// <param name="stateKey">station key of the wnted station</param>
        /// <returns></returns>
        private IEnumerable<BusLineBO> getLinesOfStations(int stateKey)
        {
            IEnumerable<BusLineBO> result = from line in GetAllLines()
                                            where line.StationList.Any(station => station.StationKey == stateKey)
                                            select line;
            return result;
        }




        /// <summary>
        /// The function receives a line number and returns a list of all its stations
        /// </summary>
        /// <param name="LineNum">the number of the Wanted line</param>
        /// <returns>IEnumerable BusLineStationBO-all the station of the line </returns>
        private IEnumerable<BusLineStationBO> getStationsOfLine(int lineId)
        {
            IEnumerable<BusLineStationBO> result = (from station in myDal.GetAllLineStationsBy(station1 => station1.LineId == lineId)//List of stations while receiving the number and name of each station
                                                    orderby station.Serial

                                                    select new BusLineStationBO
                                                    {
                                                        StationName = myDal.GetBusStation(station.StationKey).StationName,
                                                        StationKey = station.StationKey

                                                    });

            result = result.ToList();
            for (int i = 1; i < result.Count(); i++)//receiving the Distance and TimeFrom from Previous station of each station
            {
                result.ElementAt(i).DistanceFromPrev = myDal.GetConsecutiveStations(result.ElementAt(i - 1).StationKey, result.ElementAt(i).StationKey).Distance;
                result.ElementAt(i).TimeFromPrev = myDal.GetConsecutiveStations(result.ElementAt(i - 1).StationKey, result.ElementAt(i).StationKey).TravelTime;
            }

            return result;
        }

        /// <summary>
        /// The function receives a line number and returns a list of all its Schedules
        /// </summary>
        /// <param name="LineNum">the number of the Wanted line</param>
        /// <returns>IEnumerable BusLineScheduleBO-all the Schedule of the line </returns>
        private IEnumerable<BusLineScheduleBO> getSchedulesOfLine(int lineId)
        {
            return from Schedule in myDal.GetAllSchedulesBy(Schedule1 => Schedule1.LineId== lineId)
                   orderby Schedule.StartActivity
                   select new BusLineScheduleBO
                   {
                       StartActivity = Schedule.StartActivity,
                       LineId= lineId,
                       LineNumber = myDal.GetLine(Schedule.LineId).LineNumber,
                       EndActivity = Schedule.EndActivity,
                       frequency = Schedule.frequency
                   };
        }

        #endregion
        
        /// <summary>
        /// The function returns all the lines that exist in the system — with their stations and schedules
        /// </summary>
        /// <returns>IEnumerableBusLineBO-all the lines in the system</returns>
        public IEnumerable<BusLineBO> GetAllLines()
        {
            return from line in myDal.GetAllLines()
                   orderby line.LineNumber
                   select new BusLineBO
                   {
                       Id=line.Id,
                       StationList = getStationsOfLine(line.Id),
                       ScheduleList = getSchedulesOfLine(line.Id),
                       LineNumber = line.LineNumber
                   };

        }

        /// <summary>
        /// The function returns all the stations that exist in the system — with the lines that pass in this stataion
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusStationBO> GetAllStation()
        {
            return from station in myDal.GetAllStations()
                   orderby station.StationKey
                   select new BusStationBO
                   {
                       StationKey = station.StationKey,
                       StationName = station.StationName,
                       ListOfLines = getLinesOfStations(station.StationKey)
                   };
        }        
        



    }
}




        

            












      





    






