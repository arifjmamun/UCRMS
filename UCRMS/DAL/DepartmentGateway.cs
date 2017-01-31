﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UCRMS.Models.EntityModels;

namespace UCRMS.DAL
{
    public class DepartmentGateway : DBconnection
    {
        public int IsCodeAvailable(string code)
        {
            try
            {
                const string storeProcedure = "IsDepartmentCodeAvailable";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;

                Command.Parameters.AddWithValue("@Code", code);
                int countRow = (int) Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        internal int IsNameAvailable(string name)
        {
            try
            {
                const string storeProcedure = "IsDepartmentNameAvailable";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;

                Command.Parameters.AddWithValue("@Name", name);
                int countRow = (int)Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int Save(Department department)
        {
            try
            {
                const string storeProcedure = "SaveDepartment";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;

                Command.Parameters.AddWithValue("@Code", department.Code);
                Command.Parameters.AddWithValue("@Name", department.Name);
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