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

        public Dictionary<bool, string> Save(Course course)
        {
            Dictionary<bool, string> status = new Dictionary<bool, string>();
            if (IsCodeAvailable(course.Code) && IsNameAvailable(course.Name))
            {
                int affectedRow = _courseGateway.Save(course);
                if (affectedRow > 0) status.Add(true, "Course Added");
                status.Add(true, "Course Not Added");

            }
            else if (!IsCodeAvailable(course.Code) && !IsNameAvailable(course.Name))
            {
                status.Add(false, "Course Code and Name are already exists.");
            }
            else if (!IsCodeAvailable(course.Code))
            {
                status.Add(false, "Course Code is already exists.");
            }
            else
            {
                status.Add(false, "Course Name is already exists.");
            }
            return status;
        }

        private bool IsCodeAvailable(string code)
        {
            int countRow = _courseGateway.IsCodeAvailable(code);
            if (countRow > 0) return false;
            return true;
        }

        private bool IsNameAvailable(string name)
        {
            int countRow = _courseGateway.IsNameAvailable(name);
            if (countRow > 0) return false;
            return true;
        }
    }
}