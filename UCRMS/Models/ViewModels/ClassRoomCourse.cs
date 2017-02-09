using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS.Models.ViewModels
{
    public class ClassRoomCourse
    {
        [Required(ErrorMessage = "Select a Department.")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Select a course.")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Select a room.")]
        [Display(Name = "Room No.")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Select a day.")]
        [Display(Name = "Day")]
        public string DayCode { get; set; }

        [Required(ErrorMessage = "You must enter start time.")]
        [Display(Name = "From")]
        //[RegularExpression("\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))", ErrorMessage = "You must follow the format.")]
        public string StartFrom { get; set; }

        [Required(ErrorMessage = "You must enter end time.")]
        [Display(Name = "To")]
        //[RegularExpression("\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))", ErrorMessage = "You must follow the format.")]
        public string EndTo { get; set; }

        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }
        
        [Display(Name = "Name")]
        public string CourseName { get; set; }
        
        [Display(Name = "Schedule Info")]
        public string ScheduleInfo { get; set; }
    }
}