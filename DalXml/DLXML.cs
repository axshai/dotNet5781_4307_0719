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

    sealed class DLXML : IDAL    
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }// static ctor to ensure instance init is done just before first usage
        DLXML() { } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files

        string linesPath = @"BusLinesXml.xml"; //XElement
        string schedulesPath = @"BusLineSchedulesXml.xml"; //XMLSerializer
        string busStationsPath = @"BusStationsXml.xml"; //XMLSerializer
        string consecutiveStationsPath = @"AllConsecutiveStationsXml.xml"; //XMLSerializer
        string lineStations = @"LineStationsXml.xml"; //XMLSerializer



        #endregion

        #region BusLine

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
                             where int.Parse(l.Element("Id").Value) == id&& bool.Parse(l.Element("IsExists").Value) == true
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
                              where int.Parse(l.Element("Id").Value) == line.Id&& bool.Parse(l.Element("IsExists").Value) == true
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

        #region Student
        public DO.Student GetStudent(int id)
        {
            List<Student> ListStudents = XMLTools.LoadListFromXMLSerializer<Student>(studentsPath);

            DO.Student stu = ListStudents.Find(p => p.ID == id);
            if (stu != null)
                return stu; //no need to Clone()
            else
                throw new DO.BadPersonIdException(id, $"bad student id: {id}");
        }
        public void AddStudent(DO.Student student)
        {
            List<Student> ListStudents = XMLTools.LoadListFromXMLSerializer<Student>(studentsPath);

            if (ListStudents.FirstOrDefault(s => s.ID == student.ID) != null)
                throw new DO.BadPersonIdException(student.ID, "Duplicate student ID");

            if (GetPerson(student.ID) == null)
                throw new DO.BadPersonIdException(student.ID, "Missing person ID");

            ListStudents.Add(student); //no need to Clone()

            XMLTools.SaveListToXMLSerializer(ListStudents, studentsPath);

        }
        public IEnumerable<DO.Student> GetAllStudents()
        {
            List<Student> ListStudents = XMLTools.LoadListFromXMLSerializer<Student>(studentsPath);

            return from student in ListStudents
                   select student; //no need to Clone()
        }
        public IEnumerable<object> GetStudentFields(Func<int, string, object> generate)
        {
            List<Student> ListStudents = XMLTools.LoadListFromXMLSerializer<Student>(studentsPath);

            return from student in ListStudents
                   select generate(student.ID, GetPerson(student.ID).Name);
        }

        public IEnumerable<object> GetStudentListWithSelectedFields(Func<DO.Student, object> generate)
        {
            List<Student> ListStudents = XMLTools.LoadListFromXMLSerializer<Student>(studentsPath);

            return from student in ListStudents
                   select generate(student);
        }
        public void UpdateStudent(DO.Student student)
        {
            List<Student> ListStudents = XMLTools.LoadListFromXMLSerializer<Student>(studentsPath);

            DO.Student stu = ListStudents.Find(p => p.ID == student.ID);
            if (stu != null)
            {
                ListStudents.Remove(stu);
                ListStudents.Add(student); //no nee to Clone()
            }
            else
                throw new DO.BadPersonIdException(student.ID, $"bad student id: {student.ID}");

            XMLTools.SaveListToXMLSerializer(ListStudents, studentsPath);
        }

        public void UpdateStudent(int id, Action<DO.Student> update)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            List<Student> ListStudents = XMLTools.LoadListFromXMLSerializer<Student>(studentsPath);

            DO.Student stu = ListStudents.Find(p => p.ID == id);

            if (stu != null)
            {
                ListStudents.Remove(stu);
            }
            else
                throw new DO.BadPersonIdException(id, $"bad student id: {id}");

            XMLTools.SaveListToXMLSerializer(ListStudents, studentsPath);
        }
        #endregion Student

        #region StudentInCourse
        public IEnumerable<DO.StudentInCourse> GetStudentsInCourseList(Predicate<DO.StudentInCourse> predicate)
        {
            List<StudentInCourse> ListStudInCourses = XMLTools.LoadListFromXMLSerializer<StudentInCourse>(studInCoursesPath);

            return from sic in ListStudInCourses
                   where predicate(sic)
                   select sic; //no need to Clone()
        }
        public void AddStudentInCourse(int perID, int courseID, float grade = 0)
        {
            List<StudentInCourse> ListStudInCourses = XMLTools.LoadListFromXMLSerializer<StudentInCourse>(studInCoursesPath);

            if (ListStudInCourses.FirstOrDefault(cis => (cis.PersonId == perID && cis.CourseId == courseID)) != null)
                throw new DO.BadPersonIdCourseIDException(perID, courseID, "person ID is already registered to course ID");

            DO.StudentInCourse sic = new DO.StudentInCourse() { PersonId = perID, CourseId = courseID, Grade = grade };

            ListStudInCourses.Add(sic);

            XMLTools.SaveListToXMLSerializer(ListStudInCourses, studInCoursesPath);
        }

        public void UpdateStudentGradeInCourse(int perID, int courseID, float grade)
        {
            List<StudentInCourse> ListStudInCourses = XMLTools.LoadListFromXMLSerializer<StudentInCourse>(studInCoursesPath);

            DO.StudentInCourse sic = ListStudInCourses.Find(cis => (cis.PersonId == perID && cis.CourseId == courseID));

            if (sic != null)
            {
                sic.Grade = grade;
            }
            else
                throw new DO.BadPersonIdCourseIDException(perID, courseID, "person ID is NOT registered to course ID");

            XMLTools.SaveListToXMLSerializer(ListStudInCourses, studInCoursesPath);
        }

        public void DeleteStudentInCourse(int perID, int courseID)
        {
            List<StudentInCourse> ListStudInCourses = XMLTools.LoadListFromXMLSerializer<StudentInCourse>(studInCoursesPath);

            DO.StudentInCourse sic = ListStudInCourses.Find(cis => (cis.PersonId == perID && cis.CourseId == courseID));

            if (sic != null)
            {
                ListStudInCourses.Remove(sic);
            }
            else
                throw new DO.BadPersonIdCourseIDException(perID, courseID, "person ID is NOT registered to course ID");

            XMLTools.SaveListToXMLSerializer(ListStudInCourses, studInCoursesPath);

        }
        public void DeleteStudentFromAllCourses(int perID)
        {
            List<StudentInCourse> ListStudInCourses = XMLTools.LoadListFromXMLSerializer<StudentInCourse>(studInCoursesPath);

            ListStudInCourses.RemoveAll(p => p.PersonId == perID);

            XMLTools.SaveListToXMLSerializer(ListStudInCourses, studInCoursesPath);

        }

        #endregion StudentInCourse

        #region Course
        public DO.Course GetCourse(int id)
        {
            List<Course> ListCourses = XMLTools.LoadListFromXMLSerializer<Course>(coursesPath);

            return ListCourses.Find(c => c.ID == id); //no need to Clone()

            //if not exist throw exception etc.
        }

        public IEnumerable<DO.Course> GetAllCourses()
        {
            List<Course> ListCourses = XMLTools.LoadListFromXMLSerializer<Course>(coursesPath);

            return from course in ListCourses
                   select course; //no need to Clone()
        }

        #endregion Course

        #region Lecturer
        public IEnumerable<DO.LecturerInCourse> GetLecturersInCourseList(Predicate<DO.LecturerInCourse> predicate)
        {
            List<LecturerInCourse> ListLectInCourses = XMLTools.LoadListFromXMLSerializer<LecturerInCourse>(lectInCoursesPath);

            return from sic in ListLectInCourses
                   where predicate(sic)
                   select sic; //no need to Clone()
        }













        public IEnumerable<LineStationDO> GetAllLineStationsBy(Predicate<LineStationDO> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(int lineKey, int stationKey, Action<LineStationDO> toUpdate)
        {
            throw new NotImplementedException();
        }

        public LineStationDO GetLineStation(int stationKey, int lineId)
        {
            throw new NotImplementedException();
        }

        public void AddLineStation(LineStationDO station)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineStation(int lineKey, int stationKey)
        {
            throw new NotImplementedException();
        }

        public void AddBusStation(BusStationDO station)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusStationDO> GetAllStations()
        {
            throw new NotImplementedException();
        }

        public BusStationDO GetBusStation(int key)
        {
            throw new NotImplementedException();
        }

        public void DeleteBusStation(int key)
        {
            throw new NotImplementedException();
        }

        public void UpdateBusStation(BusStationDO station)
        {
            throw new NotImplementedException();
        }

        public ConsecutiveStationsDO GetConsecutiveStations(int stationKey1, int stationKey2)
        {
            throw new NotImplementedException();
        }

        public void AddConsecutiveStations(ConsecutiveStationsDO stations)
        {
            throw new NotImplementedException();
        }

        public void UpdateConsecutiveStations(int stationKey1, int stationKey2, Action<ConsecutiveStationsDO> toUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusLineScheduleDO> GetAllSchedulesBy(Predicate<BusLineScheduleDO> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateSchedule(int lineId, TimeSpan start, Action<BusLineScheduleDO> toUpdate)
        {
            throw new NotImplementedException();
        }

        public void DeleteSchedule(int lineId, TimeSpan start)
        {
            throw new NotImplementedException();
        }

        public void AddSchedule(BusLineScheduleDO toadd)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
