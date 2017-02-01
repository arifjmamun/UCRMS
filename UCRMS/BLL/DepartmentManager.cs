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
            //if (IsCodeAvailable(department.Code) && IsNameAvailable(department.Name))
            //{
            //    int affectedRow = _departmentGateway.Save(department);
            //    if (affectedRow > 0) return new string[] { "alert-success", "Success!", "Department Added" };
            //    return new string[] { "alert-danger", "Error!", "Department Not Added" };
            //}
            //else if (!IsCodeAvailable(department.Code) && !IsNameAvailable(department.Name))
            //{
            //    return new string[] { "alert-danger", "Error!", "Department Code and Name are already exists." };
            //}
            //else if (!IsCodeAvailable(department.Code) && IsNameAvailable(department.Name))
            //{
            //    return new string[] { "alert-danger", "Error!", "Department Code is already exists." };
            //}
            //else
            //{
            //    return new string[] {"alert-danger", "Error!", "Department Name is already exists."};
            //}
        }

        //private bool IsCodeAvailable(string code)
        //{
        //    int countRow = _departmentGateway.IsCodeAvailable(code);
        //    if (countRow > 0) return false;
        //    return true;
        //}

        //private bool IsNameAvailable(string name)
        //{
        //    int countRow = _departmentGateway.IsNameAvailable(name);
        //    if (countRow > 0) return false;
        //    return true;
        //}

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