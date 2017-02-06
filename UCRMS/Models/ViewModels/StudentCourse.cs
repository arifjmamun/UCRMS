using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS.Models.ViewModels
{
    public class StudentCourse
    {
        [Required(ErrorMessage = "Select a student registration number.")]
        [Display(Name = "Student Reg. No.")]
        public string StudentRegNo { get; set; }

        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Display(Name = "Email")]
        public string StudentEmail { get; set; }

        [Display(Name = "Department")]
        public string StudentDepartment { get; set; }

        [Required(ErrorMessage = "Select a course to enroll.")]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Date cannot be empty.")]
        [DisplayFormat(DataFormatString = "0:{yyyy-MM-dd}")]
        [Display(Name = "Date")]
        public DateTime EnrollDate { get; set; }


    }
}