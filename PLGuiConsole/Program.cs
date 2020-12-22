using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
namespace PLGuiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IBL mybl = BLFactory.GetBL("1");
            foreach (var item in mybl.GetAllLines().ToList())
            {
                Console.WriteLine(item);
            }
        }
    }
}
