using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;
using DS;
namespace Dal
{

    sealed class DLObject : IDAL
    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }
        DLObject() { }
        public static DLObject Instance { get => instance; }
        #endregion

        #region Line functions
        public IEnumerable<BusLineDO> GetAllLines()
        {
            return from line in DataSource.BusLines
                   where line.IsExists == true
                   select line.Clone();
        }

        public IEnumerable<BusLineDO> GetAllLinesBy(Predicate<BusLineDO> predicate)
        {
            return from line in DataSource.BusLines
                   where predicate(line) && line.IsExists == true
                   select line.Clone();
        }

        public BusLineDO GetLine(int id)
        {
            BusLineDO line1 = DataSource.BusLines.Find(line => line.Id == id && line.IsExists == true);
            if (line1 != null)
                return line1.Clone();
            throw new BadLineIdException(id,"This line was not found!");
        }

        public int AddLine(BusLineDO line)
        {
            BusLineDO line1_toadd = line.Clone();
            line1_toadd.Id = DSConfig.BusLineCounter;
            DataSource.BusLines.Add(line1_toadd);
            return line1_toadd.Id;
        }


        public void UpdateLine(BusLineDO line)
        {
            int index = DataSource.BusLines.FindIndex(line1 => line1.Id == line.Id && line.IsExists == true);
            if (index == -1)
                throw new BadLineIdException(line.Id,"This Line was not found!");
            DataSource.BusLines[index] = line.Clone();
        }

        public void UpdateLine(int id, Action<BusLineDO> toUpdate) //method that knows to updt specific fields in Line
        {
            BusLineDO line = DataSource.BusLines.Find(line1 => line1.Id == id && line1.IsExists == true);
            if (line == null)
                throw new BadLineIdException(id,"This Line was not found!");
            toUpdate(line);

        }

        public void DeleteLine(int id)
        {
            BusLineDO line = DataSource.BusLines.Find(line1 => line1.Id == id && line1.IsExists == true);
            if (line == null)
            {
                throw new BadLineIdException(id,"This Line was not found!");
            }
            line.IsExists = false;

        }
        #endregion
        //---------------------
        #region User functions
        public IEnumerable<UserDO> GetAllUsers()
        {
            return from user in DataSource.Users
                   where user.IsExists == true
                   select user.Clone();
        }

        public IEnumerable<UserDO> GetAllUsersBy(Predicate<UserDO> predicate)
        {
            return from user in DataSource.Users
                   where predicate(user) && user.IsExists == true
                   select user.Clone();

        }
        public UserDO GetUser(string name)
        {
            UserDO user1 = DataSource.Users.Find(user => user.Name == name && user.IsExists == true);
            if (user1 != null)
                return user1.Clone();
            throw new Exception("This user was not found!");
        }

        public void AddUser(UserDO user)//לא ניתן לתת שם גם של משתמש ישן!
        {
            UserDO toAdd = user.Clone();
            if (DataSource.Users.Exists(user1 => user1.Name == toAdd.Name))
                throw new Exception("There is already such a user with the same name in the system!");
            DataSource.Users.Add(toAdd);
        }

        public void UpdateUser(UserDO user)
        {
            int index = DataSource.Users.FindIndex(user1 => user1.Name == user.Name && user1.IsExists == true);
            if (index == -1)
                throw new Exception("This user was not found!");
            DataSource.Users[index] = user.Clone();
        }

        public void UpdateUser(string name, Action<UserDO> toUpdate) //method that knows to updt specific fields in Person
        {
            UserDO user1 = DataSource.Users.Find(user => user.Name == name && user.IsExists == true);
            if (user1 != null)
                toUpdate(user1);
            else
                throw new Exception("This user was not found!");
        }

        public void DeleteUser(string name)
        {
            UserDO user1 = DataSource.Users.Find(user => user.Name == name && user.IsExists == true);
            if (user1 != null)
                user1.IsExists = false;
            else
                throw new Exception("This user was not found!");
        }
        #endregion

        #region Bus functions
        public IEnumerable<BusDO> GetAllBuses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusDO> GetAllBusesBy(Predicate<BusDO> predicate)
        {
            throw new NotImplementedException();
        }

        public BusDO GetBus(int licenseNum)
        {
            throw new NotImplementedException();
        }

        public void AddBus(BusDO bus)
        {
            throw new NotImplementedException();
        }

        public void UpdateBus(BusDO bus)
        {
            throw new NotImplementedException();
        }

        public void UpdateBus(int id, Action<BusDO> toUpdate)
        {
            throw new NotImplementedException();
        }

        public void DeleteBus(int licenseNum)
        {
            throw new NotImplementedException();
        }
        #endregion
        //---------------------
        #region LineStation functions
        public IEnumerable<LineStationDO> GetAllLineStationsBy(Predicate<LineStationDO> predicate)
        {
            return from station in DataSource.LineStations
                   where predicate(station) && station.IsExist == true
                   select station.Clone();
        }

        public void UpdateLineStation(int lineKey, int stationKey, Action<LineStationDO> toUpdate) //method that knows to updt specific fields in station
        {
            LineStationDO station1 = DataSource.LineStations.Find(station => station.StationKey == stationKey && station.LineId == lineKey && station.IsExist == true);
            if (station1 != null)
                toUpdate(station1);
            else
                throw new BadLineStationKeyLineIDException(stationKey, lineKey,"This station was not found!");
        }

        public void AddLineStation(LineStationDO station)
        {
            LineStationDO toAdd = station.Clone();
            if (DataSource.LineStations.Exists(station1 => station1.LineId == station.LineId && station1.StationKey == station.StationKey && station1.IsExist == true))
                throw new BadLineStationKeyLineIDException(station.StationKey,station.LineId,"There is already such a LineStation with the same key in the system!");
            DataSource.LineStations.Add(toAdd);
        }

        public void DeleteLineStation(int lineKey, int stationKey)
        {
            LineStationDO toDelete = DataSource.LineStations.Find(station => station.StationKey == stationKey && station.LineId == lineKey && station.IsExist == true);
            if (toDelete != null)
                toDelete.IsExist = false;
            else
                throw new BadLineStationKeyLineIDException(stationKey, lineKey, "This line station was not found!");
        }

        public LineStationDO GetLineStation(int stationKey, int lineId)
        {
            LineStationDO station = DataSource.LineStations.Find(station1 => station1.StationKey == stationKey && station1.LineId == lineId && station1.IsExist == true);
            if (station != null)
                return station.Clone();
            throw new BadLineStationKeyLineIDException(stationKey, lineId, "This line station was not found!");
        }


        #endregion

        #region ConsecutiveStations functions
        public ConsecutiveStationsDO GetConsecutiveStations(int stationKey1, int stationKey2)
        {
            ConsecutiveStationsDO c1 = DataSource.AllConsecutiveStations.Find(c2 => c2.Station1Key == stationKey1 && c2.Station2Key == stationKey2);
            if (c1 != null)
                return c1.Clone();
            throw new BadConsecutiveStationsKeysException(stationKey1, stationKey2,"These stations were not found as  Consecutive!");
        }

        public void AddConsecutiveStations(ConsecutiveStationsDO stations)
        {
            ConsecutiveStationsDO toAdd = stations.Clone();
            if (DataSource.AllConsecutiveStations.Exists(stations1 => stations1.Station1Key == stations.Station1Key && stations1.Station2Key == stations.Station2Key))
                throw new BadConsecutiveStationsKeysException(stations.Station1Key, stations.Station2Key, "There is already such ConsecutiveStations in the system!");
            DataSource.AllConsecutiveStations.Add(toAdd);
        }

        public void UpdateConsecutiveStations(int stationKey1, int stationKey2, Action<ConsecutiveStationsDO> toUpdate)
        {
            ConsecutiveStationsDO c1 = DataSource.AllConsecutiveStations.Find(c2 => c2.Station1Key == stationKey1 && c2.Station2Key == stationKey2);
            if (c1 == null)
                throw new BadConsecutiveStationsKeysException(stationKey1, stationKey2, "These stations were not found as  Consecutive!");
            toUpdate(c1);
        }

        #endregion


        #region BusStation functions

        public void AddBusStation(BusStationDO station)
        {
            BusStationDO toAdd = station.Clone();
            if (DataSource.BusStations.Exists(station1 => station1.StationKey == station.StationKey && station1.IsExists == true))
                throw new BadBusStationKeyException(station.StationKey,"There is already station with the same key in the system!");
            DataSource.BusStations.Add(toAdd);
        }

        public IEnumerable<BusStationDO> GetAllStations()
        {

            return from station in DataSource.BusStations
                   where station.IsExists == true
                   select station.Clone();

        }

        public BusStationDO GetBusStation(int key)
        {
            BusStationDO station = DataSource.BusStations.Find(station1 => station1.StationKey == key && station1.IsExists == true);
            if (station != null)
                return station.Clone();
            throw new BadBusStationKeyException(key,"This station was not found!");
        }


        public void DeleteBusStation(int key)
        {
            BusStationDO station = DataSource.BusStations.Find(station1 => station1.StationKey == key && station1.IsExists == true);
            if (station == null)
            {
                throw new BadBusStationKeyException(key, "This station was not found!");
            }
            station.IsExists = false;

        }


        public void UpdateBusStation(BusStationDO station)
        {
            int index = DataSource.BusStations.FindIndex(station1 => station1.StationKey == station.StationKey && station1.IsExists == true);
            if (index == -1)
                throw new BadBusStationKeyException(station.StationKey, "This station was not found!");
            DataSource.BusStations[index] = station.Clone();
        }



        #endregion

        #region BusLineSchedule functions

        public IEnumerable<BusLineScheduleDO> GetAllSchedulesBy(Predicate<BusLineScheduleDO> predicate)
        {
            return from schedule in DataSource.BusLineSchedules
                   where predicate(schedule) && schedule.IsExists == true
                   select schedule.Clone();
        }


        public void DeleteSchedule(int lineId, TimeSpan start)
        {
            BusLineScheduleDO Sched = DataSource.BusLineSchedules.Find(Sched1 => Sched1.LineId == lineId && Sched1.StartActivity == start && Sched1.IsExists == true);
            if (Sched != null)
                Sched.IsExists = false;
            else
                throw new BadBusLineScheduleException(start, lineId, "This Schedule was not found!");
        }

        public void UpdateSchedule(int lineId, TimeSpan start, Action<BusLineScheduleDO> toUpdate) //method that knows to updt specific fields in Person
        {
            BusLineScheduleDO Sched = DataSource.BusLineSchedules.Find(Sched1 => Sched1.LineId == lineId && Sched1.StartActivity == start && Sched1.IsExists == true);
            if (Sched != null)
                toUpdate(Sched);
            else
                throw new BadBusLineScheduleException(start, lineId, "There is already such a Schedule for the line the system!");
        }

        public void AddSchedule(BusLineScheduleDO toadd)
        {

            if (DataSource.BusLineSchedules.Exists(sched => sched.LineId == toadd.LineId && sched.StartActivity == toadd.StartActivity && sched.IsExists==true))
                throw new BadBusLineScheduleException(toadd.StartActivity,toadd.LineId,"There is already such a Schedule for the line the system!");
            DataSource.BusLineSchedules.Add(toadd.Clone());
        }


        #endregion
    }


}