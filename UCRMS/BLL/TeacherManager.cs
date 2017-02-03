using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models.EntityModels;

namespace UCRMS.BLL
{
    public class TeacherManager
    {
        TeacherGateway _teacherGateway = new TeacherGateway();

        private bool IsEmailAvailable(string email)
        {
            int countRow = _teacherGateway.IsEmailAvailable(email);
            if (countRow > 0) return false;
            return true;
        }

        public string[] Save(Teacher teacher)
        {
            if (IsEmailAvailable(teacher.Email))
            {
                int affectedRow = _teacherGateway.Save(teacher);
                if (affectedRow > 0) return new string[] { "alert-success", "Success!", "Teacher Saved." };
                return new string[] { "alert-danger", "Error!", "Teacher not saved." };
            }
            return new string[] { "alert-danger", "Error!", "Teacher email already exists." };
        }
    }
}