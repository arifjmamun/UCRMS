﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models.EntityModels;
using UCRMS.Models.ViewModels;

namespace UCRMS.BLL
{
    public class StudentManager
    {
        StudentGateway _studentGateway = new StudentGateway();
        
        public string CountStudent(int departmentId, string currentYear)
        {
            int countStudent = _studentGateway.CountStudent(departmentId, currentYear);
            countStudent++;
            return countStudent.ToString("000");
        }

        public ArrayList Register(Student student)
        {
            if (IsEmailAvailable(student.Email))
            {
                student.RegNo = student.GenerateRegNo();
                int affectedRow = _studentGateway.Register(student);
                if (affectedRow > 0) return new ArrayList {true, "alert-success", "Success!", "Student Registered.", student.RegNo };
                return new ArrayList {false, "alert-danger", "Error!", "Student not registered." };
            }
            return new ArrayList {false, "alert-danger", "Error!", "Student email already exists." };
        }

        private bool IsEmailAvailable(string email)
        {
            int countRow = _studentGateway.IsEmailAvailable(email);
            if (countRow > 0) return false;
            return true;
        }

        public List<Student> GetAll()
        {
            return _studentGateway.GetAll();
        }

        public StudentCourse GetStudentByStudentId(int studentId)
        {
            return _studentGateway.GetStudentByStudentId(studentId);
        }

        public ArrayList EnrollInCourse(StudentCourse studentCourse)
        {
            if (IsCourseEnrollable(studentCourse))
            {
                int affectedRow = _studentGateway.EnrollInCourse(studentCourse);
                if (affectedRow > 0) return new ArrayList {true, "alert-success", "Success!", "The student enrolled in the course." };
                return new ArrayList {false, "alert-danger", "Error!", "The student not enrolled in the course." };
            }
            return new ArrayList {false, "alert-danger", "Error!", "The course already assigned to the student." };
        }

        private bool IsCourseEnrollable(StudentCourse studentCourse)
        {
            int countRow = _studentGateway.IsCourseEnrollable(studentCourse);
            if (countRow > 0) return false;
            return true;
        }

        public ArrayList SaveResult(StudentResult studentResult)
        {
            if (IsStudentResultAssignable(studentResult))
            {
                int affectedRow = _studentGateway.SaveResult(studentResult);
                if (affectedRow > 0) return new ArrayList {true, "alert-success", "Success!", "The student result saved." };
                return new ArrayList {false, "alert-danger", "Error!", "The student result is not saved." };
            }
            return new ArrayList {false, "alert-danger", "Error!", "The student result is already added." };
        }

        private bool IsStudentResultAssignable(StudentResult studentResult)
        {
            int countRow = _studentGateway.IsStudentResultAssignable(studentResult);
            if (countRow > 0) return false;
            return true;
        }

        public List<StudentResult> GetStudentResultByStudentId(int studentId)
        {
            return _studentGateway.GetStudentResultByStudentId(studentId);
        }

        public Student GetStudentInfoByRegNo(string regNo)
        {
            return _studentGateway.GetStudentInfoByRegNo(regNo);
        }
    }
}