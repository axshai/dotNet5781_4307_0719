using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_4307_0719
{
    public class Bus
    {

        private String licence;
        private DateTime dateOfAbsorption { get; set; }//*
        public DateTime LastTreatment { get; set; }
        public int Fuel { get; set; }
        public int TotalKm { get; set; }
        public int KmofTreatment { get; set; }
        

        public String License
        {
            get
            {
                string prefix, middle, suffix;
                string result;
                if (licence.Length == 7)
                {
                    prefix = licence.Substring(0, 2);
                    middle = licence.Substring(2, 3);
                    suffix = licence.Substring(4, 2);
                    result = string.Format("{0}-{1}-{2}", prefix, middle, suffix);
                }
                else
                {
                    prefix = licence.Substring(0, 3);
                    middle = licence.Substring(3, 2);
                    suffix = licence.Substring(5, 3);

                    result = string.Format("{0}-{1}-{2}", prefix, middle, suffix);
                }

                return result;
            }

            set
            {
                if (dateOfAbsorption.Year >= 2018 && value.Length == 8)
                {
                    licence = value;
                }
                else if (dateOfAbsorption.Year < 2018 && value.Length == 7)
                {
                    licence = value;
                }
                else
                {
                    throw new Exception("The license number is invalid");
                }
            }
        }
       
        public Bus(DateTime date, string license)//
        {
            dateOfAbsorption = date;
            License = license;
        }
        
        public void drive(int kmToDrive)
        {

           if ((kmToDrive> Fuel)|| ((DateTime.Now- LastTreatment)>1)|| TotalKm- KmofTreatment>20000)//*
                throw new Exception("It is not possible to make the trip");
            Fuel -=kmToDrive;
            TotalKm += kmToDrive;
        }

    }
}

