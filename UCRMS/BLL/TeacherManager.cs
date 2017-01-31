using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;

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
    }
}