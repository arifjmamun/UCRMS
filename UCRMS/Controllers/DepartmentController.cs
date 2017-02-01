using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.Models.EntityModels;

namespace UCRMS.Controllers
{
    public class DepartmentController : Controller
    {
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
            return View(department);
        }

        // GET: Show All Departments
        [HttpGet]
        public ActionResult ViewAll()
        {
            return View();
        }
    }
}