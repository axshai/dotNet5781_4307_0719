﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_4307_0719
{
    public class Bus //bus
    {

        private String licence;//licence NUMBER
        private DateTime dateOfAbsorption;//The year of the ascent to the road
        public DateTime LastTreatment { get; set; }//The date of the last treatment
        public int Fuel { get; set; }//Fuel condition
        public int TotalKm { get; set; }//Total mileage
        public int KmofTreatment { get; set; }//Mileage since last treatment

        public Bus(DateTime date, string license)//ctor
        {
            DateOfAbsorption = LastTreatment = date;
            License = license;
        }

        public String License//Licensing property
        {
            get { return licence; }

            set//set-Checking the validity of a license number
            {
                bool valid;
                int toNum;
                if (!(valid = int.TryParse(value,out toNum)))//Check that the license number includes only digits
                    throw new Exception("A license number can contain digits only");
                if (DateOfAbsorption.Year >= 2018 && value.Length == 8)
                {
                    licence = value;
                }
                else if (DateOfAbsorption.Year < 2018 && value.Length == 7)
                {
                    licence = value;
                }
                else
                {
                    throw new Exception("The license number is invalid");
                }
            }
        }

        public DateTime DateOfAbsorption//dateOfAbsorption property
        {
            get { return dateOfAbsorption; }

            set
            {
                if (value > DateTime.Now)//chek if The date arrived
                    throw new Exception("The date has not yet arrived");
                dateOfAbsorption = value;
            }
        }

        public void Drive(int kmToDrive)//Make a trip
        {
            //Check that the bus is not dangerous and that there is enough fuel:
            if ((kmToDrive > Fuel) || ((DateTime.Now - LastTreatment).TotalDays > 365) || TotalKm - KmofTreatment > 20000)
                throw new Exception("It is not possible to make the trip");
            Fuel -= kmToDrive;//Fuel reduction
            TotalKm += kmToDrive;//Add to mileage
        }

        public void DoRefuel()//Make a refueling
        {
            Fuel = 1200;
        }

        public void DoHandle()//make a treatment
        {
            LastTreatment = DateTime.Now;//update the date and km of last treatment
            KmofTreatment = TotalKm;
        }

        public override string ToString()//Print requested details for the bus
        {
            string prefix, middle, suffix;
            string result;
            if (licence.Length == 7)//If a 7-digit license number
            {
                prefix = licence.Substring(0, 2);
                middle = licence.Substring(2, 3);
                suffix = licence.Substring(5, 2);
                result = string.Format("{0}-{1}-{2}", prefix, middle, suffix);
            }
            else//If a 8-digit license number
            {
                prefix = licence.Substring(0, 3);
                middle = licence.Substring(3, 2);
                suffix = licence.Substring(5, 3);

                result = string.Format("{0}-{1}-{2}", prefix, middle, suffix);//The required display of the license number
            }

            return string.Format("licence: {0,-10} KM: {1}",result,(TotalKm- KmofTreatment));

        }
    }
}
