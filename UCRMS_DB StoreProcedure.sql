USE UCRMS_DB;
GO

/*Saving Data to Department Table*/
CREATE PROCEDURE SaveDepartment
	@Code VARCHAR(7),
	@Name VARCHAR(50)
AS

	SET NOCOUNT OFF;
	INSERT INTO Department(Code, Name) VALUES(@Code, @Name)
GO

/*Getting All Data From Department Table*/
CREATE PROCEDURE GetAllDepartments
AS
	SET NOCOUNT ON;
	SELECT * FROM Department
GO

/*Check Code exist or not in Department Table*/
CREATE PROCEDURE IsDepartmentCodeAvailable
	@Code VARCHAR(7)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM Department WHERE Code = @Code
GO

/*Check Name exist or not in Department Table*/
CREATE PROCEDURE IsDepartmentNameAvailable
	@Name VARCHAR(60)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM Department WHERE Name = @Name
GO

/*Check DepartmentInfo exist or not in Department Table*/
CREATE PROCEDURE IsDepartmentAvailable
	@Name VARCHAR(60),
	@Code VARCHAR(7)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM Department WHERE Name = @Name OR Code = @Code
GO

/*Getting All Data From Semester Table*/
CREATE PROCEDURE GetAllSemesters
AS
	SET NOCOUNT ON;
	SELECT * FROM Semester
GO

/*Check Code exist or not in Department Table*/
CREATE PROCEDURE IsCourseCodeAvailable
	@Code VARCHAR(15)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM Course WHERE Code = @Code
GO

/*Check Name exist or not in Department Table*/
CREATE PROCEDURE IsCourseNameAvailable
	@Name VARCHAR(100)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM Course WHERE Name = @Name
GO

/*Check CoursetInfo exist or not in Department Table*/
CREATE PROCEDURE IsCourseAvailable
	@Name VARCHAR(100),
	@Code VARCHAR(15)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM Course WHERE Name = @Name OR Code = @Code
GO

/*Saving Data to Course Table*/
CREATE PROCEDURE SaveCourse
	@Code VARCHAR(15),
	@Name VARCHAR(100),
	@Credit DECIMAL(18,2),
	@Description VARCHAR(MAX),
	@DepartmentId INT,
	@SemesterId	INT,
	@Assigned TINYINT
AS
	SET NOCOUNT OFF;
	INSERT INTO Course(Code, Name, Credit, Description, DepartmentId, SemesterId, Assigned) 
	VALUES(@Code, @Name, @Credit, @Description, @DepartmentId, @SemesterId, @Assigned)
GO

/*Getting All Data From Semester Table*/
CREATE PROCEDURE GetAllDesignation
AS
	SET NOCOUNT ON;
	SELECT * FROM Designation
GO

/*Check Email exist or not in Teacher Table*/
CREATE PROCEDURE IsTeacherEmailAvailable
	@Email VARCHAR(100)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM Teacher WHERE Email = @Email
GO

/*Saving Data to Teacher Table*/
CREATE PROCEDURE SaveTeacher
	@Name VARCHAR(50),
	@Address VARCHAR(MAX),
	@Email VARCHAR(100),
	@ContactNo VARCHAR(20),
	@DesignationId INT,
	@DepartmentId INT,
	@CreditToBeTaken DECIMAL(18, 2)
AS
	SET NOCOUNT OFF;
	INSERT INTO Teacher(Name, Address, Email, ContactNo, DesignationId, DepartmentId, CreditToBeTaken) 
	VALUES(@Name, @Address, @Email, @ContactNo, @DesignationId, @DepartmentId, @CreditToBeTaken)
GO

/*Get all Teacher from Teacher Table By DepartmentId*/
CREATE PROCEDURE GetAllTeacherByDepartmentId
	@DepartmentId INT
AS
	SET NOCOUNT OFF;
	SELECT Id, Name FROM Teacher WHERE DepartmentId = @DepartmentId
GO

/*Get all Teacher Taken Course's credit from TeacherCourse and Course Table By TeacherId [Joining]*/
CREATE PROCEDURE GetTotalTakenCreditByTeacherId
	@TeacherId INT
AS
	SET NOCOUNT OFF;
	SELECT ISNULL(SUM(c.Credit),0) FROM Course c
	JOIN TeacherCourse tc ON tc.CourseId = c.Id AND tc.TeacherId = @TeacherId AND tc.Status = 1
GO

/*Get all Teacher Taken Course's credit from Teacher Table By TeacherId*/
CREATE PROCEDURE GetCreditToBeTakenByTeacherId
	@Id INT
AS
	SET NOCOUNT OFF;
	SELECT CreditToBeTaken FROM Teacher WHERE Id = @Id
GO

/*Get all Course from Course Table By DepartmentId*/
CREATE PROCEDURE GetAllCourseByDepartmentId
	@DepartmentId INT
AS
	SET NOCOUNT OFF;
	SELECT Id, Code, Name FROM Course WHERE DepartmentId = @DepartmentId
