using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public class BusInTravelDO
    {
       
        public static int Ids { get; set; }
        public int Id { get; set; }
        public int LicenseNum { get; set; }
        public string LineNum { get; set; }//יכול להכיל גם אותיות אולי
        public DateTime FormalStart { get; set; }
        public DateTime Start { get; set; }
        public int Laststation { get; set; }
        public DateTime LaststationTime { get; set; }
        public DateTime NextstationTime { get; set; }
        public bool IsExists { get; set; }
        public override string ToString()
        {
            string result = "Id: " + Id.ToString() + "\nLicenseNum: " + LicenseNum.ToString() + "LineNum: " + LineNum + "FormalStart: " + FormalStart.ToString() + "\nStart: " + Start.ToString() + "\nLaststation: " + Laststation.ToString() + "\nLaststationTime" + LaststationTime.ToString() + "NextstationTime: " + NextstationTime.ToString() + "\nIsExists? " + IsExists.ToString();

            return result;
        }
    }
}
