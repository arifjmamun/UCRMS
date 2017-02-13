using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.BLL;
using UCRMS.Models.EntityModels;

namespace UCRMS.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager _departmentManager = new DepartmentManager();
        
        // GET: Department
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        // POST: Department
        [HttpPost]
        public ActionResult Save(Department department)
        {
            if (ModelState.IsValid)
            {
                ArrayList status = _departmentManager.Save(department);
                ViewBag.Status = status;
                if ((bool) status[0])
                {
                    ModelState.Clear();
                    return View(new Department());
                }
                return View(department);
            }
            return View(department);
        }

        // GET: Show All Departments
        [HttpGet]
        public ActionResult ViewAll()
        {
            var departments = _departmentManager.GetAll();
            if (departments != null)
            {
                return View(departments);
            }
            ViewBag.Message = "No records found.";
            return View(new List<Department>());
        }
    }
}