using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UCRMS.Models.EntityModels;

namespace UCRMS.DAL
{
    public class SemesterGateway : DBconnection
    {

        public List<Semester> GetAll()
        {
            try
            {
                List<Semester> semesters = new List<Semester>();
                const string storeProcedure = "GetAllSemesters";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        var semester = new Semester
                        {
                            Id = (int)Reader["id"],
                            Code = Reader["Code"].ToString(),
                            Name = Reader["Name"].ToString()
                        };
                        semesters.Add(semester);
                    }
                    Reader.Close();
                }
                return semesters;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}