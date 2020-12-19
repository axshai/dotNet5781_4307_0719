using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DalApi
{
    public static class DLFactory
    {

        public static IDAL GetDal()
        {
            string dalType = DalConfig.DalName;
            string dalPackage = DalConfig.DalPackages[dalType];
            if (dalPackage == null)
                throw new DalConfigException($"Wrong DL type: {dalType}");
            try { Assembly.Load(dalPackage); }
            catch (Exception ex)
            { throw new DalConfigException($"Failed loading {dalPackage}.dll", ex); }

            Type type = Type.GetType($"Dal.{dalPackage}, {dalPackage}");
            if (type == null)
                throw new DalConfigException($"Class name is not the same as Assembly Name: {dalPackage}");
            try
            {
                IDAL dal = type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static).GetValue(null) as IDal;
                if (dal == null)
                    throw new DalConfigException($"Class {dalPackage} instance is not initialized");
                return dal;
            }

            catch (NullReferenceException ex) 
            { throw new DalConfigException($"Class {dalPackage} is not a singleton", ex); }

        }
        [Serializable]
        public class DalConfigException : Exception
        {
            public DalConfigException(string message) : base(message) { }
            public DalConfigException(string message, Exception inner) : base(message, inner) { }
        }
    }
    
}

