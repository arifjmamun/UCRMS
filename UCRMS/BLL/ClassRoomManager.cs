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
            if (IsGivenTimeValid(classRoomCourse))
            {
                if (IsTimeAvailable(classRoomCourse))
                {
                    int affectedRow = _classRoomGateway.AllocateClass(classRoomCourse);
                    if (affectedRow > 0) return new string[] { "alert-success", "Success!", "Classroom allocated." };
                    return new string[] { "alert-danger", "Error!", "Classsroom not allocated." };
                }
                return new string[] { "alert-danger", "Error!", "Given time overlaps with the existing class schedule." };
            }
            return new string[] { "alert-danger", "Error!", "Inavid! Class starting time must be less than ending time." };
        }

        private bool IsGivenTimeValid(ClassRoomCourse classRoomCourse)
        {
            DateTime startTime = Convert.ToDateTime(classRoomCourse.StartFrom + ":00");
            DateTime endTime = Convert.ToDateTime(classRoomCourse.EndTo + ":00");

            return startTime.TimeOfDay < endTime.TimeOfDay;
        }

        private bool IsTimeAvailable(ClassRoomCourse classRoomCourse)
        {
            return IsStartTimeAvailable(classRoomCourse) && IsEndTimeAvailable(classRoomCourse);
        }
        
        private bool IsStartTimeAvailable(ClassRoomCourse classRoomCourse)
        {
            int countRow = _classRoomGateway.IsStartTimeAvailable(classRoomCourse);
            if (countRow > 0) return false;
            return true;
        }

        private bool IsEndTimeAvailable(ClassRoomCourse classRoomCourse)
        {
            int countRow = _classRoomGateway.IsEndTimeAvailable(classRoomCourse);
            if (countRow > 0) return false;
            return true;
        }

        public List<ClassRoomCourse> GetClassRoomAllocationInfoByDepartmentId(int departmentId)
        {
            return _classRoomGateway.GetClassRoomAllocationInfoByDepartmentId(departmentId);
            
        }
    }
}