﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace BLApi
{
    public interface IBL 
    {
        #region lines functions
        IEnumerable<BusLineBO> GetAllLines();
        void DeleteLine(int id);
        BusLineBO GetLine(int id);
        #endregion

        #region Schedules functions
        void DeleteSchedule(BusLineScheduleBO toDelete);
        void UpdateSchedule(BusLineScheduleBO toUpdate, int newFreq);//ניתן לעדכן רק תדירות! כל השאר זה מפתח הישות
        void AddSchedule(int lineId, TimeSpan begin, TimeSpan end, int freq);
        #endregion

        #region BusStation functions
        IEnumerable<BusStationBO> GetAllStation();
        #endregion
    }
}
