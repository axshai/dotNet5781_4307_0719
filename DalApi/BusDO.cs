using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class BusDO
    {
        public int LicenseNum { get; set; }
        public DateTime LicensingDate { get; set; }
        public double Mileage { get; set; }
        public int Fuel { get; set; }
        public Status BusStatus { get; set; }
        public bool IsExists { get; set; }//להחזיר אוטובוס לשירות.יש משהו שתלוי בה
    }
}
