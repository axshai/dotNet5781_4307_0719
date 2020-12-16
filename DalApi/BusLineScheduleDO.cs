using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class BusLineScheduleDO
    {
        public string LineNumber { get; set; }
        public TimeSpan StartActivity { get; set; }//לא קשור לתאריך מסוים
        public TimeSpan EndActivity { get; set; }
        public int frequency { get; set; }
        public bool IsExists { get; set; }

    }
}
