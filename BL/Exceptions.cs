using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [Serializable]
    public class BadBusLineScheduleException : Exception
    {
        public int LineID;
        public TimeSpan Start;
        public BadBusLineScheduleException(TimeSpan start, int ID, string message) :
           base(message)
        { LineID = ID; Start = start; }
        public BadBusLineScheduleException(string message, Exception innerException) :
            base(message, innerException)
        { LineID = ((DO.BadBusLineScheduleException)innerException).LineID; Start = ((DO.BadBusLineScheduleException)innerException).Start; }

        public override string ToString() => base.ToString() + $", bad Line id: {LineID} and start time: {Start}";
    }

    public class BadLineException : Exception
    {
        public int ID;
        public BadLineException(string message, int id = 0) :
           base(message)
        {  ID=id; }
        public BadLineException(string message, Exception innerException) :
            base(message, innerException)
        { ID = ((DO.BadLineIdException)innerException).ID; }

        public override string ToString() => base.ToString() + $", bad Line id: {ID}";
    }

    [Serializable]
    public class BadConsecutiveStationsKeysException : Exception
    {
        public int Station1key;
        public int Station2key;
        public BadConsecutiveStationsKeysException(int key1, int key2, string message) :
            base(message)
        { Station1key = key1; Station2key = key2; }
        public BadConsecutiveStationsKeysException(string message, Exception innerException) :
            base(message, innerException)
        { Station1key=((DO.BadConsecutiveStationsKeysException)innerException).Station1key ; Station2key = ((DO.BadConsecutiveStationsKeysException)innerException).Station2key; }

        public override string ToString() => base.ToString() + $", bad station1 key {Station1key} and station2 key: {Station2key}";
    }

    [Serializable]
    public class BadBusStationException : Exception
    {
        public int Key;
        public BadBusStationException(int key, string message) :
            base(message) => Key = key;
        public BadBusStationException(int key, string message, Exception innerException) :
            base(message, innerException) => Key = ((DO.BadBusStationKeyException)innerException).Key;

        public override string ToString() => base.ToString() + $", bad station Key: {Key}";
    }

}
