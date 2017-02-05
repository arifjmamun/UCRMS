using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS.Models.ViewModels
{
    public class CourseStatics
    {
        public string Code { get; set; }

        [Required(ErrorMessage = "Select a department.")]
        public string Department { get; set; }

        [Display(Name = "Name/Title")]
        public string Title { get; set; }

        public string Semester { get; set; }

        [Display(Name = "Assigned To")]
        public string AssignedTo { get; set; }
    }
}