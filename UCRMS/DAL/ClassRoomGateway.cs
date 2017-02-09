using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using UCRMS.Models.EntityModels;
using UCRMS.Models.ViewModels;

namespace UCRMS.DAL
{
    public class ClassRoomGateway : DBconnection
    {
        public List<Room> GetAllRooms()
        {
            try
            {
                List<Room> rooms = null;
                const string storeProcedure = "GetAllRooms";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    rooms = new List<Room>();
                    while (Reader.Read())
                    {
                        var room = new Room
                        {
                            Id = (int)Reader["Id"],
                            Code = Reader["Code"].ToString(),
                            Name = Reader["Name"].ToString()
                        };
                        rooms.Add(room);
                    }
                    Reader.Close();
                }
                return rooms;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int IsStartTimeAvailable(ClassRoomCourse classRoomCourse)
        {
            try
            {
                const string storeProcedure = "IsStartTimeAvailableForClassSchedule";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@RoomId", classRoomCourse.RoomId);
                Command.Parameters.AddWithValue("@DayCode", classRoomCourse.DayCode);
                Command.Parameters.AddWithValue("@StartFrom", classRoomCourse.StartFrom);
                Command.Parameters.AddWithValue("@EndTo", classRoomCourse.EndTo);
                int countRow = (int)Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int IsEndTimeAvailable(ClassRoomCourse classRoomCourse)
        {
            try
            {
                const string storeProcedure = "IsEndTimeAvailableForClassSchedule";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@RoomId", classRoomCourse.RoomId);
                Command.Parameters.AddWithValue("@DayCode", classRoomCourse.DayCode);
                Command.Parameters.AddWithValue("@StartFrom", classRoomCourse.StartFrom);
                Command.Parameters.AddWithValue("@EndTo", classRoomCourse.EndTo);
                int countRow = (int)Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int AllocateClass(ClassRoomCourse classRoomCourse)
        {
            try
            {
                const string storedProcedure = "AllocateClassRoom";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storedProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@DepartmentId", classRoomCourse.DepartmentId);
                Command.Parameters.AddWithValue("@CourseId", classRoomCourse.CourseId);
                Command.Parameters.AddWithValue("@RoomId", classRoomCourse.RoomId);
                Command.Parameters.AddWithValue("@DayCode", classRoomCourse.DayCode);
                Command.Parameters.AddWithValue("@StartFrom", classRoomCourse.StartFrom);
                Command.Parameters.AddWithValue("@EndTo", classRoomCourse.EndTo);
                int affectedRow = Command.ExecuteNonQuery();
                return affectedRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<ClassRoomCourse> GetClassRoomAllocationInfoByDepartmentId(int departmentId)
        {
            try
            {
                List<ClassRoomCourse> classRoomCourses = null;
                const string storeProcedure = "GetClassScheduleAllocationInfo";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@DepartmentId", departmentId);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    string courseCode = "";
                    classRoomCourses = new List<ClassRoomCourse>();
                    ClassRoomCourse classRoomCourse = null;
                    bool isNew = false;
                    while (Reader.Read())
                    {
                        string readerCourseCode = Reader["CourseCode"].ToString();
                        if (courseCode != readerCourseCode)
                        {
                            classRoomCourse = new ClassRoomCourse();
                            isNew = false;
                        }
                        else
                        {
                            isNew = true;
                        }
                        courseCode = Reader["CourseCode"].ToString();
                        classRoomCourse.CourseCode = courseCode;
                        classRoomCourse.CourseName = Reader["CourseName"].ToString();
                        string roomNo = Reader["RoomNo"].ToString();
                        if (roomNo != "")
                        {
                            string day = Reader["DayCode"].ToString();
                            DateTime startFrom = Convert.ToDateTime(Reader["StartFrom"].ToString().Substring(0, 8));
                            DateTime endTo = Convert.ToDateTime(Reader["EndTo"].ToString().Substring(0, 8));
                            classRoomCourse.ScheduleInfo += "R. No : " + roomNo + ", " + day + ", " + startFrom.ToString("hh:m tt") + " - " + endTo.ToString("hh:m tt") + ";<br/>";
                        }
                        else
                        {
                            classRoomCourse.ScheduleInfo = "Not Scheduled Yet";
                        }
                        if(!isNew) classRoomCourses.Add(classRoomCourse);
                        
                    }
                    Reader.Close();
                }
                return classRoomCourses;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}