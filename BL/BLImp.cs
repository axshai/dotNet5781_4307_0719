using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using DalApi;
using BO;
using DO;
using System.ComponentModel;

namespace BL
{
    /// <summary>
    /// Execution of the ibl interfenc-contract
    /// </summary>
    internal class BLImp : IBL
    {
        #region singelton
        static readonly BLImp instance;
        static BLImp() { }
        BLImp() { }
        public static BLImp Instance
        {
            get
            {
                if (instance == null) return new BLImp();
                return instance;
            }
        }
        #endregion

        IDAL myDal = DLFactory.GetDL();

        #region private functions-help to the IBLS functions

        /// <summary>
        /// The function receives a station number and returns all its subsequent stations 
        /// </summary>
        /// <param name="StationKey">the key of the station</param>
        /// <returns>IEnumerable of ConsecutiveStationBO-all its consecutive Stations</returns>
        private IEnumerable<ConsecutiveStationBO> GetConsecutiveStations(int StationKey)
        {
            List<ConsecutiveStationBO> result = new List<ConsecutiveStationBO>();
            IEnumerable<ConsecutiveStationBO> temp = (from line in GetAllLines()
                                                      where line.StationList.ToList().Exists(line2 => line2.StationKey == StationKey)
                                                      let index = line.StationList.ToList().FindIndex(station2 => station2.StationKey == StationKey)
                                                      where (index < line.StationList.Count() - 1) && (!result.Exists(station1 => line.StationList.ElementAt(index + 1).StationKey == station1.StationKey))
                                                      select new ConsecutiveStationBO { DistanceFromPrev = line.StationList.ElementAt(index + 1).DistanceFromPrev, PrevStationKey = StationKey, StationKey = line.StationList.ElementAt(index + 1).StationKey, StationName = line.StationList.ElementAt(index + 1).StationName, TimeFromPrev = line.StationList.ElementAt(index + 1).TimeFromPrev });
            return from station in temp.ToList()
                   where temp.ToList().FindAll(station1 => station1.StationKey == station.StationKey).Count() < 2
                   select station;

        }


        /// <summary>
        /// The function receives a line and a station and returns the arrival times of the line to the station
        /// </summary>
        /// <param name="line">line id</param>
        /// <param name="stationKey">station key</param>
        /// <returns>IEnumerable of TimeSpan-arrival times to the station</returns>
        private IEnumerable<TimeSpan> lineArrivalTimes(BusLineBO line, int stationKey)
        {
            int sum = line.StationList.Where(state => myDal.GetLineStation(state.StationKey, line.Id).Serial <= myDal.GetLineStation(stationKey, line.Id).Serial).Select(stat => stat.TimeFromPrev.Minutes).Sum();
            IEnumerable<TimeSpan> result = from sched in line.ScheduleList.ToList()
                                           let x = Enumerable.Range(0, (int)((sched.EndActivity - sched.StartActivity).TotalMinutes - 1) / sched.frequency + 1)
                                           from mult in x
                                           select sched.StartActivity.Add(TimeSpan.FromMinutes(sum + sched.frequency * mult));
            return result;

        }
       
        /// <summary>
        /// The function receives information about a pair of consecutive stations and adds an appropriate entity to the system
        /// </summary>
        /// <param name="stateKey1">first station key</param>
        /// <param name="stateKey2">second station key</param>
        /// <param name="distance">distance between the stations</param>
        /// <param name="time">travel time between the stations</param>
        private void addConsecutiveStations(int stateKey1, int stateKey2, double distance, TimeSpan time)
        {
            if (distance <= 0 || time <= TimeSpan.Zero)
                throw new BO.BadConsecutiveStationsKeysException(stateKey1, stateKey2, "Distance and time  between two different stations must be positive!");

            myDal.AddConsecutiveStations(new ConsecutiveStationsDO { Distance = distance, TravelTime = time, Station1Key = stateKey1, Station2Key = stateKey2 });
        }

