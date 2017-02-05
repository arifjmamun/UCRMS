using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UCRMS.Models.EntityModels;
using UCRMS.Models.ViewModels;

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
                Command.Parameters.Clear();
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
                Command.Parameters.Clear();
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
                Command.Parameters.Clear();
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

        public int IsCourseAvailable(Course course)
        {
            try
            {
                const string storeProcedure = "IsCourseAvailable";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Code", course.Code);
                Command.Parameters.AddWithValue("@Name", course.Name);
                int countRow = (int)Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Course> GetAllCourseByDepartmentId(int departmentId)
        {
            try
            {
                List<Course> courses = null;
                const string storeProcedure = "GetAllCourseByDepartmentId";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@DepartmentId", departmentId);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    courses = new List<Course>();
                    while (Reader.Read())
                    {
                        var course = new Course
                        {
                            Id = (int)Reader["Id"],
                            Code = Reader["Code"].ToString()
                        };
                        courses.Add(course);
                    }
                    Reader.Close();
                }
                return courses;
            }
            finally
            {
                Connection.Close();
            }
        }

        public Course GetCourseInfoByCourseId(int courseId)
        {
            try
            {
                Course course = null;
                const string storeProcedure = "GetCourseInfoByCourseId";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Id", courseId);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    if (Reader.Read())
                    {
                        course = new Course
                        {
                            Name = Reader["Name"].ToString(), 
                            Credit = (decimal)Reader["Credit"]
                        };
                    }
                    Reader.Close();
                }
                return course;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int IsCourseAssignable(int courseId)
        {
            try
            {
                const string storeProcedure = "IsCourseAssigned";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Id", courseId);
                int countRow = Convert.ToInt32(Command.ExecuteScalar());
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}