using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UCRMS.Models.EntityModels;

namespace UCRMS.DAL
{
    public class TeacherGateway : DBconnection
    {
        public int IsEmailAvailable(string email)
        {
            try
            {
                const string storeProcedure = "IsTeacherEmailAvailable";
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

        public int Save(Teacher teacher)
        {
            try
            {
                const string storedProcedure = "SaveTeacher";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storedProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Name", teacher.Name);
                Command.Parameters.AddWithValue("@Address", teacher.Address);
                Command.Parameters.AddWithValue("@Email", teacher.Email);
                Command.Parameters.AddWithValue("@ContactNo", teacher.ContactNo);
                Command.Parameters.AddWithValue("@DesignationId", teacher.DesignationId);
                Command.Parameters.AddWithValue("@DepartmentId", teacher.DepartmentId);
                Command.Parameters.AddWithValue("@CreditToBeTaken", teacher.CreditToBeTaken);
                int affectedRow = Command.ExecuteNonQuery();
                return affectedRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Teacher> GetAllTeacherByDepartmentId(int departmentId)
        {
            try
            {
                List<Teacher> teachers = null;
                const string storeProcedure = "GetAllTeacherByDepartmentId";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@DepartmentId", departmentId);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    teachers = new List<Teacher>();
                    while (Reader.Read())
                    {
                        var teacher = new Teacher
                        {
                            Id = (int)Reader["Id"],
                            Name = Reader["Name"].ToString()
                        };
                        teachers.Add(teacher);
                    }
                    Reader.Close();
                }
                return teachers;
            }
            finally
            {
                Connection.Close();
            }
        }

        public decimal GetTotalTakenCredit(int teacherId)
        {
            try
            {
                const string storeProcedure = "GetTotalTakenCreditByTeacherId";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@TeacherId", teacherId);
                decimal totalTakenCredit = (decimal)Command.ExecuteScalar();
                return totalTakenCredit;
            }
            finally
            {
                Connection.Close();
            }
        }

        public decimal GetCreditToBeTaken(int teacherId)
        {
            try
            {
                const string storeProcedure = "GetCreditToBeTakenByTeacherId";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Id", teacherId);
                decimal creditToBeTaken = (decimal)Command.ExecuteScalar();
                return creditToBeTaken;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}