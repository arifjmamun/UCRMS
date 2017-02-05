using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS.Models.ViewModels
{
    public class TeacherCourse
    {
        [Required(ErrorMessage = "First, select a Department.")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        
        [Required(ErrorMessage = "Then, select a Teacher.")]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        [Display(Name = "Credit to be taken")]
        public decimal CreditToBeTaken { get; set; }

        [Display(Name = "Remaining Credit")]
        public decimal RemainingCredit { get; set; }

        [Required(ErrorMessage = "Then, select a Course.")]
        [Display(Name = "Course Code")]
        public int CourseId { get; set; }

        [Display(Name = "Name")]
        public string CourseName { get; set; }

        [Display(Name = "Credit")]
        public decimal CourseCredit { get; set; }

        [Required]
        public string AssignedDate { get; set; }

        public TeacherCourse()
        {
            AssignedDate = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}