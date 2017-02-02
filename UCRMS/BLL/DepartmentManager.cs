using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models.EntityModels;

namespace UCRMS.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway _departmentGateway = new DepartmentGateway();

        public string[] Save(Department department)
        {
            if (IsDepartmentAvailable(department))
            {
                int affectedRow = _departmentGateway.Save(department);
                if (affectedRow > 0) return new string[] { "alert-success", "Success!", "Department Added." };
                return new string[] { "alert-danger", "Error!", "Department Not Added." };
            }
            return new string[] { "alert-danger", "Error!", "Department Code or Name already exists." };
            
        }

        private bool IsDepartmentAvailable(Department department)
        {
            int countRow = _departmentGateway.IsDepartmentAvailable(department);
            if (countRow > 0) return false;
            return true;
        }

        public List<Department> GetAll()
        {
            return _departmentGateway.GetAll();
        }
    }
}