using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DO;

namespace Dal
{

    sealed class DLXml : IDAL
    {
        #region singelton
        static readonly DLXml instance = new DLXml();
        static DLXml() { }// static ctor to ensure instance init is done just before first usage
        DLXml() { } // default => private
        public static DLXml Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files

        string linesPath = @"BusLinesXml.xml"; //XElement
        string schedulesPath = @"BusLineSchedulesXml.xml"; //XMLSerializer
        string busStationsPath = @"BusStationsXml.xml"; //XMLSerializer
        string consecutiveStationsPath = @"AllConsecutiveStationsXml.xml"; //XMLSerializer
        string lineStationsPath = @"LineStationsXml.xml"; //XMLSerializer



        #endregion

        #region BusLine functions

        public IEnumerable<BusLineDO> GetAllLines()
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);

            return from line in linesRootElem.Elements()
                   where bool.Parse(line.Element("IsExists").Value) == true
                   select new BusLineDO()
                   {
                       Id = int.Parse(line.Element("Id").Value),
                       IsExists = bool.Parse(line.Element("IsExists").Value),
                       LineArea = (Area)Enum.Parse(typeof(Area), line.Element("LineArea").Value),
                       LineNumber = line.Element("LineNumber").Value
                   };

        }

        public BusLineDO GetLine(int id)
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);
            BusLineDO line1 = (from line in linesRootElem.Elements()
                               where int.Parse(line.Element("Id").Value) == id && bool.Parse(line.Element("IsExists").Value) == true
                               select new BusLineDO()
                               {
                                   Id = int.Parse(line.Element("Id").Value),
                                   IsExists = bool.Parse(line.Element("IsExists").Value),
                                   LineArea = (Area)Enum.Parse(typeof(Area), line.Element("LineArea").Value),
                                   LineNumber = line.Element("LineNumber").Value
                               }
                        ).FirstOrDefault();

            if (line1 == null)
                throw new DO.BadLineIdException(id, "This line was not found!");

            return line1;
        }

        public IEnumerable<BusLineDO> GetAllLinesBy(Predicate<BusLineDO> predicate)
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);

            return from line in linesRootElem.Elements()
                   let l1 = new BusLineDO()
                   {
                       Id = int.Parse(line.Element("Id").Value),
                       IsExists = bool.Parse(line.Element("IsExists").Value),
                       LineArea = (Area)Enum.Parse(typeof(Area), line.Element("LineArea").Value),
                       LineNumber = line.Element("LineNumber").Value
                   }
                   where predicate(l1) && l1.IsExists == true
                   select l1;
        }

        public int AddLine(BusLineDO line)
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);
            int newId = XMLConfig.BusLineCounter();
            XElement lineElem = new XElement("BusLineDO",
                new XElement("Id", newId),
                                   new XElement("LineNumber", line.LineNumber),
                                   new XElement("LineArea", line.LineArea),
                                   new XElement("IsExists", line.IsExists)
                                  );
            linesRootElem.Add(lineElem);
            XMLTools.SaveListToXMLElement(linesRootElem, linesPath);
            return newId;
        }

        public void DeleteLine(int id)
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);
            XElement line = (from l in linesRootElem.Elements()
                             where int.Parse(l.Element("Id").Value) == id && bool.Parse(l.Element("IsExists").Value) == true
                             select l).FirstOrDefault();

            if (line != null)
            {
                line.Element("IsExists").Value = bool.FalseString;

                XMLTools.SaveListToXMLElement(linesRootElem, linesPath);
            }
            else
                throw new BadLineIdException(id, "This line was not found!");
        }

        public void UpdateLine(int id, Action<BusLineDO> toUpdate)
        {
            try
            {
                BusLineDO updated = GetLine(id);
                toUpdate(updated);
                UpdateLine(updated);
            }
            catch (BadLineIdException ex) { throw ex; }

        }



        public void UpdateLine(BusLineDO line)
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);
            XElement line1 = (from l in linesRootElem.Elements()
                              where int.Parse(l.Element("Id").Value) == line.Id && bool.Parse(l.Element("IsExists").Value) == true
                              select l).FirstOrDefault();

            if (line1 != null)
            {
                line1.Element("LineNumber").Value = line.LineNumber;
                line1.Element("LineArea").Value = line.LineArea.ToString();
                line1.Element("Id").Value = line.Id.ToString(); ;
                line1.Element("IsExists").Value = line.IsExists.ToString();
                line1.Element("IsExists").Value = bool.FalseString;

                XMLTools.SaveListToXMLElement(linesRootElem, linesPath);
            }
            else
                throw new BadLineIdException(line.Id, "This line was not found!");
        }

        #endregion BusLine

        #region LineStation functions
        public IEnumerable<LineStationDO> GetAllLineStationsBy(Predicate<LineStationDO> predicate)
        {
            List<LineStationDO> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStationDO>(lineStationsPath);
            return from station in ListLineStations
                   where predicate(station) && station.IsExist == true
                   select station;
        }



        public LineStationDO GetLineStation(int stationKey, int lineId)
        {
            List<LineStationDO> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStationDO>(lineStationsPath);

            LineStationDO station = ListLineStations.Find(station1 => station1.StationKey == stationKey && station1.LineId == lineId && station1.IsExist == true);
            if (station != null)
                return station;
            throw new BadLineStationKeyLineIDException(stationKey, lineId, "This line station was not found!");
        }

        public void AddLineStation(LineStationDO station)
        {
            List<LineStationDO> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStationDO>(lineStationsPath);

            if (ListLineStations.Exists(station1 => station1.LineId == station.LineId && station1.StationKey == station.StationKey && station1.IsExist == true))
                throw new BadLineStationKeyLineIDException(station.StationKey, station.LineId, "There is already such a LineStation with the same key in the system!");
            ListLineStations.Add(station);
            XMLTools.SaveListToXMLSerializer(ListLineStations, lineStationsPath);
        }

        public void DeleteLineStation(int lineKey, int stationKey)
        {
            List<LineStationDO> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStationDO>(lineStationsPath);

            LineStationDO toDelete = ListLineStations.Find(station => station.StationKey == stationKey && station.LineId == lineKey && station.IsExist == true);
            if (toDelete != null)
                toDelete.IsExist = false;
            else
                throw new BadLineStationKeyLineIDException(stationKey, lineKey, "This line station was not found!");

            XMLTools.SaveListToXMLSerializer(ListLineStations, lineStationsPath);
        }


        public void UpdateLineStation(int lineKey, int stationKey, Action<LineStationDO> toUpdate)
        {
            List<LineStationDO> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStationDO>(lineStationsPath);

            LineStationDO station1 = ListLineStations.Find(station => station.StationKey == stationKey && station.LineId == lineKey && station.IsExist == true);
            if (station1 != null)
                toUpdate(station1);
            else
                throw new BadLineStationKeyLineIDException(stationKey, lineKey, "This station was not found!");
            XMLTools.SaveListToXMLSerializer(ListLineStations, lineStationsPath);
        }
        #endregion

        #region BusStation
        public void AddBusStation(BusStationDO station)
        {
            List<BusStationDO> ListStations = XMLTools.LoadListFromXMLSerializer<BusStationDO>(busStationsPath);

            if (ListStations.Exists(station1 => station1.StationKey == station.StationKey && station1.IsExists == true))
                throw new BadBusStationKeyException(station.StationKey, "There is already such a LineStation with the same key in the system!");
            ListStations.Add(station);
            XMLTools.SaveListToXMLSerializer(ListStations, busStationsPath);
        }

        public IEnumerable<BusStationDO> GetAllStations()
        {
            List<BusStationDO> ListStations = XMLTools.LoadListFromXMLSerializer<BusStationDO>(busStationsPath);

            return from station in ListStations
                   where station.IsExists == true
                   select station;
        }

        public BusStationDO GetBusStation(int key)
        {
            List<BusStationDO> ListStations = XMLTools.LoadListFromXMLSerializer<BusStationDO>(busStationsPath);

            BusStationDO station = ListStations.Find(station1 => station1.StationKey == key && station1.IsExists == true);
            if (station != null)
                return station;
            throw new BadBusStationKeyException(key, "This station was not found!");
        }

        public void DeleteBusStation(int key)
        {
            List<BusStationDO> ListStations = XMLTools.LoadListFromXMLSerializer<BusStationDO>(busStationsPath);

            BusStationDO toDelete = ListStations.Find(station => station.StationKey == key && station.IsExists == true);
            if (toDelete != null)
                toDelete.IsExists = false;
            else
                throw new BadBusStationKeyException(key, "This station was not found!");

            XMLTools.SaveListToXMLSerializer(ListStations, busStationsPath);
        }

        public void UpdateBusStation(BusStationDO station)
        {
            List<BusStationDO> ListStations = XMLTools.LoadListFromXMLSerializer<BusStationDO>(busStationsPath);

            int index= ListStations.FindIndex(station2 => station2.StationKey == station.StationKey && station2.IsExists == true);
            if (index == -1)
                throw new BadBusStationKeyException(station.StationKey, "This station was not found!");
            ListStations[index] = station;

            XMLTools.SaveListToXMLSerializer(ListStations, busStationsPath);
        }
        #endregion

        #region ConsecutiveStations functions
        public ConsecutiveStationsDO GetConsecutiveStations(int stationKey1, int stationKey2)
        {
            List<ConsecutiveStationsDO> ListConsecutStations = XMLTools.LoadListFromXMLSerializer<ConsecutiveStationsDO>(consecutiveStationsPath);
            ConsecutiveStationsDO c1 = ListConsecutStations.Find(c2 => c2.Station1Key == stationKey1 && c2.Station2Key == stationKey2);
            if (c1 != null)
                return c1;
            throw new BadConsecutiveStationsKeysException(stationKey1, stationKey2, "These stations were not found as  Consecutive!");
        }

        public void AddConsecutiveStations(ConsecutiveStationsDO stations)
        {
            List<ConsecutiveStationsDO> ListConsecutStations = XMLTools.LoadListFromXMLSerializer<ConsecutiveStationsDO>(consecutiveStationsPath);

            if (ListConsecutStations.Exists(stations1 => stations1.Station1Key == stations.Station1Key && stations1.Station2Key == stations.Station2Key))
                throw new BadConsecutiveStationsKeysException(stations.Station1Key, stations.Station2Key, "There is already such ConsecutiveStations in the system!");
            ListConsecutStations.Add(stations);
            XMLTools.SaveListToXMLSerializer(ListConsecutStations, consecutiveStationsPath);

        }

        public void UpdateConsecutiveStations(int stationKey1, int stationKey2, Action<ConsecutiveStationsDO> toUpdate)
        {
            List<ConsecutiveStationsDO> ListConsecutStations = XMLTools.LoadListFromXMLSerializer<ConsecutiveStationsDO>(consecutiveStationsPath);

            ConsecutiveStationsDO c1 = ListConsecutStations.Find(c2 => c2.Station1Key == stationKey1 && c2.Station2Key == stationKey2);
            if (c1 == null)
                throw new BadConsecutiveStationsKeysException(stationKey1, stationKey2, "These stations were not found as  Consecutive!");
            toUpdate(c1);

            XMLTools.SaveListToXMLSerializer(ListConsecutStations, consecutiveStationsPath);

        }
        #endregion


        public IEnumerable<BusLineScheduleDO> GetAllSchedulesBy(Predicate<BusLineScheduleDO> predicate)
        {
            List<BusLineScheduleDO> ListSchedules = XMLTools.LoadListFromXMLSerializer<BusLineScheduleDO>(schedulesPath);

            return from schedule in ListSchedules
                   where predicate(schedule) && schedule.IsExists == true
                   select schedule;
        }

        public void UpdateSchedule(int lineId, TimeSpan start, Action<BusLineScheduleDO> toUpdate)
        {
            List<BusLineScheduleDO> ListSchedules = XMLTools.LoadListFromXMLSerializer<BusLineScheduleDO>(schedulesPath);
            
            BusLineScheduleDO Sched = ListSchedules.Find(Sched1 => Sched1.LineId == lineId && Sched1.StartActivity == start && Sched1.IsExists == true);
            if (Sched != null)
                toUpdate(Sched);
            else
                throw new BadBusLineScheduleException(start, lineId, "There is already such a Schedule for the line the system!");

            XMLTools.SaveListToXMLSerializer(ListSchedules, schedulesPath);
        }

        public void DeleteSchedule(int lineId, TimeSpan start)
        {
            List<BusLineScheduleDO> ListSchedules = XMLTools.LoadListFromXMLSerializer<BusLineScheduleDO>(schedulesPath);
            BusLineScheduleDO Sched = ListSchedules.Find(Sched1 => Sched1.LineId == lineId && Sched1.StartActivity == start && Sched1.IsExists == true);
            if (Sched != null)
                Sched.IsExists = false;
            else
                throw new BadBusLineScheduleException(start, lineId, "This Schedule was not found!");


            XMLTools.SaveListToXMLSerializer(ListSchedules, schedulesPath);

        }

        public void AddSchedule(BusLineScheduleDO toadd)
        {
            List<BusLineScheduleDO> ListSchedules = XMLTools.LoadListFromXMLSerializer<BusLineScheduleDO>(schedulesPath);
            if (ListSchedules.Exists(sched => sched.LineId == toadd.LineId && sched.StartActivity == toadd.StartActivity && sched.IsExists == true))
                throw new BadBusLineScheduleException(toadd.StartActivity, toadd.LineId, "There is already such a Schedule for the line the system!");
            ListSchedules.Add(toadd);

            XMLTools.SaveListToXMLSerializer(ListSchedules, schedulesPath);

        }


    }
}
