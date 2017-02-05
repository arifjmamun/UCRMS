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
	JOIN TeacherCourse tc ON tc.CourseId = c.Id AND tc.TeacherId = @TeacherId
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
	SELECT Id, Code FROM Course WHERE DepartmentId = @DepartmentId
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
	INSERT INTO TeacherCourse(DepartmentId, TeacherId, CourseId, AssignedDate) 
	VALUES(@DepartmentId, @TeacherId, @CourseId, @AssignedDate)
GO