GO

/*Get Course Info from Course Table By CourseId*/
CREATE PROCEDURE GetCourseInfoByCourseId
	@Id INT
AS
	SET NOCOUNT OFF;
	SELECT Name, Credit FROM Course WHERE Id = @Id
GO

/*Check a Course that already assigned or not from Course Table By CourseId*/
CREATE PROCEDURE IsCourseAssigned
	@Id INT
AS
	SET NOCOUNT OFF;
	SELECT Assigned FROM Course WHERE Id = @Id
GO

/*Saving Data to TeacherCourse Table*/
CREATE PROCEDURE SaveTeacherCourse
	@DepartmentId INT,
	@TeacherId INT,
	@CourseId INT,
	@AssignedDate DATETIME
AS
	SET NOCOUNT OFF;
	INSERT INTO TeacherCourse(DepartmentId, TeacherId, CourseId, AssignedDate, Status) 
	VALUES(@DepartmentId, @TeacherId, @CourseId, @AssignedDate, 1)
	IF @@ROWCOUNT>0
		EXECUTE UpdateCourseAssignedFlagBit @CourseId, @TeacherId
GO

/*Update Course Table's Assigned Flagbit after a course is assigned*/
CREATE PROCEDURE UpdateCourseAssignedFlagBit
	@Id INT,
	@AssignedTo INT
AS
	SET NOCOUNT OFF;
	UPDATE Course SET Assigned = 1, AssignedTo = @AssignedTo WHERE Id = @Id
GO

/*Get CourseStatics from Course and Teacher Table By DepartmentId*/
CREATE PROCEDURE GetCourseStaticsByDepartmentId
	@DepartmentId INT
AS
	SET NOCOUNT OFF;
	SELECT C.Code, C.Name Title, S.Name Semester, ISNULL(T.Name,'Not Assigned Yet') AssignedTo FROM Course C
	JOIN Semester S ON S.Id = C.SemesterId AND C.DepartmentId = @DepartmentId
	LEFT JOIN Teacher T ON T.Id = C.AssignedTo
	ORDER BY C.Code ASC
GO

/*Get Department Code by DepartmentId*/
CREATE PROCEDURE GetDepartmentCodeById
	@Id INT
AS
	SET NOCOUNT OFF;
	SELECT Code FROM Department WHERE Id = @Id
GO

/*Get Department Code by DepartmentId*/
CREATE PROCEDURE CountStudent
	@DepartmentId INT,
	@Year VARCHAR(5)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM Student WHERE DepartmentId = @DepartmentId AND RegDate LIKE '%'+@Year+'%'
GO

/*Save student info to StudentTable*/
CREATE PROCEDURE SaveStudent
	@RegNo VARCHAR(15),
	@Name VARCHAR(50),
	@Email VARCHAR(100),
	@ContactNo VARCHAR(20),
	@RegDate DATETIME,
	@Address VARCHAR(MAX),
	@DepartmentId INT
AS
	SET NOCOUNT OFF;
	INSERT INTO Student(RegNo, Name, Email, ContactNo, RegDate, Address, DepartmentId) 
	VALUES(@RegNo, @Name, @Email, @ContactNo, @RegDate, @Address, @DepartmentId)
GO

/*Check Email exist or not in Teacher Table*/
CREATE PROCEDURE IsStudentEmailAvailable
	@Email VARCHAR(100)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM Student WHERE Email = @Email
GO

/*Getting All Data From Student Table*/
CREATE PROCEDURE GetAllStudents
AS
	SET NOCOUNT ON;
	SELECT * FROM Student
GO

/*Get studentInfo by studentId From Student Table and Department Table [Joining]*/
CREATE PROCEDURE GetStudentByStudentId
	@Id INT
AS
	SET NOCOUNT ON;
	SELECT S.Name, S.Email, D.Name Department FROM Student S
	JOIN Department D ON S.DepartmentId = D.Id AND S.Id= @Id
GO

/*Get studentInfo by studentRegNo From Student Table*/
CREATE PROCEDURE GetStudentInfoByRegNo
	@RegNo VARCHAR(15)
AS
	SET NOCOUNT ON;
	SELECT S.RegNo, S.Name, S.Email, S.ContactNo, S.RegDate, S.Address, D.Name DepartmentName FROM Student S
	JOIN Department D ON S.DepartmentId = D.Id AND S.RegNo = @RegNo
GO

/*Get Allcourse by studentId From Course and Student Table [INNER SELECT]*/
CREATE PROCEDURE GetAllCourseByStudentId
	@Id INT
AS
	SET NOCOUNT ON;
	SELECT C.Id, C.Code, C.Name FROM Course C WHERE C.DepartmentId IN ( SELECT DepartmentId FROM Student WHERE Id = @Id )
GO

/*Check a course that is assignable to a student.*/
CREATE PROCEDURE IsCourseEnrollableToStudent
	@StudentId INT,
	@CourseId INT
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM StudentCourse WHERE CourseId = @CourseId AND StudentId = @StudentId 
GO

