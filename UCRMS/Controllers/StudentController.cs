using System;
using System.Collections;
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

        List<Grade> grades = new List<Grade>
        {
            new Grade{Name = "A+"},
            new Grade{Name = "A"},
            new Grade{Name = "A"},
            new Grade{Name = "B+"},
            new Grade{Name = "B"},
            new Grade{Name = "B-"},
            new Grade{Name = "C+"},
            new Grade{Name = "C"},
            new Grade{Name = "C-"},
            new Grade{Name = "D+"},
            new Grade{Name = "D"},
            new Grade{Name = "D-"},
            new Grade{Name = "F"}
        };

        // GET: Srudent
        [HttpGet]
        public ActionResult Register()
        {
            var departments = _departmentManager.GetAll() ?? new List<Department>();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Register(Student student)
        {
            var departments = _departmentManager.GetAll() ?? new List<Department>();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            if (ModelState.IsValid)
            {
                //student.RegNo = student.GenerateRegNo();
                ArrayList status = _studentManager.Register(student);
                ViewBag.Status = status;
                if ((bool) status[0])
                {
                    TempData["RegNo"] = status[4];
                    return RedirectToAction("ViewDetails", "Student");
                }
                return View(student);
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult ViewDetails()
        {
            if (TempData["RegNo"] != null)
            {
                string regNo = TempData["RegNo"].ToString();
                var student = _studentManager.GetStudentInfoByRegNo(regNo) ?? new Student();
                return View(student);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EnrollCourse()
        {
            var students = _studentManager.GetAll() ?? new List<Student>();
            ViewBag.Students = new SelectList(students, "Id", "RegNo");
            return View();
        }

        [HttpPost]
        public ActionResult EnrollCourse(StudentCourse studentCourse)
        {
            var students = _studentManager.GetAll() ?? new List<Student>();
            ViewBag.Students = new SelectList(students, "Id", "RegNo");
            if (ModelState.IsValid)
            {
                ArrayList status = _studentManager.EnrollInCourse(studentCourse);
                ViewBag.Status = status;
                if ((bool) status[0])
                {
                    ModelState.Clear();
                    return View(); 
                }
                return View(studentCourse);
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

        [HttpGet]
        public ActionResult SaveResult()
        {
            var students = _studentManager.GetAll() ?? new List<Student>();
            ViewBag.Students = new SelectList(students, "Id", "RegNo");
            return View();
        }

        [HttpPost]
        public ActionResult SaveResult(StudentResult studentResult)
        {
            var students = _studentManager.GetAll();
            ViewBag.Students = new SelectList(students, "Id", "RegNo");
            if (ModelState.IsValid)
            {
                ArrayList status = _studentManager.SaveResult(studentResult);
                ViewBag.Status = status;
                if ((bool) status[0])
                {
                    ModelState.Clear();
                    return View();
                }
                return View(studentResult);
            }
            return View(studentResult);
        }

        public JsonResult GetStudentEnrolledCourseInfoByStudentId(int studentId)
        {
            var student = _studentManager.GetStudentByStudentId(studentId);
            var courses = _courseManager.GetEnrolledCoursesByStudentId(studentId);
            var studentAndCourses = new
            {
                student = student,
                courses = courses,
                grades = grades
            };
            return Json(studentAndCourses, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ShowResult()
        {
            var students = _studentManager.GetAll() ?? new List<Student>();
            ViewBag.Students = new SelectList(students, "Id", "RegNo");
            return View();
        }

        public JsonResult GetStudentCourseResultByStudentId(int studentId)
        {
            var student = _studentManager.GetStudentByStudentId(studentId);
            var courses = _studentManager.GetStudentResultByStudentId(studentId);
            var studentAndCourses = new
            {
                student = student,
                courses = courses
            };
            return Json(studentAndCourses, JsonRequestBehavior.AllowGet);
        }
    }
}