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
        static readonly BLImp instance = new BLImp();
        static BLImp() { }
        BLImp() { }
        public static BLImp Instance { get => instance; }
        #endregion

        IDAL myDal = DLFactory.GetDL();
        
        /// <summary>
        /// The function receives a line number and returns a list of all its stations
        /// </summary>
        /// <param name="LineNum">the number of the Wanted line</param>
        /// <returns>IEnumerable BusLineStationBO-all the station of the line </returns>
        private IEnumerable<BusLineStationBO> getStationsOfLine(string LineNum)
        {
            IEnumerable<BusLineStationBO> result = (from station in myDal.GetAllLineStationsBy(station1 => station1.LineNumber == LineNum)//List of stations while receiving the number and name of each station
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
        private IEnumerable<BusLineScheduleBO> getSchedulesOfLine(string LineNum)
        {
            return from Schedule in myDal.GetAllSchedulesBy(Schedule1 => Schedule1.LineNumber == LineNum)
                   orderby Schedule.StartActivity
                   select new BusLineScheduleBO
                   {
                       StartActivity = Schedule.StartActivity,
                       LineNumber = Schedule.LineNumber,
                       EndActivity = Schedule.EndActivity,
                       frequency = Schedule.frequency
                   };
        }


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
                       StationList = getStationsOfLine(line.LineNumber),
                       ScheduleList = getSchedulesOfLine(line.LineNumber),
                       LineNumber = line.LineNumber
                   };

        }


      
    }





}
