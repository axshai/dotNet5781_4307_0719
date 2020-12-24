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
            foreach (var item in mybl.GetAllLines())
            {
                Console.WriteLine(item);
            }
            BusLineScheduleBO b1 = new BusLineScheduleBO { EndActivity = TimeSpan.Parse("12:00:00"), StartActivity = TimeSpan.Parse("10:00:00"), frequency = 5, LineId = 1, LineNumber = 66.ToString() };

            mybl.DeleteSchedule(b1);
           
            foreach (var item in mybl.GetAllLines())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

        }
    }
}
