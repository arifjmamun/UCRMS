using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace UCRMS.Models.ViewModels
{
    public class StudentResult
    {

        [Required(ErrorMessage = "Select a student registration number.")]
        [Display(Name = "Student Reg. No.")]
        public int StudentId { get; set; }

        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Display(Name = "Email")]
        public string StudentEmail { get; set; }

        [Display(Name = "Department")]
        public string StudentDepartment { get; set; }

        [Required(ErrorMessage = "Select a course.")]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Select a grdade letter")]
        [Display(Name = "Select Grade Letter")]
        public string GradeLetter { get; set; }

        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Display(Name = "Name")]
        public string CourseName { get; set; }

    }
}