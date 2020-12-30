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
        private void addConsecutiveStations(int stateKey1, int stateKey2, double distance, TimeSpan time)
        {
            if (distance <= 0 || time <= TimeSpan.Zero)
                throw new Exception("Distance and time  between two different stations must be positive!");

            myDal.AddConsecutiveStations(new ConsecutiveStationsDO { Distance = distance, TravelTime = time, Station1Key = stateKey1, Station2Key = stateKey2 });
        }

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
        /// The function returns all the stations that exist in the system — with the lines that pass in this stataion
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusStationBO> GetAllStation()
        {
            return from station in myDal.GetAllStations()
                   orderby station.StationArea
                   select new BusStationBO
                   {
                       Area = (BO.Area)((int)station.StationArea),
                        Latitude=station.Latitude,
                        Longitude=station.Longitude,
                       StationKey = station.StationKey,
                       StationName = station.StationName,
                       ListOfLines = getLinesOfStations(station.StationKey),
                       ListOfConsecutiveLineStations=GetListOfConsecutiveLineStation(station.StationKey)
                   };
        }
        /// <summary>
        /// The function receives a line schedule and removes it from the system
        /// </summary>
        /// <param name="toDelete">the schedule to delete</param>
        public void DeleteSchedule(BusLineScheduleBO toDelete)
        {

            try { myDal.DeleteSchedule(toDelete.LineId, toDelete.StartActivity); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// The function updates the frequency of a line schedule
        /// </summary>
        /// <param name="toUpdate">the schedule to delete update</param>
        /// <param name="newFreq">the new frequency</param>
        public void UpdateSchedule(BusLineScheduleBO toUpdate, int newFreq)
        {
            if ((toUpdate.EndActivity - toUpdate.StartActivity).TotalMinutes < newFreq)
                throw new Exception("The frequency is higher than the maximum possible in this time frame!");
            try
            {
                myDal.UpdateSchedule(toUpdate.LineId, toUpdate.StartActivity, newFreq);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                                                      where (sched.StartActivity > begin1 && sched.StartActivity < end1) || (sched.EndActivity > begin1 && sched.EndActivity < end1) || (sched.StartActivity < begin1 && sched.EndActivity > end1)
                                                      select sched;

            foreach (BusLineScheduleBO item in toChange)
            {
                if (item.StartActivity > begin1 && item.EndActivity < end1)//אם החדש בולע אותו
                {
                    DeleteSchedule(item);
                    continue;
                }

                if (item.StartActivity > begin1)//אם הוא מתחיל בתוך החדש
                    myDal.UpdateSchedule(lineId: item.LineId, start: item.StartActivity, newFreq: item.frequency, begin: end1);//עשה שיתחיל אחריו
                else if (item.EndActivity < end1)//אם נגמר בתוך החדש
                    myDal.UpdateSchedule(lineId: item.LineId, start: item.StartActivity, newFreq: item.frequency, end: begin1);//עשה שיגמר לפניו
                else
                {
                    myDal.AddSchedule(new BusLineScheduleDO//אם הוא בולע את החדש
                    { IsExists = true, StartActivity = end1, EndActivity = item.EndActivity, frequency = item.frequency, LineId = lineId });
                    myDal.UpdateSchedule(lineId: item.LineId, start: item.StartActivity, newFreq: item.frequency, end: begin1);

                }
            }
            myDal.AddSchedule(new BusLineScheduleDO
            { IsExists = true, StartActivity = begin1, EndActivity = end1, frequency = freq, LineId = lineId });



        }

        /// <summary>
        /// The function receives a line id and returns a list of stations that can be added to the line
        /// </summary>
        /// <param name="lineId">the id of the wanted line</param>
        /// <returns></returns>
        public IEnumerable<BusStationBO> getRestStations(int lineId)
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


        /// <summary>
        ///The function receives a line id and delete it from the data source 
        /// </summary>
        /// <param name="id">>the id of the wanted line</param>
        public void DeleteLine(int id)
        {
            try
            {
                BusLineBO doDel = GetLine(id);
                foreach (var item in doDel.StationList)
                {
                    myDal.DeleteLineStation(id, item.StationKey);
                }

                foreach (var item in doDel.ScheduleList)
                {
                    myDal.DeleteSchedule(id, item.StartActivity);
                }
                myDal.DeleteLine(id);
            }
            catch(Exception ex)
            {
                throw new Exception("Deletion failed", ex);
            }

        }

        /// <summary>
        /// The function receives a line id and returns it as BusLineBO
        /// </summary>
        /// <param name="id">>the id of the wanted line</param>
        /// <returns></returns>
        public BusLineBO GetLine(int id)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void AddLineStation(int lineId, int stationKey, int index, double? PrevDistance = null, TimeSpan? PrevTime = null, double? nextDistance = null, TimeSpan? NextTime = null)
        {
            BusLineBO line = GetLine(lineId);
           
            if (index == 1)//if we want to add first station
            {
               
                if (nextDistance == null)//if we dont  received details about time and distance between the stations
                    try
                    {
                        myDal.GetConsecutiveStations(stationKey, line.StationList.ElementAt(0).StationKey);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No details on time and distance between this stations end next station", ex);
                    }

                else//if we need to add ConsecutiveStation
                {
                    addConsecutiveStations(stationKey, line.StationList.ElementAt(0).StationKey, (double)nextDistance, (TimeSpan)NextTime);
                }
            }

            else if (line.StationList.Count()+1==index)//if he wants to add last station
            {
                
                if (PrevDistance == null)//if we dont  received details about tome and distance between the stations
                    try
                    {
                        myDal.GetConsecutiveStations(line.StationList.ElementAt(index - 2).StationKey, stationKey);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No details on time and distance between this stations end previous station", ex);
                    }
                else//if we need to add ConsecutiveStation
                {
                    addConsecutiveStations(line.StationList.ElementAt(index - 2).StationKey, stationKey, (double)PrevDistance, (TimeSpan)PrevTime);
                }

            }

            else
            {
                
                if (nextDistance == null)//if we dont  received details about time and distance between the stations
                    try
                    {
                        myDal.GetConsecutiveStations(stationKey, line.StationList.ElementAt(index-1).StationKey);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No details on time and distance between this stations end next station", ex);
                    }

                else//if we need to add ConsecutiveStation
                {
                    addConsecutiveStations(stationKey, line.StationList.ElementAt(index-1).StationKey, (double)nextDistance, (TimeSpan)NextTime);
                }

                if (PrevDistance == null)//if we dont  received details about tome and distance between the stations
                    try
                    {
                        myDal.GetConsecutiveStations(line.StationList.ElementAt(index - 2).StationKey, stationKey);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No details on time and distance between this stations end previous station", ex);
                    }
                else//if we need to add ConsecutiveStation
                {
                    addConsecutiveStations(line.StationList.ElementAt(index - 2).StationKey, stationKey, (double)PrevDistance, (TimeSpan)PrevTime);
                }
            } 

            foreach (var item in myDal.GetAllLineStationsBy(station => station.LineId == line.Id && station.Serial >= index))
            {
                myDal.UpdateLineStation(item.LineId,item.StationKey,station1 => station1.Serial++);
            }

            myDal.AddLineStation(new LineStationDO { IsExist = true, StationKey = stationKey, Serial = index, LineId = lineId });
        }


        public IEnumerable<BusLineStationBO> GetListOfConsecutiveLineStation(int StationKey)
        {
            List<BusLineBO> lists = new List<BusLineBO>();
            List<BusLineStationBO> myStation = new List<BusLineStationBO>();

            foreach (var line1 in GetAllLines())
            {
                if (line1.StationList.ToList().Find(line2 => line2.StationKey == StationKey) != null)
                {
                    lists.Add(line1);
                }
            }

            int index = 0;
            foreach(var line1 in lists)  
            {
                index = line1.StationList.ToList().FindIndex(station1 => station1.StationKey == StationKey);
                if (index< line1.StationList.ToList().Count()-1)
                {
                    myStation.Add(line1.StationList.ToList()[index + 1]);
                }
            }

            return myStation as IEnumerable<BusLineStationBO>;

            }

        public void updateLine(int id, string name)
        {
           IEnumerable<BusLineDO> sameName = myDal.GetAllLinesBy(line => line.LineNumber == name);
            if(name.Length>3)
                throw new Exception("Line name must be up to three characters!");
            if (sameName.Count() > 1)
                throw new Exception("There are already two lines with the same name!");
            if (sameName.Any(line => line.LineArea != myDal.GetLine(id).LineArea))
                throw new Exception("Lines with the same name must be in the same area!");
            myDal.UpdateLine(id, line => line.LineNumber = name);


        }

        public void DeleteLineStation(BusLineBO line, int stationKey, double? distance = null, TimeSpan? time = null)
        {
            
            int place= myDal.GetLineStation(stationKey,line.Id).Serial;
           // int index = line.StationList.ToList().FindIndex(state => state.StationKey == stationKey);

            if (place != 1 && place != line.StationList.Count())//if he wants do delete station in the midle of the rout
            {
                if (distance == null)
                {
                    try
                    {
                        myDal.GetConsecutiveStations(line.StationList.ElementAt(place - 2).StationKey, line.StationList.ElementAt(place).StationKey);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No details on time and distance between this stations end previous station", ex);
                    }
                }
                else 
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
    }





    
}































