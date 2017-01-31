using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models.EntityModels;

namespace UCRMS.BLL
{
    public class SemesterManager
    {
        SemesterGateway _semesterGateway = new SemesterGateway();

        public List<Semester> GetAll()
        {
            return _semesterGateway.GetAll();
        }
    }
}