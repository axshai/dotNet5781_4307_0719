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

            mybl.GetAllStation().ElementAt(5);

            Console.WriteLine(mybl.GetAllStation().ElementAt(5));
            Console.ReadLine();



        }
    }
}
