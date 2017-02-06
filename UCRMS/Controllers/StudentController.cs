using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.BLL;
using UCRMS.Models.EntityModels;

namespace UCRMS.Controllers
{
    public class StudentController : Controller
    {
        DepartmentManager _departmentManager = new DepartmentManager();
        StudentManager _studentManager = new StudentManager();

        // GET: Srudent
        [HttpGet]
        public ActionResult Register()
        {
            var departments = _departmentManager.GetAll();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Register(Student student)
        {
            var departments = _departmentManager.GetAll();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            if (ModelState.IsValid)
            {
                student.RegNo = student.GenerateRegNo();
                ViewBag.Status = _studentManager.Register(student);
                ModelState.Clear();
                return View();
            }
            return View(student);
        }
    }
}