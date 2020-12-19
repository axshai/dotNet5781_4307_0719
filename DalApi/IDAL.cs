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
        #region Bus
        IEnumerable<BusDO> GetAllBuses();
        IEnumerable<BusDO> GetAllBusesBy(Predicate<BusDO> predicate);
        BusDO GetBus(int licenseNum);
        void AddBus(BusDO bus);
        void UpdateBus(BusDO bus);
        void UpdateBus(int id, Action<BusDO> toUpdate); //method that knows to updt specific fields in Person
        void DeleteBus(int licenseNum);
        #endregion

       
    }
}