        /// <summary>
        /// The function receives a station key and returns a list of all lines that have a stop in this station
        /// </summary>
        /// <param name="stateKey">station key of the wnted station</param>
        /// <returns>IEnumerable with all the lines that have a stop in this station</returns>
        private IEnumerable<LineInStationBO> getLinesOfStations(int stateKey)
        {
            IEnumerable<LineInStationBO> result = from line in GetAllLines()
                                                  where line.StationList.Any(station => station.StationKey == stateKey)
                                                  select new LineInStationBO
                                                  {
                                                      Id = line.Id,
                                                      LineNumber = line.LineNumber,
                                                      Destination = line.StationList.Last().StationName,
                                                      ArrivalTimes = lineArrivalTimes(line, stateKey),
                                                      Area = line.Area
                                                  };
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
            return from Schedule in myDal.GetAllSchedulesBy(Schedule1 => Schedule1.LineId == lineId)
                   orderby Schedule.StartActivity
                   select new BusLineScheduleBO
                   {
                       StartActivity = Schedule.StartActivity,
                       LineId = lineId,
                       LineNumber = myDal.GetLine(Schedule.LineId).LineNumber,
                       EndActivity = Schedule.EndActivity,
                       frequency = Schedule.frequency
                   };
        }

        /// <summary>
        /// The function receives a line id and returns a list of stations that can be added to the line
        /// </summary>
        /// <param name="lineId">the id of the wanted line</param>
        /// <returns></returns>
        private IEnumerable<BusStationBO> getRestStations(int lineId)
        {
            BusLineDO line = myDal.GetLine(lineId);
            return from station in myDal.GetAllStations()
                   where !myDal.GetAllLineStationsBy(stat => stat.LineId == lineId).Any(state1 => state1.StationKey == station.StationKey) && (line.LineArea == DO.Area.GENERAL || line.LineArea == station.StationArea)
                   select new BusStationBO
                   {
                       Area = (BO.Area)(int)station.StationArea,
                       StationKey = station.StationKey,
                       StationName = station.StationName,
                       ListOfLines = getLinesOfStations(station.StationKey),
                       Latitude = station.Latitude,
                       Longitude = station.Longitude

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
                       Id = line.Id,
                       Area = (BO.Area)((int)line.LineArea),
                       StationList = getStationsOfLine(line.Id),
                       ScheduleList = getSchedulesOfLine(line.Id),
                       LineNumber = line.LineNumber,
                       restStationList = getRestStations(line.Id)
                   };

        }

        /// <summary>
        /// The function returns all lines that Answers on condition
        /// </summary>
        /// <param name="predicate">the condition</param>
        /// <returns>IEnumerable of the lines</returns>
        public IEnumerable<BusLineBO> GetAllLinesBy(Predicate<BusLineBO> predicate)
        {
            return from line in GetAllLines()
                   where predicate(line)
                   select line;
        }

        /// <summary>
        /// Function adds a new line to the system
        /// </summary>
        /// <param name="number">line number</param>
        /// <param name="first">his first station</param>
        /// <param name="last">his last station</param>
        /// <param name="area">his area</param>
        /// <param name="distance">Distance between these stations - if not present in the system</param>
        /// <param name="time">time between these stations - if not present in the system</param>
        public void AddLine(string number, BusStationBO first, BusStationBO last, BO.Area area, double? distance = null, TimeSpan? time = null)
        {
            IEnumerable<BusLineDO> sameName = myDal.GetAllLinesBy(line => line.LineNumber == number);
            if (number.Length > 3 || number.Length < 1)
                throw new BadLineException("Line name must be up to three characters and not less from one!");
            if (sameName.Count() > 1)
                throw new BadLineException("There are already two lines with the same name!");
            if (sameName.Any(line => (int)line.LineArea != (int)area))
                throw new BadLineException("Lines with the same name must be in the same area!");
            if ((first.Area != area || last.Area != area) && BO.Area.GENERAL != area)
                throw new BadLineException("The stations do not match the line area!");
            if (first.StationKey == last.StationKey)
                throw new BadLineException("The stations Must be different!");
            if (distance != null)
                addConsecutiveStations(first.StationKey, last.StationKey, (double)distance, (TimeSpan)time);

            try
            {
                myDal.GetConsecutiveStations(first.StationKey, last.StationKey);
            }
            catch (DO.BadConsecutiveStationsKeysException ex)
            {
                throw new BO.BadConsecutiveStationsKeysException("No details on time and distance between this 2 station", ex);
            }

            int id = myDal.AddLine(new BusLineDO { IsExists = true, LineArea = (DO.Area)((int)area), LineNumber = number });
            myDal.AddLineStation(new LineStationDO { IsExist = true, Serial = 1, StationKey = first.StationKey, LineId = id });
            myDal.AddLineStation(new LineStationDO { IsExist = true, Serial = 2, StationKey = last.StationKey, LineId = id });

        }

