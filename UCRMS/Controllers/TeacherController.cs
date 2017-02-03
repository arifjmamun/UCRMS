using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.BLL;
using UCRMS.Models.EntityModels;

namespace UCRMS.Controllers
{
    public class TeacherController : Controller
    {
        DesignationManager _designationManager = new DesignationManager();
        DepartmentManager _departmentManager = new DepartmentManager();
        TeacherManager _teacherManager = new TeacherManager();
        // GET: Teacher
        [HttpGet]
        public ActionResult Save()
        {
            var designations = _designationManager.GetAll();
            var departments = _departmentManager.GetAll();
            ViewBag.Designations = new SelectList(designations, "Id", "Name");
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            var designations = _designationManager.GetAll();
            var departments = _departmentManager.GetAll();
            ViewBag.Designations = new SelectList(designations, "Id", "Name");
            ViewBag.Departments = new SelectList(departments, "Id", "Name");

            if (ModelState.IsValid)
            {
                ViewBag.Status = _teacherManager.Save(teacher);
            }

            return View(teacher);
        }
    }
}