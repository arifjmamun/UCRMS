using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.BLL;
using UCRMS.Models.EntityModels;
using UCRMS.Models.ViewModels;

namespace UCRMS.Controllers
{
    public class StudentController : Controller
    {
        DepartmentManager _departmentManager = new DepartmentManager();
        StudentManager _studentManager = new StudentManager();
        CourseManager _courseManager = new CourseManager();
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

        [HttpGet]
        public ActionResult EnrollCourse()
        {
            var students = _studentManager.GetAll();
            ViewBag.Students = new SelectList(students, "Id", "RegNo");
            return View();
        }

        [HttpPost]
        public ActionResult EnrollCourse(StudentCourse studentCourse)
        {
            var students = _studentManager.GetAll();
            ViewBag.Students = new SelectList(students, "Id", "RegNo");
            if (ModelState.IsValid)
            {
                ViewBag.Status = _studentManager.EnrollInCourse(studentCourse);
                ModelState.Clear();
                return View();
            }
            return View(studentCourse);
        }

        public JsonResult GetStudentCourseInfoByStudentId(int studentId)
        {
            var student = _studentManager.GetStudentByStudentId(studentId);
            var courses = _courseManager.GetAllCourseByStudentId(studentId);
            var studentAndCourses = new
            {
                student = student,
                courses = courses
            };
            return Json(studentAndCourses, JsonRequestBehavior.AllowGet);
        }
    }
}