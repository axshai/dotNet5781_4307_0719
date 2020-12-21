using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using DalApi;
namespace BL
{
   internal class BLImp: IBL
    {
        #region singelton
        static readonly BLImp instance = new BLImp();
        static BLImp() { }
        BLImp() { }
        public static BLImp Instance { get => instance; }
        #endregion
    }
}
