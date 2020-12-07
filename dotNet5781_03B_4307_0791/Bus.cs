﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace dotNet5781_03B_4307_0791
{
    public class Bus : INotifyPropertyChanged //bus
    {
        public event PropertyChangedEventHandler PropertyChanged;//event for update Visual objects

        private const int MAX_FUEL = 1200;//max fuel
        private const int MAX_KM = 20000;//mex kmwithout care

        public Bus(DateTime date, string license)//ctor
        {
            DateOfAbsorption = date;

            LastTreatment = date;
            License = license;
            State = (DateTime.Now - LastTreatment).TotalDays > 365 ? STATUS.DANGEROUS : STATUS.READY;
            TimerText = "00:00:00";
        }

        private int fuel;//Fuel condition
        public int Fuel
        {
            get { return fuel; }
            set
            {
                fuel = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("fuel"));
            }
        }

        private DateTime lastTreatment;//The date of the last treatment
        public DateTime LastTreatment//The date of the last treatment
        {
            get { return lastTreatment; }
            set
            {
                lastTreatment = value;
                if (!this.DangerTest()) State = STATUS.READY;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("lastTreatment"));
            }
        }

        private string timerText;//tp presemt time until to end of prosses(like drive,reful)
        public string TimerText
        {
            get { return timerText; }
            set
            {
                timerText = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("timerText"));
            }
        }

        //private bool isReady;//if bus not beasy
        public bool IsReady
        {
            get => State == STATUS.READY;
            set
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ISready"));
            }
        }

        public bool IsReadyOrDangroeus
        {
            get => State == STATUS.READY || State== STATUS.DANGEROUS;
            set
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ISready"));
            }
        }

        private int totalKm;
        public int TotalKm//Total mileage
        {
            get { return totalKm; }
            set
            {
                totalKm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("TotalKm"));
            }
        }

        private int kmofTreatment;//Mileage since last treatment
        public int KmofTreatment//Mileage since last treatment
        {
            get { return kmofTreatment; }
            set
            {
                kmofTreatment = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("KmofTreatment"));
            }
        }

        private String licence;//licence NUMBER
        public String License//Licensing property
        {
            get
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

                }
                return string.Format("{0}-{1}-{2}", prefix, middle, suffix);//The required display of the license number
            }


            set//set-Checking the validity of a license number
            {
                bool valid;
                uint toNum;
                if (!(valid = uint.TryParse(value, out toNum)))//Check that the license number includes only digits
                    throw new FormatException("A license number can contain digits only");
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
                    throw new ArgumentException("The license number is invalid");
                }
            }
        }

        private STATUS state;//state of the bus-what its doing now
        public STATUS State
        {
            get { return state; }
            set
            {
                state = value;
                IsReady = true;
                IsReadyOrDangroeus = true;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        }

        private DateTime dateOfAbsorption;//The year of the ascent to the road
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
            if ((kmToDrive > Fuel) || KmofTreatment + kmToDrive > MAX_KM)
                throw new InvalidOperationException("It is not possible to make the trip-Check the fuel condition or the mileage status");
            if (State == STATUS.DANGEROUS)
                throw new InvalidOperationException("The bus is dangerous!");

            Fuel -= kmToDrive;//Fuel reduction
            TotalKm += kmToDrive;//Add to mileage
            KmofTreatment += kmToDrive;
            
        }

        public void DoRefuel()//Make a refueling
        {
            Fuel = MAX_FUEL;
        }

        public void DoHandle()//make a treatment
        {
            LastTreatment = DateTime.Now;//update the date and km of last treatment
            KmofTreatment = 0;
            Fuel = MAX_FUEL;
        }

        public bool DangerTest()
        {
            if ((DateTime.Now - LastTreatment).TotalDays > 365 || KmofTreatment >= MAX_KM)
            {
                State = STATUS.DANGEROUS;
                return true;
            }
            else
                return false;
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

            return string.Format("licence: {0,-10} KM: {1}", result, (TotalKm - KmofTreatment));

        }
    }
}









