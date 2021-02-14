using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DO;
namespace Dal
{
    static class Cloning
    {
        internal static T Clone<T>(this T orginal) where T : new()
        {
            T copy = new T();
            foreach (PropertyInfo properetyInfo in typeof(T).GetProperties())
            {
                properetyInfo.SetValue(copy, properetyInfo.GetValue(orginal, null), null);
            }
            return copy;
        }

    }
}


