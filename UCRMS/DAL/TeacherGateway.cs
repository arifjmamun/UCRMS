using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

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

                Command.Parameters.AddWithValue("@Email", email);
                int countRow = (int)Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}