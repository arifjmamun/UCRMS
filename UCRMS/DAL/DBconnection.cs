using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UCRMS.DAL
{
    public class DBconnection
    {
        protected SqlConnection Connection;
        protected SqlCommand Command;
        protected SqlDataReader Reader;
        protected SqlDataAdapter Adapter;

        public DBconnection()
        {
            Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[""].ConnectionString);
            Command = new SqlCommand();
            Command.Connection = Connection;
        }
    }
}