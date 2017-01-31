using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models.EntityModels;

namespace UCRMS.BLL
{
    public class DesignationManager
    {
        DesignationGateway _designationGateway = new DesignationGateway();

        public List<Designation> GetAll()
        {
            return _designationGateway.GetAll();
        }
    }
}