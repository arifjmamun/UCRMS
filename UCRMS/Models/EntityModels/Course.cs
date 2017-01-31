using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMS.Models.EntityModels
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Credit { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public int SemesterId { get; set; }
        public byte Assigned { get; set; }
    }
}