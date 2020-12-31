using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;
namespace PLGuiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IBL mybl = BLFactory.GetBL("1");
            
            Console.WriteLine(mybl.GetLine(2));

            List<BusStationBO> station = mybl.GetAllStation().ToList();

           

        }
    }
}
