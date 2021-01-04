using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class BadLineIdException : Exception
    {
        public int ID;
        public BadLineIdException(int id) : base() => ID = id;
        public BadLineIdException(int id, string message) :
            base(message) => ID = id;
        public BadLineIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad Line id: {ID}";
    }

    [Serializable]
    public class BadLineStationKeyLineIDException : Exception
    {
        public int LineID;
        public int StationKey;
        public BadLineStationKeyLineIDException(int Key, int ID) : base() { LineID = ID; StationKey = Key; }
        public BadLineStationKeyLineIDException(int Key, int ID, string message) :
            base(message){ LineID = ID; StationKey = Key; }
        public BadLineStationKeyLineIDException(int Key, int ID, string message, Exception innerException) :
            base(message, innerException){ LineID = ID; StationKey = Key; }

        public override string ToString() => base.ToString() + $", bad line id: {LineID} and station key: {StationKey}";
    }

    [Serializable]
    public class BadConsecutiveStationsKeysException : Exception
    {
        public int Station1key;
        public int Station2key;
        public BadConsecutiveStationsKeysException(int key1, int key2) : base() { Station1key = key1; Station2key = key2; }
        public BadConsecutiveStationsKeysException(int key1, int key2, string message) :
            base(message)
        { Station1key = key1; Station2key = key2; }
        public BadConsecutiveStationsKeysException(int key1, int key2, string message, Exception innerException) :
            base(message, innerException)
        { Station1key = key1; Station2key = key2; }

        public override string ToString() => base.ToString() + $", bad station1 key {Station1key} and station2 key: {Station2key}";
    }

    [Serializable]
    public class BadBusStationKeyException : Exception
    {
        public int Key;
        public BadBusStationKeyException(int key) : base() => Key = key;
        public BadBusStationKeyException(int key, string message) :
            base(message) => Key = key;
        public BadBusStationKeyException(int key, string message, Exception innerException) :
            base(message, innerException) => Key = key;

        public override string ToString() => base.ToString() + $", bad station Key: {Key}";
    }

    [Serializable]
    public class BadBusLineScheduleException : Exception
    {
        public int LineID;
        public TimeSpan Start;
        public BadBusLineScheduleException(TimeSpan start, int ID) : base() {LineID=ID; Start = start; }
        public BadBusLineScheduleException(TimeSpan start, int ID, string message) :
            base(message) {LineID=ID; Start = start; }
        public BadBusLineScheduleException(TimeSpan start, int ID, string message, Exception innerException) :
            base(message, innerException){LineID=ID; Start = start; }

        public override string ToString() => base.ToString() + $", bad Line id: {LineID} and start time: {Start}";
    }
}
