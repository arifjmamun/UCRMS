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
    public class RoomController : Controller
    {
        ClassRoomManager _classRoomManager = new ClassRoomManager();
        DepartmentManager _departmentManager = new DepartmentManager();
        CourseManager _courseManager = new CourseManager();

        private readonly List<Day> _days = new List<Day>
        {
            new Day{Id = 1,Code = "Sat",Name = "Saturday"},
            new Day{Id = 2,Code = "Sun",Name = "Sunday"},
            new Day{Id = 3,Code = "Mon",Name = "Monday"},
            new Day{Id = 4,Code = "Tue",Name = "Tuesday"},
            new Day{Id = 5,Code = "Wed",Name = "Wednesday"},
            new Day{Id = 6,Code = "Thu",Name = "Thursday"},
            new Day{Id = 7,Code = "Fri",Name = "Friday"},
        };

        // GET: Room
        [HttpGet]
        public ActionResult AllocateClass()
        {
            var rooms = _classRoomManager.GetAllRooms() ?? new List<Room>();
            var departments = _departmentManager.GetAll() ?? new List<Department>();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            ViewBag.Rooms = new SelectList(rooms, "Id", "Name");
            ViewBag.Days = new SelectList(_days,"Id","Name");
            return View();
        }

        [HttpPost]
        public ActionResult AllocateClass(ClassRoomCourse classRoomCourse)
        {
            var rooms = _classRoomManager.GetAllRooms() ?? new List<Room>();
            var departments = _departmentManager.GetAll() ?? new List<Department>();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            ViewBag.Rooms = new SelectList(rooms, "Id", "Name");
            ViewBag.Days = new SelectList(_days, "Id", "Name");

            if (ModelState.IsValid)
            {
                ViewBag.Status = _classRoomManager.AllocateClass(classRoomCourse);
                ModelState.Clear();
                return View();
            }
            return View(classRoomCourse);
        }

        public JsonResult GetAllCourseByDepartmentId(int departmentId)
        {
            var courses = _courseManager.GetAllCourseByDepartmentId(departmentId);
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
    }
}