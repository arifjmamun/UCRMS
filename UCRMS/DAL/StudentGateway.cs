using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UCRMS.Models.EntityModels;
using UCRMS.Models.ViewModels;

namespace UCRMS.DAL
{
    public class StudentGateway : DBconnection
    {
        public int CountStudentByDepartmentId(int departmentId)
        {
            try
            {
                const string storeProcedure = "CountStudentByDepartmentId";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@DepartmentId", departmentId);
                int countStudent = (int)Command.ExecuteScalar();
                return countStudent;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int IsEmailAvailable(string email)
        {
            try
            {
                const string storeProcedure = "IsStudentEmailAvailable";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Email", email);
                int countRow = (int)Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int Register(Student student)
        {
            try
            {
                const string storedProcedure = "SaveStudent";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storedProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@RegNo", student.RegNo);
                Command.Parameters.AddWithValue("@Name", student.Name);
                Command.Parameters.AddWithValue("@Email", student.Email);
                Command.Parameters.AddWithValue("@ContactNo", student.ContactNo);
                Command.Parameters.AddWithValue("@RegDate", student.RegDate);
                Command.Parameters.AddWithValue("@Address", student.Address);
                Command.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);
                int affectedRow = Command.ExecuteNonQuery();
                return affectedRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Student> GetAll()
        {
            try
            {
                List<Student> students = null;
                const string storeProcedure = "GetAllStudents";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    students = new List<Student>();
                    while (Reader.Read())
                    {
                        var student = new Student
                        {
                            Id = (int)Reader["Id"],
                            RegNo = Reader["RegNo"].ToString()
                        };
                        students.Add(student);
                    }
                    Reader.Close();
                }
                return students;
            }
            finally
            {
                Connection.Close();
            }
        }

        public StudentCourse GetStudentByStudentId(int studentId)
        {
            try
            {
                StudentCourse studentCourse = null;
                const string storeProcedure = "GetStudentByStudentId";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Id", studentId);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    if (Reader.Read())
                    {
                        studentCourse = new StudentCourse
                        {
                            StudentName = Reader["Name"].ToString(),
                            StudentEmail = Reader["Email"].ToString(),
                            StudentDepartment = Reader["Department"].ToString()
                        };
                    }
                    Reader.Close();
                }
                return studentCourse;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int EnrollInCourse(StudentCourse studentCourse)
        {
            try
            {
                const string storedProcedure = "EnrollStudentInCourse";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storedProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@StudentId", studentCourse.StudentId);
                Command.Parameters.AddWithValue("@CourseId", studentCourse.CourseId);
                Command.Parameters.AddWithValue("@EnrollDate", studentCourse.EnrollDate);
                int affectedRow = Command.ExecuteNonQuery();
                return affectedRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int IsCourseEnrollable(StudentCourse studentCourse)
        {
            try
            {
                const string storeProcedure = "IsCourseEnrollableToStudent";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@StudentId", studentCourse.StudentId);
                Command.Parameters.AddWithValue("@CourseId", studentCourse.CourseId);
                int countRow = (int)Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int IsStudentResultAssignable(StudentResult studentResult)
        {
            try
            {
                const string storeProcedure = "IsStudentResultAssignable";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@StudentId", studentResult.StudentId);
                Command.Parameters.AddWithValue("@CourseId", studentResult.CourseId);
                int countRow = (int)Command.ExecuteScalar();
                return countRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int SaveResult(StudentResult studentResult)
        {
            try
            {
                const string storedProcedure = "SaveStudentResult";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storedProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@StudentId", studentResult.StudentId);
                Command.Parameters.AddWithValue("@CourseId", studentResult.CourseId);
                Command.Parameters.AddWithValue("@GradeLetter", studentResult.GradeLetter);
                int affectedRow = Command.ExecuteNonQuery();
                return affectedRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<StudentResult> GetStudentResultByStudentId(int studentId)
        {
            try
            {
                List<StudentResult> studentResults = null;
                const string storeProcedure = "GetStudentResultByStudentId";
                Connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storeProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("", studentId);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    studentResults = new List<StudentResult>();
                    while (Reader.Read())
                    {
                        var studentResult = new StudentResult
                        {
                            CourseCode = Reader["CourseCode"].ToString(),
                            CourseName = Reader["CourseName"].ToString(),
                            GradeLetter = Reader["GradeLetter"].ToString()
                        };
                        studentResults.Add(studentResult);
                    }
                    Reader.Close();
                }
                return studentResults;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}