        /// <summary>
        ///The function receives a line id and delete it from the data source 
        /// </summary>
        /// <param name="id">>the id of the wanted line</param>
        public void DeleteLine(int id)
        {
            try
            {
                BusLineBO doDel = GetLine(id);
                foreach (var item in doDel.StationList)//delete all his linestations
                {
                    myDal.DeleteLineStation(id, item.StationKey);
                }

                foreach (var item in doDel.ScheduleList)//delete all his Schedules
                {
                    myDal.DeleteSchedule(id, item.StartActivity);
                }
                myDal.DeleteLine(id);
            }
            catch (DO.BadLineStationKeyLineIDException ex)
            {
                throw new BO.BadLineException("Deletion failed", ex);
            }
            catch (DO.BadBusLineScheduleException ex)
            {
                throw new BO.BadLineException("Deletion failed", ex);
            }

        }

        /// <summary>
        /// The function receives a line id and returns it as BusLineBO
        /// </summary>
        /// <param name="id">>the id of the wanted line</param>
        /// <returns></returns>
        public BusLineBO GetLine(int id)
        {
            BusLineDO line = myDal.GetLine(id);

            return new BusLineBO
            {
                Id = line.Id,
                Area = (BO.Area)((int)line.LineArea),
                StationList = getStationsOfLine(line.Id),
                ScheduleList = getSchedulesOfLine(line.Id),
                LineNumber = line.LineNumber,
                restStationList = getRestStations(line.Id)
            };
        }

        /// <summary>
        /// The function updates a name for a line
        /// </summary>
        /// <param name="id">the line id</param>
        /// <param name="name">name of the kine</param>
        public void updateLine(int id, string name)
        {
            IEnumerable<BusLineDO> sameName = myDal.GetAllLinesBy(line => line.LineNumber == name);
            if (name.Length > 3)
                throw new BadLineException("Line name must be up to three characters!", id);
            if (sameName.Count() > 1)
                throw new BadLineException("There are already two lines with the same name!", id);
            if (sameName.Any(line => line.LineArea != myDal.GetLine(id).LineArea))
                throw new BadLineException("Lines with the same name must be in the same area!", id);
            myDal.UpdateLine(id, line => line.LineNumber = name);


        }

        /// <summary>
        /// The function receives a line schedule and removes it from the system
        /// </summary>
        /// <param name="toDelete">the schedule to delete</param>
        public void DeleteSchedule(BusLineScheduleBO toDelete)
        {
            myDal.DeleteSchedule(toDelete.LineId, toDelete.StartActivity);
        }

        /// <summary>
        /// The function updates the frequency of a line schedule
        /// </summary>
        /// <param name="toUpdate">the schedule to delete update</param>
        /// <param name="newFreq">the new frequency</param>
        public void UpdateSchedule(BusLineScheduleBO toUpdate, int newFreq)
        {
            if ((toUpdate.EndActivity - toUpdate.StartActivity).TotalMinutes < newFreq)
                throw new BO.BadBusLineScheduleException(toUpdate.StartActivity, toUpdate.LineId, "The frequency is higher than the maximum possible in this time frame!");

            myDal.UpdateSchedule(toUpdate.LineId, toUpdate.StartActivity, sched => sched.frequency = newFreq);
        }

