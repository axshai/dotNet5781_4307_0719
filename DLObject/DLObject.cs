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

        public BusLineDO GetLine(string lineNumber)
        {
            BusLineDO line1 = DataSource.BusLines.Find(line => line.LineNumber == lineNumber && line.IsExists == true);
            if (line1 != null)
                return line1.Clone();
            throw new Exception("This line was not found!");
        }

        public void AddLine(BusLineDO line)
        {
            throw new NotImplementedException();
        }


        public void UpdateLine(BusDO bus)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(int id, Action<BusDO> toUpdate) //method that knows to updt specific fields in Person
        { throw new NotImplementedException(); }

        public void DeleteLine(int licenseNum)
        { throw new NotImplementedException(); }
        #endregion

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
            throw new Exception("This user was not found!");
        }

        public void DeleteUser(string name)
        {
            UserDO user1 = DataSource.Users.Find(user => user.Name == name && user.IsExists == true);
            if (user1 != null)
                user1.IsExists = false;
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

        #region LineStation
        public IEnumerable<LineStationDO> GetAllLineStationsBy(Predicate<LineStationDO> predicate)
        {
            return from station in DataSource.LineStations
                   where predicate(station) && station.IsExist == true
                   select station.Clone();
        }
        #endregion

        #region BusStation functions
        public BusStationDO GetBusStation(int key)
        {
            BusStationDO station = DataSource.BusStations.Find(station1 => station1.StationKey == key && station1.IsExists == true);
            if (station != null)
                return station.Clone();
            throw new Exception("This station was not found!");
        }

        #endregion

        #region ConsecutiveStations functions
        public ConsecutiveStationsDO GetConsecutiveStations(int stationKey1, int stationKey2)
        {
            ConsecutiveStationsDO c1 = DataSource.AllConsecutiveStations.Find(c2 => c2.Station1Key == stationKey1 && c2.Station2Key == stationKey2);
            if (c1 != null)
                return c1.Clone();
            throw new Exception("These stations were not found as  Consecutive!");
        }
        #endregion

        #region BusLineSchedule functions
        public IEnumerable<BusLineScheduleDO> GetAllSchedulesBy(Predicate<BusLineScheduleDO> predicate)
        {
            return from schedule in DataSource.BusLineSchedules
                   where predicate(schedule) && schedule.IsExists == true
                   select schedule.Clone();
        }


        #endregion

        #region BusStation Function
        public IEnumerable<BusStationDO> GetAllStations()
        {
            
                return from station in DataSource.BusStations
                       where station.IsExists == true
                       select station.Clone();
         
        }
        #endregion
    }


}