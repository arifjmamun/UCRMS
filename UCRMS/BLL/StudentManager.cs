using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;

namespace UCRMS.BLL
{
    public class StudentManager
    {
        StudentGateway _studentGateway = new StudentGateway();
        
        public string CountStudentByDepartmentId(int departmentId)
        {
            int countStudent = _studentGateway.CountStudentByDepartmentId(departmentId);
            countStudent++;
            return countStudent.ToString("000");
        }
    }
}