/*Enroll a course to a student*/
CREATE PROCEDURE EnrollStudentInCourse
	@StudentId INT,
	@CourseId INT,
	@EnrollDate DATETIME
AS
	SET NOCOUNT OFF;
	INSERT INTO StudentCourse (StudentId, CourseId, EnrollDate) 
	VALUES (@StudentId, @CourseId, @EnrollDate)
GO

/*Get All student enrolled courses by student id [Joining]*/
CREATE PROCEDURE GetEnrolledCoursesByStudentId
	@StudentId INT
AS
	SET NOCOUNT ON;
	SELECT C.Id, C.Code, C.Name FROM StudentCourse SC
	JOIN Course C ON C.Id = SC.CourseId AND SC.StudentId = @StudentId
GO

/*Check a course that is assignable to a student for saving result.*/
CREATE PROCEDURE IsStudentResultAssignable
	@StudentId INT,
	@CourseId INT
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM StudentResult WHERE CourseId = @CourseId AND StudentId = @StudentId 
GO

/*Enroll a course to a student*/
CREATE PROCEDURE SaveStudentResult
	@StudentId INT,
	@CourseId INT,
	@GradeLetter VARCHAR(2)
AS
	SET NOCOUNT OFF;
	INSERT INTO StudentResult(StudentId, CourseId, GradeLetter) 
	VALUES (@StudentId, @CourseId, @GradeLetter)
GO

/*Get student's result by student id [Joining]*/
CREATE PROCEDURE GetStudentResultByStudentId
	@StudentId INT
AS
	SET NOCOUNT ON;
	SELECT C.Code CourseCode, C.Name CourseName, SC.StudentId, ISNULL(SR.GradeLetter,'Not Graded Yet') GradeLetter FROM StudentCourse SC 
	LEFT JOIN StudentResult SR ON SC.CourseId = SR.CourseId AND SC.StudentId = SR.StudentId
	JOIN Course C ON C.Id = SC.CourseId AND SC.StudentId = @StudentId
GO

/*Unassigne all courses from teacher*/
CREATE PROCEDURE UnassignAllCoursesFromTeacher
AS
	SET NOCOUNT OFF;
	UPDATE Course SET Assigned = 0, AssignedTo = NULL
	IF @@ROWCOUNT>0
		UPDATE TeacherCourse SET Status = 0
GO

/*Unassigne all courses from teacher*/
CREATE PROCEDURE GetAllRooms
AS
	SET NOCOUNT ON;
	SELECT * FROM Room
GO

/*Check the class schedule Time is availabele or not*/
CREATE PROCEDURE IsStartTimeAvailableForClassSchedule
	@RoomId INT,
	@DayCode VARCHAR(3),
	@StartFrom TIME(7),
	@EndTo TIME(7)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM AllocatedClassRoom WHERE Status=1 AND RoomId = @RoomId AND DayCode = @DayCode 
	AND (StartFrom BETWEEN @StartFrom AND @EndTo)
GO

CREATE PROCEDURE IsEndTimeAvailableForClassSchedule
	@RoomId INT,
	@DayCode VARCHAR(3),
	@StartFrom TIME(7),
	@EndTo TIME(7)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM AllocatedClassRoom WHERE Status=1 AND RoomId = @RoomId AND DayCode = @DayCode 
	AND (EndTo BETWEEN @StartFrom AND @EndTo)
GO

/*Allocate new class schedule to classroom*/
CREATE PROCEDURE AllocateClassRoom
	@DepartmentId INT,
	@CourseId INT,
	@RoomId INT,
	@DayCode VARCHAR(3),
	@StartFrom TIME(7),
	@EndTo TIME(7)
AS
	SET NOCOUNT OFF;
	INSERT INTO AllocatedClassRoom(DepartmentId, CourseId, RoomId, DayCode, StartFrom, EndTo, Status) 
	VALUES(@DepartmentId, @CourseId, @RoomId, @DayCode, @StartFrom, @EndTo, 1)
GO

/*Allocate new class schedule to classroom*/
CREATE PROCEDURE UnAllocateAllClassRoom
AS
	SET NOCOUNT OFF;
	UPDATE AllocatedClassRoom SET Status = 0 WHERE Status =1
GO

/*Get Class schedule and Room Allocation information by Department Id Joining*/
CREATE PROCEDURE GetClassScheduleAllocationInfo
	@DepartmentId INT
AS
	SET NOCOUNT OFF;
	SELECT DC.Code CourseCode, DC.Name CourseName, ISNULL(R.Name,'') RoomNo, ACR.DayCode, ACR.StartFrom, ACR.EndTo FROM 
		(SELECT * FROM Course C WHERE C.DepartmentId = @DepartmentId) DC
		LEFT JOIN AllocatedClassRoom ACR ON ACR.CourseId = DC.Id AND ACR.Status != 0
		LEFT JOIN Room R ON R.Id = ACR.RoomId ORDER BY CourseCode
GO