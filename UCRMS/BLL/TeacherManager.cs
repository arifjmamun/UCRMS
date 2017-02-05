using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models.EntityModels;
using UCRMS.Models.ViewModels;

namespace UCRMS.BLL
{
    public class TeacherManager
    {
        TeacherGateway _teacherGateway = new TeacherGateway();
        CourseGateway _courseGateway  = new CourseGateway();

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

        public List<Teacher> GetAllTeacherByDepartmentId(int departmentId)
        {
            return _teacherGateway.GetAllTeacherByDepartmentId(departmentId);
        }

        public TeacherCourse GetTeacherCourseCreditInfoByTeacherId(int teacherId)
        {
            decimal totalTakenCredit = GetTotalTakenCredit(teacherId);
            decimal creditToBeTaken = GetCreditToBeTaken(teacherId);

            TeacherCourse teacherCourse = new TeacherCourse
            {
                RemainingCredit = creditToBeTaken - totalTakenCredit,
                CreditToBeTaken = creditToBeTaken
            };
            return teacherCourse;
        }

        private decimal GetCreditToBeTaken(int teacherId)
        {
            return _teacherGateway.GetCreditToBeTaken(teacherId);
        }

        private decimal GetTotalTakenCredit(int teacherId)
        {
            return _teacherGateway.GetTotalTakenCredit(teacherId);
        }

        public string[] AssignCourse(TeacherCourse teacherCourse)
        {
            if (IsCourseAssignable(teacherCourse.CourseId))
            {
                int affectedRow = _teacherGateway.AssignCourse(teacherCourse);
                if (affectedRow > 0) return new string[] { "alert-success", "Success!", "Course assigned to the teacher." };
                return new string[] { "alert-danger", "Error!", "Course not assigned to the teacher." };
            }
            return new string[] { "alert-danger", "Error!", "Course already assigned to a teahcer." };
        }

        private bool IsCourseAssignable(int courseId)
        {
            int countRow = _courseGateway.IsCourseAssignable(courseId);
            if (countRow > 0) return false;
            return true;
        }
    }
}