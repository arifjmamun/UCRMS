using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UCRMS.Models.EntityModels;

namespace UCRMS.DAL
{
    public class ClassRoomGateway : DBconnection
    {
        public List<Room> GetAllRooms()
        {
            try
            {
                List<Room> rooms = null;
                const string storeProcedure = "GetAllRooms";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    rooms = new List<Room>();
                    while (Reader.Read())
                    {
                        var room = new Room
                        {
                            Id = (int)Reader["Id"],
                            Code = Reader["Code"].ToString(),
                            Name = Reader["Name"].ToString()
                        };
                        rooms.Add(room);
                    }
                    Reader.Close();
                }
                return rooms;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}