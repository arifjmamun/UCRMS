using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models.EntityModels;

namespace UCRMS.BLL
{
    public class CourseManager
    {
        CourseGateway _courseGateway = new CourseGateway();

        public string[] Save(Course course)
        {
            if (IsCourseAvailable(course))
            {
                int affectedRow = _courseGateway.Save(course);
                if (affectedRow > 0) return new string[] { "alert-success", "Success!", "Course Added." };
                return new string[] { "alert-danger", "Error!", "Course Not Added." };
            }
            return new string[] { "alert-danger", "Error!", "Course Code or Name already exists." };
        }

        private bool IsCourseAvailable(Course course)
        {
            int countRow = _courseGateway.IsCourseAvailable(course);
            if (countRow > 0) return false;
            return true;
        }
    }
}