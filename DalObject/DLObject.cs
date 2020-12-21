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
        #region Bus functions
        public IEnumerable<BusDO> GetAllBuses()
        { throw new NotImplementedException(); }

        public IEnumerable<BusDO> GetAllBusesBy(Predicate<BusDO> predicate)
        { throw new NotImplementedException(); }
        public BusDO GetBus(int licenseNum)
        { throw new NotImplementedException(); }
        public void AddBus(BusDO bus)
        {
            throw new NotImplementedException();
        }
        public void UpdateBus(BusDO bus)
        {
            throw new NotImplementedException();
        }
        public void UpdateBus(int id, Action<BusDO> toUpdate) //method that knows to updt specific fields in Person
        { throw new NotImplementedException(); }
        public void DeleteBus(int licenseNum)
        { throw new NotImplementedException(); }
        #endregion
        #region User functions
        public IEnumerable<UserDO> GetAllUsers()
        {
            return from user in DataSource.Users
                   where user.IsExists==true
                   select user.Clone();
        }

        public IEnumerable<UserDO> GetAllUsersBy(Predicate<UserDO> predicate)
        {
            return from user in DataSource.Users
                   where predicate(user)&& user.IsExists == true
                   select user.Clone();

        }
        public UserDO GetUser(string name)
        {
            UserDO user1= DataSource.Users.Find(user => user.Name == name && user.IsExists == true);
            if (user1 != null)
                return user1.Clone();
            throw new Exception("This user was not found!");
        }
        
        public void AddUser(UserDO user)//לא ניתן לתת שם גם של משתמש ישן!
        {
            UserDO toAdd = user.Clone();
            if(DataSource.Users.Exists(user1 => user1.Name == toAdd.Name))
                throw new Exception("There is already such a user with the same name in the system!");
            DataSource.Users.Add(toAdd);
        }
       
        public void UpdateUser(UserDO user)
        {
           int index = DataSource.Users.FindIndex(user1 => user1.Name == user.Name && user1.IsExists == true);
            if(index==-1)
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
            UserDO user1 = DataSource.Users.Find(user => user.Name == name&& user.IsExists==true);
            if (user1 != null)
                user1.IsExists = false;
            throw new Exception("This user was not found!");
        }
        #endregion


    }


}
