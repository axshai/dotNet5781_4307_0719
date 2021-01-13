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
        string schedulesPath = @"BusLineSchedulesXml.xml"; //XElement
        string busStationsPath = @"BusStationsXml.xml"; //XMLSerializer
        string consecutiveStationsPath = @"AllConsecutiveStationsXml.xml"; //XElement
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

            int index = ListStations.FindIndex(station2 => station2.StationKey == station.StationKey && station2.IsExists == true);
            if (index == -1)
                throw new BadBusStationKeyException(station.StationKey, "This station was not found!");
            ListStations[index] = station;

            XMLTools.SaveListToXMLSerializer(ListStations, busStationsPath);
        }
        #endregion

        #region ConsecutiveStations functions
        public ConsecutiveStationsDO GetConsecutiveStations(int stationKey1, int stationKey2)
        {
            XElement ConsecutRootElem = XMLTools.LoadListFromXMLElement(consecutiveStationsPath);
            ConsecutiveStationsDO c1 = (from cStations in ConsecutRootElem.Elements()
                                        where int.Parse(cStations.Element("Station1Key").Value) == stationKey1 && int.Parse(cStations.Element("Station2Key").Value) == stationKey2
                                        select new ConsecutiveStationsDO()
                                        {
                                            Distance = double.Parse(cStations.Element("Distance").Value),
                                            Station1Key = int.Parse(cStations.Element("Station1Key").Value),
                                            Station2Key = int.Parse(cStations.Element("Station2Key").Value),
                                            TravelTime = TimeSpan.Parse(cStations.Element("TravelTime").Value)
                                        }

               ).FirstOrDefault();

            if (c1 == null)
                throw new BadConsecutiveStationsKeysException(stationKey1, stationKey2, "These stations were not found as  Consecutive!");
            return c1;
        }

        public void AddConsecutiveStations(ConsecutiveStationsDO stations)
        {
            XElement ConsecutRootElem = XMLTools.LoadListFromXMLElement(consecutiveStationsPath);

            XElement ConsElem = new XElement("ConsecutiveStationsDO",
                new XElement("Station1Key", stations.Station1Key),
                                   new XElement("Station2Key", stations.Station2Key),
                                   new XElement("Distance", stations.Distance),
                                   new XElement("TravelTime", stations.TravelTime.ToString())
                                  );
            ConsecutRootElem.Add(ConsElem);
            XMLTools.SaveListToXMLElement(ConsecutRootElem, consecutiveStationsPath);
        }

        public void UpdateConsecutiveStations(int stationKey1, int stationKey2, Action<ConsecutiveStationsDO> toUpdate)
        {
            XElement ConsecutRootElem = XMLTools.LoadListFromXMLElement(consecutiveStationsPath);
            ConsecutiveStationsDO c1 = (from cStations in ConsecutRootElem.Elements()
                                        where int.Parse(cStations.Element("Station1Key").Value) == stationKey1 && int.Parse(cStations.Element("Station2Key").Value) == stationKey2
                                        select new ConsecutiveStationsDO()
                                        {
                                            Distance = double.Parse(cStations.Element("Distance").Value),
                                            Station1Key = int.Parse(cStations.Element("Station1Key").Value),
                                            Station2Key = int.Parse(cStations.Element("Station2Key").Value),
                                            TravelTime = TimeSpan.Parse(cStations.Element("TravelTime").Value)
                                        }).FirstOrDefault();

            if (c1 == null)
                throw new BadConsecutiveStationsKeysException(stationKey1, stationKey2, "These stations were not found as  Consecutive!");
            toUpdate(c1);

            XElement c2 = (from cStations in ConsecutRootElem.Elements()
                           where int.Parse(cStations.Element("Station1Key").Value) == stationKey1 && int.Parse(cStations.Element("Station2Key").Value) == stationKey2
                           select cStations).FirstOrDefault();


            c2.Element("Station1Key").Value = c1.Station1Key.ToString();
            c2.Element("Station2Key").Value = c1.Station2Key.ToString();
            c2.Element("Distance").Value = c1.Distance.ToString(); ;
            c2.Element("TravelTime").Value = c1.TravelTime.ToString();


            XMLTools.SaveListToXMLElement(ConsecutRootElem, consecutiveStationsPath);

        }
        #endregion


        public IEnumerable<BusLineScheduleDO> GetAllSchedulesBy(Predicate<BusLineScheduleDO> predicate)
        {
            XElement schedRootElem = XMLTools.LoadListFromXMLElement(schedulesPath);

            return from sched in schedRootElem.Elements()
                   let sched1 = new BusLineScheduleDO()
                   {
                       EndActivity = TimeSpan.Parse(sched.Element("EndActivity").Value),
                       StartActivity = TimeSpan.Parse(sched.Element("StartActivity").Value),
                       frequency = int.Parse(sched.Element("frequency").Value),
                       LineId = int.Parse(sched.Element("LineId").Value),
                       IsExists = bool.Parse(sched.Element("IsExists").Value),
                   }
                   where predicate(sched1) && sched1.IsExists == true
                   select sched1;
        }

        public void UpdateSchedule(int lineId, TimeSpan start, Action<BusLineScheduleDO> toUpdate)
        {

            XElement schedRootElem = XMLTools.LoadListFromXMLElement(schedulesPath);
            BusLineScheduleDO sched1 = GetAllSchedulesBy(sced => sced.LineId == lineId && sced.StartActivity == start && sced.IsExists == true).FirstOrDefault();

            if (sched1 == null)
                throw new BadBusLineScheduleException(start, lineId, "This Schedule was not found!");
            toUpdate(sched1);

            XElement sched2 = (from sced in schedRootElem.Elements()
                               where int.Parse(sced.Element("LineId").Value) == lineId && TimeSpan.Parse(sced.Element("StartActivity").Value) == start && bool.Parse(sced.Element("IsExists").Value) == true
                               select sced).FirstOrDefault();


            sched2.Element("StartActivity").Value = sched1.StartActivity.ToString();
            sched2.Element("EndActivity").Value = sched1.EndActivity.ToString();
            sched2.Element("frequency").Value = sched1.frequency.ToString(); ;
            sched2.Element("LineId").Value = sched1.LineId.ToString();


            XMLTools.SaveListToXMLElement(schedRootElem, schedulesPath);

        }

        public void DeleteSchedule(int lineId, TimeSpan start)
        {
            XElement schedRootElem = XMLTools.LoadListFromXMLElement(schedulesPath);
            XElement sched = (from sced in schedRootElem.Elements()
                              where int.Parse(sced.Element("LineId").Value) == lineId && TimeSpan.Parse(sced.Element("StartActivity").Value) == start && bool.Parse(sced.Element("IsExists").Value) == true
                              select sced).FirstOrDefault();

            if (sched != null)
            {
                sched.Element("IsExists").Value = bool.FalseString;

                XMLTools.SaveListToXMLElement(schedRootElem, schedulesPath);
            }
            else
                throw new BadBusLineScheduleException(start, lineId, "This Schedule was not found!");
        }

        public void AddSchedule(BusLineScheduleDO toadd)
        {
            XElement schedRootElem = XMLTools.LoadListFromXMLElement(schedulesPath);

            XElement schedElem = new XElement("BusLineScheduleDO",
                new XElement("StartActivity", toadd.StartActivity.ToString()),
                                   new XElement("EndActivity", toadd.EndActivity.ToString()),
                                   new XElement("frequency", toadd.frequency),
                                   new XElement("LineId", toadd.LineId),
                                   new XElement("IsExists", bool.TrueString)
                                  );
            schedRootElem.Add(schedElem);
            XMLTools.SaveListToXMLElement(schedRootElem, schedulesPath);
        }


    }
}