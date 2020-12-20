﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class BusLineDO
    {

        

       
        public int Id { get; set; }
        public string LineNumber { get; set; }//אולי מכיל גם אותיות
        public Area LineArea { get; set; }
        public int FirstStationKey { get; set; }
        public int LastStationKey { get; set; }
        public bool IsExists { get; set; }//להחזיר אוטובוס לשירות.יש משהו שתלוי בה
        public override string ToString()
        {
            string result = "Id: " + Id.ToString() + "\nLineNumber: " + LineNumber + "\nLineArea: " + LineArea.ToString() + "\nFirstStationKey: " + FirstStationKey.ToString() + "\nFirstStationKey:  " + FirstStationKey.ToString() + "\nLastStationKey:  " + LastStationKey.ToString() + "IsExists? " + IsExists.ToString();

            return result;
        }
    }
}
