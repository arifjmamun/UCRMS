using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.BLL;
using UCRMS.Models.EntityModels;

namespace UCRMS.Controllers
{
    public class CourseController : Controller
    {
        CourseManager _courseManager = new CourseManager();
        SemesterManager _semesterManager = new SemesterManager();
        DepartmentManager _departmentManager = new DepartmentManager();

        // GET: Course
        [HttpGet]
        public ActionResult Save()
        {
            var departments = _departmentManager.GetAll() ?? new List<Department>();
            var semesters = _semesterManager.GetAll() ?? new List<Semester>();
            ViewBag.Semesters = new SelectList(semesters, "Id", "Name");
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        // POST: Course
        [HttpPost]
        public ActionResult Save(Course course)
        {
            var departments = _departmentManager.GetAll() ?? new List<Department>();
            var semesters = _semesterManager.GetAll() ?? new List<Semester>();
            ViewBag.Semesters = new SelectList(semesters, "Id", "Name");
            ViewBag.Departments = new SelectList(departments, "Id", "Name");

            if (ModelState.IsValid)
            {
                ViewBag.Status = _courseManager.Save(course);
                ModelState.Clear();
                return View();
            }
            return View(course);
        }

        [HttpGet]
        public ActionResult ViewCourseStatics()
        {
            var departments = _departmentManager.GetAll() ?? new List<Department>();
            ViewBag.Departments = new SelectList(departments,"Id","Name");
            return View();
        }

        public JsonResult GetCourseStaticsByDepartmentId(int departmentId)
        {
            var courses = _courseManager.GetCourseStaticsByDepartmentId(departmentId);
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UnassignAllCourses()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnassignAllCourses(bool isClicked)
        {
            if (isClicked)
            {
                ViewBag.Status = _courseManager.UnassignAllCourses();
            }
            return View();
        }
    }
}