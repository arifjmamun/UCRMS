using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UCRMS.Models.EntityModels;

namespace UCRMS.DAL
{
    public class StudentGateway : DBconnection
    {
        public int CountStudentByDepartmentId(int departmentId)
        {
            try
            {
                const string storeProcedure = "CountStudentByDepartmentId";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@DepartmentId", departmentId);
                int countStudent = (int)Command.ExecuteScalar();
                return countStudent;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int IsEmailAvailable(string email)
        {
            try
            {
                const string storeProcedure = "IsStudentEmailAvailable";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Email", email);
                int countRow = (int)Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int Register(Student student)
        {
            try
            {
                const string storedProcedure = "SaveStudent";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storedProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@RegNo", student.RegNo);
                Command.Parameters.AddWithValue("@Name", student.Name);
                Command.Parameters.AddWithValue("@Email", student.Email);
                Command.Parameters.AddWithValue("@ContactNo", student.ContactNo);
                Command.Parameters.AddWithValue("@RegDate", student.RegDate);
                Command.Parameters.AddWithValue("@Address", student.Address);
                Command.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);
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