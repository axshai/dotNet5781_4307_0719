using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class BusLineScheduleBO
    {
        public string LineNumber { get; set; }
        public TimeSpan StartActivity { get; set; }//לא קשור לתאריך מסוים
        public TimeSpan EndActivity { get; set; }
        public int frequency { get; set; }
        public override string ToString()
        {
            string result = "LineNumber: " + LineNumber + "\nStartActivity: " + StartActivity.ToString() + "EndActivity: " + EndActivity.ToString() + "frequency: " + frequency.ToString();

            return result;
        }

    }
}