        /// <summary>
        /// The function adds a line schedule
        /// </summary>
        /// <param name="lineId">Line ID</param>
        /// <param name="begin1">Start time</param>
        /// <param name="end1">end time</param>
        /// <param name="freq">frequency</param>
        public void AddSchedule(int lineId, TimeSpan begin1, TimeSpan end1, int freq)
        {
            if (begin1 > end1)
                throw new Exception("Start time must be before end!");
            if ((end1 - begin1).TotalMinutes < freq)
                throw new Exception("The frequency is higher than the maximum possible in this time frame!");
            // Find and update / delete schedules that are affected by the new
            IEnumerable<BusLineScheduleBO> toChange = from sched in getSchedulesOfLine(lineId)
                                                      where (sched.StartActivity >= begin1 && sched.StartActivity <= end1) || (sched.EndActivity >= begin1 && sched.EndActivity <= end1) || (sched.StartActivity <= begin1 && sched.EndActivity >= end1)
                                                      select sched;

            foreach (BusLineScheduleBO item in toChange)//foreach old Schedule
            {
                if (item.StartActivity >= begin1 && item.EndActivity <= end1)//if the new Swallows the old
                {
                    DeleteSchedule(item);
                    continue;
                }

                if (item.StartActivity >= begin1)//If the old begins within the new
                    myDal.UpdateSchedule(item.LineId, item.StartActivity, sched => sched.StartActivity = end1); //Made him start after the new

                else if (item.EndActivity <= end1)////If the old ends within the new
                    myDal.UpdateSchedule(item.LineId, item.StartActivity, sched => sched.EndActivity = begin1);////Made him end before the new

                else//if the old Swallows the new
                {
                    myDal.AddSchedule(new BusLineScheduleDO//Split the old
                    { IsExists = true, StartActivity = end1, EndActivity = item.EndActivity, frequency = item.frequency, LineId = lineId });
                    myDal.UpdateSchedule(item.LineId, item.StartActivity, sched => sched.EndActivity = begin1);

                }
            }
            myDal.AddSchedule(new BusLineScheduleDO
            { IsExists = true, StartActivity = begin1, EndActivity = end1, frequency = freq, LineId = lineId });



        }

        /// <summary>
        /// The function returns all the stations that exist in the system — with the lines that pass in this stataion
        /// </summary>
        /// <returns>IEnumerable of the stations</returns>
        public IEnumerable<BusStationBO> GetAllStation()
        {
            return from station in myDal.GetAllStations()
                   orderby station.StationArea
                   select new BusStationBO
                   {
                       Area = (BO.Area)((int)station.StationArea),
                       Latitude = station.Latitude,
                       Longitude = station.Longitude,
                       StationKey = station.StationKey,
                       StationName = station.StationName,
                       ListOfLines = getLinesOfStations(station.StationKey),
                       ListOfConsecutiveLineStations = GetConsecutiveStations(station.StationKey)
                   };
        }

        /// <summary>
        /// The function returns all stations that Answers on condition
        /// </summary>
        /// <param name="predicate">the condition</param>
        /// <returns>IEnumerable of the stations</returns>
        public IEnumerable<BusStationBO> GetAllStationBy(Predicate<BusStationBO> predicate)
        {
            return from station in GetAllStation()
                   where predicate(station)
                   select station;
        }

        /// <summary>
        /// The function returns a desired bus station
        /// </summary>
        /// <param name="stationKey">the key of the wandet station</param>
        /// <returns> BusStationBO-the wanted station</returns>
        public BusStationBO GetBusStation(int stationKey)
        {
            BusStationDO station = myDal.GetBusStation(stationKey);
            return new BusStationBO
            {
                Area = (BO.Area)((int)station.StationArea),
                Latitude = station.Latitude,
                Longitude = station.Longitude,
                StationKey = station.StationKey,
                StationName = station.StationName,
                ListOfLines = getLinesOfStations(station.StationKey),
                ListOfConsecutiveLineStations = GetConsecutiveStations(station.StationKey)
            };
        }

        /// <summary>
        /// The function receives a station and delete it to the database
        /// </summary>
        /// <param name="toDel">the station to delete</param>
        public void DeleteBusStation(BusStationBO toDel)
        {
            if (toDel.ListOfLines.Any())
                throw new BadBusStationException(toDel.StationKey, "It is not possible to delete a station that  lines stop in it!");
            else
                myDal.DeleteBusStation(toDel.StationKey);
        }

