using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models.EntityModels;
using UCRMS.Models.ViewModels;

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

        public string[] Register(Student student)
        {
            if (IsEmailAvailable(student.Email))
            {
                int affectedRow = _studentGateway.Register(student);
                if (affectedRow > 0) return new string[] { "alert-success", "Success!", "Student Registered." };
                return new string[] { "alert-danger", "Error!", "Student not registered." };
            }
            return new string[] { "alert-danger", "Error!", "Student email already exists." };
        }

        private bool IsEmailAvailable(string email)
        {
            int countRow = _studentGateway.IsEmailAvailable(email);
            if (countRow > 0) return false;
            return true;
        }

        public List<Student> GetAll()
        {
            return _studentGateway.GetAll();
        }

        public StudentCourse GetStudentByStudentId(int studentId)
        {
            return _studentGateway.GetStudentByStudentId(studentId);
        }
    }
}