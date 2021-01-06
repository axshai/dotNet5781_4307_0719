using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class BusLineScheduleBO
    {
        public int LineId { get; set; }
        public string LineNumber { get; set; }
        public TimeSpan StartActivity { get; set; }
        public TimeSpan EndActivity { get; set; }
        public int frequency { get; set; }
        public override string ToString()
        {
            return "LineId: "+ LineId +" LineNumber: " + LineNumber + " StartActivity: " + StartActivity.ToString() + " EndActivity: " + EndActivity.ToString() + " frequency: " + frequency.ToString();

            
        }

    }
}