        /// <summary>
        /// The function receives a station and update its Fields
        /// </summary>
        /// <param name="toUpdate">station to update</param>
        public void updateBusStation(BusStationBO toUpdate)
        {
            if (toUpdate.Latitude < -90 || toUpdate.Latitude > 90)//If the latitude is incorrect
            {
                throw new BadBusStationKeyException(toUpdate.StationKey, String.Format("The Latitude must be between <{0},{1}>", -90, 90));
            }

            if (toUpdate.Longitude < -180 || toUpdate.Longitude > 180)//If the latitude is incorrect
            {
                throw new BadBusStationKeyException(toUpdate.StationKey, String.Format("The Longitude  must be between <{0},{1}>", -180, 180));
            }
            myDal.UpdateBusStation(new BusStationDO { IsExists = true, StationKey = toUpdate.StationKey, Latitude = toUpdate.Latitude, Longitude = toUpdate.Longitude, StationArea = (DO.Area)((int)toUpdate.Area), StationName = toUpdate.StationName });

        }

        /// <summary>
        ///The function receives a station and adds it to the database
        /// </summary>
        /// <param name="toAdd">the new station</param>
        public void AddBusStation(BusStationBO toAdd)
        {
            if (toAdd.StationKey > 999999 || (toAdd.StationKey < 0))//The number of station must be 6 digits
            {
                throw new BadBusStationException(toAdd.StationKey, "Station number must be between 1 and 6 digits!");
            }
            if (toAdd.Latitude < -90 || toAdd.Latitude > 90)//If the latitude is incorrect
            {
                throw new BadBusStationException(toAdd.StationKey, String.Format("The Latitude must be between <{0},{1}>", -90, 90));
            }

            if (toAdd.Longitude < -180 || toAdd.Latitude > 180)//If the latitude is incorrect
            {
                throw new BadBusStationException(toAdd.StationKey, String.Format("The Longitude  must be between <{0},{1}>", -180, 180));
            }
            try
            {
                myDal.AddBusStation(new BusStationDO { IsExists = true, StationKey = toAdd.StationKey, Latitude = toAdd.Latitude, Longitude = toAdd.Longitude, StationArea = (DO.Area)((int)toAdd.Area), StationName = toAdd.StationName });
            }
            catch (DO.BadBusStationKeyException ex) { throw new BadBusStationException(toAdd.StationKey, ex.Message, ex); }

        }

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
        public void AddLineStation(int lineId, int stationKey, int index, double? PrevDistance = null, TimeSpan? PrevTime = null, double? nextDistance = null, TimeSpan? NextTime = null)
        {
            BusLineBO line = GetLine(lineId);

            if (index == 1)//if we want to add first station
            {

                if (nextDistance == null)//if we dont  received details about time and distance between the stations-so we hope that this data already exixst in the system
                    try
                    {
                        myDal.GetConsecutiveStations(stationKey, line.StationList.ElementAt(0).StationKey);
                    }
                    catch (DO.BadConsecutiveStationsKeysException ex)
                    {
                        throw new BO.BadConsecutiveStationsKeysException("No details on time and distance between this stations end next station", ex);
                    }

                else//if we need to add ConsecutiveStation
                {
                    addConsecutiveStations(stationKey, line.StationList.ElementAt(0).StationKey, (double)nextDistance, (TimeSpan)NextTime);
                }
            }

            else if (line.StationList.Count() + 1 == index)//if he wants to add last station
            {

                if (PrevDistance == null)//if we dont  received details about tome and distance between the stations-so we hope that this data already exixst in the system
                    try
                    {
                        myDal.GetConsecutiveStations(line.StationList.ElementAt(index - 2).StationKey, stationKey);
                    }
                    catch (DO.BadConsecutiveStationsKeysException ex)
                    {
                        throw new BO.BadConsecutiveStationsKeysException("No details on time and distance between this stations end previous station", ex);
                    }
                else//if we need to add ConsecutiveStation
                {
                    addConsecutiveStations(line.StationList.ElementAt(index - 2).StationKey, stationKey, (double)PrevDistance, (TimeSpan)PrevTime);
                }

            }

            else//if he wants to add station in the middle of the rout
            {

                if (nextDistance == null)//if we dont  received details about time and distance between the stations-so we hope that this data already exixst in the system
                    try
                    {
                        myDal.GetConsecutiveStations(stationKey, line.StationList.ElementAt(index - 1).StationKey);
                    }
                    catch (DO.BadConsecutiveStationsKeysException ex)
                    {
                        throw new BO.BadConsecutiveStationsKeysException("No details on time and distance between this stations end next station", ex);
                    }

                else//if we need to add ConsecutiveStation
                {
                    addConsecutiveStations(stationKey, line.StationList.ElementAt(index - 1).StationKey, (double)nextDistance, (TimeSpan)NextTime);
                }

                if (PrevDistance == null)//if we dont  received details about tome and distance between the stations-so we hope that this data already exixst in the system
                    try
                    {
                        myDal.GetConsecutiveStations(line.StationList.ElementAt(index - 2).StationKey, stationKey);
                    }
                    catch (DO.BadConsecutiveStationsKeysException ex)
                    {
                        throw new BO.BadConsecutiveStationsKeysException("No details on time and distance between this stations end previous station", ex);
                    }
                else//if we need to add ConsecutiveStation
                {
                    addConsecutiveStations(line.StationList.ElementAt(index - 2).StationKey, stationKey, (double)PrevDistance, (TimeSpan)PrevTime);
                }
            }
           
            foreach (var item in myDal.GetAllLineStationsBy(station => station.LineId == line.Id && station.Serial >= index))//
            {
                myDal.UpdateLineStation(item.LineId, item.StationKey, station1 => station1.Serial++);
            }

            myDal.AddLineStation(new LineStationDO { IsExist = true, StationKey = stationKey, Serial = index, LineId = lineId });
        }

