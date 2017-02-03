using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS.Models.EntityModels
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Teacher Name cannot be empty.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Character Length: 3-50 Characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Teacher Address cannot be empty.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Teacher Email cannot be empty.")]
        [EmailAddress(ErrorMessage = "Invalid email. Follow the example: abc@email.com")]
        [StringLength(100, ErrorMessage = "Maximum 100 character allowed.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Teacher Contact number cannot be empty.")]
        [StringLength(20, ErrorMessage = "Maximum 20 characters allowed.")]
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Select a Designation.")]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        
        [Required(ErrorMessage = "Select a Department.")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "You must enter credit that to be taken.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Credit should be a positive number.")]
        [Display(Name = "Credit to be taken")]
        public decimal? CreditToBeTaken { get; set; }
    }
}