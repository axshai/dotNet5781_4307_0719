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
        public void AddBus(BusDO bus)
        {
            throw new NotImplementedException();
        }

       

        public void DeleteBus(int licenseNum)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

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

      

        public IEnumerable<object> GetStudentIDs(Func<int, string, object> generate)
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

      
        
    }

    
}
