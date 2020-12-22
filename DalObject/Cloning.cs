using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DO;
namespace Dal
{
    static class Cloning
    {
        internal static T Clone<T>(this T orginal) where T : new()
        {
            T copy = new T();
            foreach (PropertyInfo properetyInfo in typeof(T).GetProperties())
            {
                properetyInfo.SetValue(copy, properetyInfo.GetValue(orginal, null), null);
            }
            return copy;
        }

    }
}


    //#region BusDO Clone
    //    internal static BusDO Clone(this BusDO orginal)
    //    {
    //        BusDO copy = new BusDO()
    //        {
    //            BusStatus = orginal.BusStatus,
    //            Fuel = orginal.Fuel,
    //            IsExists = orginal.IsExists,
    //            LicenseNum = orginal.LicenseNum,
    //            LicensingDate = orginal.LicensingDate,
    //            Mileage = orginal.Mileage
    //        };
    //        return copy;
    //    }
    //    #endregion
    //    #region BusInTravelDO Clone
    //    internal static BusInTravelDO Clone(this BusInTravelDO orginal)
    //    {
    //        BusInTravelDO copy = new BusInTravelDO()
    //        {
    //            Id = orginal.Id,
    //            FormalStart = orginal.FormalStart,
    //            IsExists = orginal.IsExists,
    //            LicenseNum = orginal.LicenseNum,
    //            Laststation = orginal.Laststation,
    //            LaststationTime = orginal.LaststationTime,
    //            LineNum = orginal.LineNum,
    //            NextstationTime = orginal.NextstationTime,
    //            Start = orginal.Start
    //        };

    //        return copy;
    //    }
    //    #endregion
    //    #region BusLineDO Clone
    //    internal static BusLineDO Clone(this BusLineDO orginal)
    //    {
    //        BusLineDO copy = new BusLineDO()
    //        {
    //            FirstStationKey = orginal.FirstStationKey,
    //            Id = orginal.Id,
    //            IsExists = orginal.IsExists,
    //            LastStationKey = orginal.LastStationKey,
    //            LineArea = orginal.LineArea,
    //            LineNumber = orginal.LineNumber

    //        };
    //        return copy;
    //    }
    //    #endregion
    //    #region BusLineScheduleDO Clone
    //    internal static BusLineScheduleDO Clone(this BusLineScheduleDO orginal)
    //    {
    //        BusLineScheduleDO copy = new BusLineScheduleDO()
    //        {
    //            LineNumber = orginal.LineNumber,
    //            IsExists = orginal.IsExists,
    //            EndActivity = orginal.EndActivity,
    //            frequency = orginal.frequency,
    //            StartActivity = orginal.StartActivity,
    //        };
    //        return copy;
    //    }
    //    #endregion
    //    #region BusStationDO Clone
    //    internal static BusStationDO Clone(this BusStationDO orginal)
    //    {
    //        BusStationDO copy = new BusStationDO()
    //        {
    //            IsExists = orginal.IsExists,
    //            Latitude = orginal.Latitude,
    //            Longitude = orginal.Longitude,
    //            StationKey = orginal.StationKey,
    //            StationName = orginal.StationName
    //        };
    //        return copy;
    //    }
    //    #endregion
    //    #region ConsecutiveStationsDO Clone
    //    internal static ConsecutiveStationsDO Clone(this ConsecutiveStationsDO orginal)
    //    {
    //        ConsecutiveStationsDO copy = new ConsecutiveStationsDO()
    //        {
    //            Distance = orginal.Distance,
    //            Station1Key = orginal.Station1Key,
    //            Station2Key = orginal.Station2Key,
    //            TravelTime = orginal.TravelTime,

    //        };
    //        return copy;
    //    }
    //    #endregion
    //    #region LineStationDO Clone
    //    internal static LineStationDO Clone(this LineStationDO orginal)
    //    {
    //        LineStationDO copy = new LineStationDO()
    //        {
    //            StationKey = orginal.StationKey,
    //            LineNumber = orginal.LineNumber,
    //            Serial = orginal.Serial

    //        };
    //        return copy;
    //    }
    //    #endregion
    //    #region PassengerTravelDO Clone
    //    internal static PassengerTravelDO Clone(this PassengerTravelDO orginal)
    //    {
    //        PassengerTravelDO copy = new PassengerTravelDO()
    //        {
    //            LineNumber = orginal.LineNumber,
    //            DestinationStation = orginal.DestinationStation,
    //            End = orginal.End,
    //            Id = orginal.Id,
    //            IsExists = orginal.IsExists,
    //            Name = orginal.Name,
    //            Start = orginal.Start,
    //            StartingStation = orginal.StartingStation,
    //        };
    //        return copy;
    //    }
    //    #endregion
    //    #region UserDO Clone
    //    internal static UserDO Clone(this UserDO orginal)
    //    {
    //        UserDO copy = new UserDO()
    //        {
    //            Name = orginal.Name,
    //            IsExists = orginal.IsExists,
    //            ManagePermission = orginal.ManagePermission,
    //            Password = orginal.Password
    //        };
    //        return copy;
    //    }
    //    #endregion
    //}
