using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UCRMS.Models.EntityModels;

namespace UCRMS.DAL
{
    public class DesignationGateway : DBconnection
    {
        public List<Designation> GetAll()
        {
            try
            {
                List<Designation> designations = new List<Designation>();
                const string storeProcedure = "GetAllDesignation";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        var designation = new Designation
                        {
                            Id = (int)Reader["id"],
                            Code = Reader["Code"].ToString(),
                            Name = Reader["Name"].ToString()
                        };
                        designations.Add(designation);
                    }
                    Reader.Close();
                }
                return designations;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}