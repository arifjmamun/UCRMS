using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
                Command.Parameters.AddWithValue("@DayId", classRoomCourse.DayId);
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
                Command.Parameters.AddWithValue("@DayId", classRoomCourse.DayId);
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
                Command.Parameters.AddWithValue("@DayId", classRoomCourse.DayId);
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
    }
}