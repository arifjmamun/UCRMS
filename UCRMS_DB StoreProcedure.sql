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