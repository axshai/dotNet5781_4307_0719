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

            BusLineBO b1 = mybl.GetLine(1);
            //BusLineScheduleBO sched = b1.ScheduleList.First();

           BusStationBO B4= mybl.GetAllStation().ElementAt(5);
            Console.WriteLine(B4.ListOfLines.ElementAt(0));
            Console.WriteLine(B4.ListOfLines.ElementAt(1));




        }
    }
}
