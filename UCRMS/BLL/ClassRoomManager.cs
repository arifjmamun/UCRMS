using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models.EntityModels;
using UCRMS.Models.ViewModels;

namespace UCRMS.BLL
{
    public class ClassRoomManager
    {
        ClassRoomGateway _classRoomGateway = new ClassRoomGateway();
        public List<Room> GetAllRooms()
        {
            return _classRoomGateway.GetAllRooms();
        }

        public string[] AllocateClass(ClassRoomCourse classRoomCourse)
        {
            throw new NotImplementedException();
        }
    }
}