using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UCRMS.Models.EntityModels;

namespace UCRMS.DAL
{
    public class CourseGateway : DBconnection
    {
        public int IsCodeAvailable(string code)
        {
            try
            {
                const string storedProcedure = "IsCourseCodeAvailable";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storedProcedure;

                Command.Parameters.AddWithValue("@Code", code);
                int countRow = (int)Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int IsNameAvailable(string name)
        {
            try
            {
                const string storedProcedure = "IsCourseNameAvailable";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storedProcedure;

                Command.Parameters.AddWithValue("@Name", name);
                int countRow = (int)Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int Save(Course course)
        {
            try
            {
                const string storedProcedure = "SaveCourse";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storedProcedure;

                Command.Parameters.AddWithValue("@Code", course.Code);
                Command.Parameters.AddWithValue("@Name", course.Name);
                Command.Parameters.AddWithValue("@Credit", course.Credit);
                Command.Parameters.AddWithValue("@Description", course.Description);
                Command.Parameters.AddWithValue("@DepartmentId", course.DepartmentId);
                Command.Parameters.AddWithValue("@SemesterId", course.SemesterId);
                Command.Parameters.AddWithValue("@Assigned", course.Assigned);
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