using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class BusLineDO
    {
        public int Id { get; set; }
        public string LineNumber { get; set; }
        public Area LineArea { get; set; }
        public bool IsExists { get; set; }
       


        public override string ToString()
        {
            string result = "Id: " + Id.ToString() + "\nLineNumber: " + LineNumber + "\nLineArea: " + LineArea.ToString()  + "IsExists? " + IsExists.ToString();

            return result;
        }
    }
}
