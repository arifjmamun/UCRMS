using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using UCRMS.BLL;

namespace UCRMS.Models.EntityModels
{
    public class Student
    {
        DepartmentManager _departmentManager = new DepartmentManager();
        StudentManager _studentManager = new StudentManager();
        public int Id { get; set; }

        public string RegNo { get; set; }

        [Required(ErrorMessage = "Name cannot be empty.")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters allowed.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address cannot be empty.")]
        [StringLength(100, ErrorMessage = "Maximum 100 characters allowed.")]
        [EmailAddress(ErrorMessage = "Invalid! Select a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact number cannot be empty.")]
        [StringLength(20, ErrorMessage = "Maximum 20 characters allowed.")]
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Date cannot be empty.")]
        [DisplayFormat(DataFormatString = "0:{yyyy-MM-dd}")]
        [Display(Name = "Date")]
        public DateTime RegDate { get; set; }

        [Required(ErrorMessage = "Address cannot be empty.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Select a Department.")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public string GenerateRegNo()
        {
            int departmentId = DepartmentId;
            string departmentCode = _departmentManager.GetDepartmentCode(departmentId);
            string currentYear = RegDate.Year.ToString();
            string countStudent = _studentManager.CountStudentByDepartmentId(departmentId);
            string regNo = departmentCode + "-" + currentYear + "-" + countStudent;
            return regNo;
        }
    }
}