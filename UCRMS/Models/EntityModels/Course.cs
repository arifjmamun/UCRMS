using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS.Models.EntityModels
{
    public class Course
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Course Code cannot be empty.")]
        [StringLength(15,MinimumLength = 5, ErrorMessage = "Minimum length 5 Character.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Course Name cannot be empty.")]
        [StringLength(100, ErrorMessage = "Maximum length 100 Character.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Course Credit cannot be empty.")]
        [Range(0.5, 5.0, ErrorMessage = "Credit valid range: 0.5 to 5.0")]
        public decimal? Credit { get; set; }

        [Required(ErrorMessage = "Course Description cannot be empty.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Select a Department.")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Select a Semester.")]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        [Required]
        public byte Assigned { get; set; }

    }
}