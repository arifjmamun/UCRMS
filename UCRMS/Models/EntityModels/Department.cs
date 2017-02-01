using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS.Models.EntityModels
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Code cannot be empty.")]
        [StringLength(7,MinimumLength = 2, ErrorMessage = "Length - Max: 7 Char and Min: 2 Char.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Department Name cannot be empty.")]
        [StringLength(60, ErrorMessage = "Maximum Length: 60 Char.")]
        public string Name { get; set; }
    }
}