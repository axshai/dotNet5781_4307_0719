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

            Console.WriteLine(mybl.GetLine(1));

            //try
           // {
                mybl.AddLineStation(1, 789, prevStationKey: 456);
                Console.WriteLine(mybl.GetLine(1));
          //  }
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }
    }
}
