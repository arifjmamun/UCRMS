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

        public Dictionary<bool,string> Save(Department department)
        {
            Dictionary<bool, string> status = new Dictionary<bool, string>();
            if (IsCodeAvailable(department.Code) && IsNameAvailable(department.Name))
            {
                int affectedRow = _departmentGateway.Save(department);
                if (affectedRow > 0) status.Add(true, "Department Added");
                status.Add(true, "Department Not Added");
                
            }
            else if (!IsCodeAvailable(department.Code) && !IsNameAvailable(department.Name))
            {
                status.Add(false, "Department Code and Name are already exists.");
            }
            else if (!IsCodeAvailable(department.Code))
            {
                status.Add(false, "Department Code is already exists.");
            }
            else
            {
                status.Add(false, "Department Name is already exists.");
            }
            return status;
        }

        private bool IsCodeAvailable(string code)
        {
            int countRow = _departmentGateway.IsCodeAvailable(code);
            if (countRow > 0) return false;
            return true;
        }

        private bool IsNameAvailable(string name)
        {
            int countRow = _departmentGateway.IsNameAvailable(name);
            if (countRow > 0) return false;
            return true;
        }

        public List<Department> GetAll()
        {
            return _departmentGateway.GetAll();
        }
    }
}