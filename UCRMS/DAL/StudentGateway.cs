using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

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
    }
}