using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMS.Models.ViewModels
{
    public class TeacherCourse
    {
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public decimal CreditToBeTaken { get; set; }
        public decimal RemainingCredit { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal CourseCredit { get; set; }
    }
}