        /// <summary>
        /// The function deletes from the system line station 
        /// </summary>
        /// <param name="line">the  line</param>
        /// <param name="stationKey">the station key</param>
        /// <param name="distance">Distance between the two stations that have become consecutive as a result of the deletion-if does not yet exist in the system</param>
        /// <param name="time">time between the two stations that have become consecutive as a result of the deletion-if does not yet exist in the system</param>
        public void DeleteLineStation(BusLineBO line, int stationKey, double? distance = null, TimeSpan? time = null)
        {

            int place = myDal.GetLineStation(stationKey, line.Id).Serial;

            if (place != 1 && place != line.StationList.Count())//if he wants do delete station in the midle of the rout
            {
                if (distance == null)//we hope that this data about stations that have become consecutive as a result of the deletion already exixst in the system
                {
                    try
                    {
                        myDal.GetConsecutiveStations(line.StationList.ElementAt(place - 2).StationKey, line.StationList.ElementAt(place).StationKey);
                    }
                    catch (DO.BadConsecutiveStationsKeysException ex)
                    {
                        throw new BO.BadConsecutiveStationsKeysException("No details on time and distance between this stations end previous station", ex);
                    }
                }

                else//if we got the data about time and distance-We understand that the information does not yet exist in the system
                {
                    addConsecutiveStations(line.StationList.ElementAt(place - 2).StationKey, line.StationList.ElementAt(place).StationKey, (double)distance, (TimeSpan)time);
                }

            }

            foreach (var item in myDal.GetAllLineStationsBy(station => station.LineId == line.Id && station.Serial >= myDal.GetLineStation(stationKey, line.Id).Serial))
            {
                myDal.UpdateLineStation(item.LineId, item.StationKey, station1 => station1.Serial--);
            }

            myDal.DeleteLineStation(line.Id, stationKey);
        }

        /// <summary>
        /// The function updates time and distance between consecutive stations
        /// </summary>
        /// <param name="stationKey1">the first station key</param>
        /// <param name="stationKey2">the second station key</param>
        /// <param name="distance">new distance</param>
        /// <param name="time">new time</param>
        public void UpdateConsecutiveStation(int stationKey1, int stationKey2, double distance, TimeSpan time)
        {
            myDal.UpdateConsecutiveStations(stationKey1, stationKey2, cState => cState.Distance = distance);
            myDal.UpdateConsecutiveStations(stationKey1, stationKey2, cState => cState.TravelTime = time);
        }

    }
}

































