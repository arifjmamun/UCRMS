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
	@Name VARCHAR(50)
AS
	SET NOCOUNT OFF;
	SELECT COUNT(*) FROM Department WHERE Code = @Name
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
	SELECT COUNT(*) FROM Course WHERE Code = @Name
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