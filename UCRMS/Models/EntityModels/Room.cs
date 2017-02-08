using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMS.Models.EntityModels
{
    public class Room
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public sbyte Allocated { get; set; }
    }
}