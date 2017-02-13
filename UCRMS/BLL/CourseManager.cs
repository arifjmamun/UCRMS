using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models.EntityModels;
using UCRMS.Models.ViewModels;

namespace UCRMS.BLL
{
    public class CourseManager
    {
        CourseGateway _courseGateway = new CourseGateway();

        public ArrayList Save(Course course)
        {
            if (IsCourseAvailable(course))
            {
                int affectedRow = _courseGateway.Save(course);
                if (affectedRow > 0) return new ArrayList {true, "alert-success", "Success!", "Course Added." };
                return new ArrayList {false, "alert-danger", "Error!", "Course Not Added." };
            }
            return new ArrayList {false, "alert-danger", "Error!", "Course Code or Name already exists." };
        }

        private bool IsCourseAvailable(Course course)
        {
            int countRow = _courseGateway.IsCourseAvailable(course);
            if (countRow > 0) return false;
            return true;
        }

        public List<Course> GetAllCourseByDepartmentId(int departmentId)
        {
            return _courseGateway.GetAllCourseByDepartmentId(departmentId);
        }

        public Course GetCourseInfoByCourseId(int courseId)
        {
            return _courseGateway.GetCourseInfoByCourseId(courseId);
        }

        public List<CourseStatics> GetCourseStaticsByDepartmentId(int departmentId)
        {
            return _courseGateway.GetCourseStaticsByDepartmentId(departmentId);
        }

        public List<Course> GetAllCourseByStudentId(int studentId)
        {
            return _courseGateway.GetAllCourseByStudentId(studentId);
        }

        public List<Course> GetEnrolledCoursesByStudentId(int studentId)
        {
            return _courseGateway.GetEnrolledCoursesByStudentId(studentId);
        }

        public string[] UnassignAllCourses()
        {
            int affectedRow = _courseGateway.UnassignAllCourses();
            if (affectedRow > 0) return new string[] { "alert-success", "Success!", "All Course Unassigned successfully." };
            return new string[] { "alert-danger", "Error!", "Courses not Unassigned." };
        }
    }
}