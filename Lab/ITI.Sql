Use master
Go


Create Database ITIAdoLab
use ITIAdoLab

CREATE TABLE [dbo].[Students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fName] [nvarchar](20) NOT NULL,
	[lName] [nvarchar](20) NOT NULL,
	[age] [int] NOT NULL,
	[address] [nvarchar](50) NULL,
	[deptId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
Create Table Department (
	id int primary key identity(1,1),
	name nVarchar(20) not null,
	insId int not null,
	hiringDate date NULL
);
GO

Alter Table Students
add Foreign Key ([deptId]) References Department(id);

GO

Create Table Instructors (
	id int primary key identity(1,1),
	fullName nVarchar(20) not null,
	bouns int Null,
	salary decimal(5,2) Not Null,
	address nVarChar(50) Null,
	hourRate int Not Null,
	deptId int References Department(id)
);

GO


---Inser Tester Department--> when i create it with UI that Query Will Exqute
sp_executesql N'SELECT TOP (200) id, name, insId, hiringDate
FROM Department
WHERE (name = @Param1) AND (insId = @Param2) AND (hiringDate IS NULL)',
N'@Param1 nvarchar(4),@Param2 int',@Param1=N'JAVA',@Param2=1
--
GO


GO

Alter Table Department
Add Foreign Key(instId) References Instructors(id);

GO
ALTER TABLE Instructors
ALTER COLUMN salary DECIMAL(7, 2);
GO

BEGIN TRANSACTION;

-- Step 1: Insert department
INSERT INTO Departments(name,insId)
VALUES ('Software Engineering',1);

-- Step 2: Get the new department ID
DECLARE @DeptId INT = SCOPE_IDENTITY();

-- Step 3: Insert instructor with valid deptId
INSERT INTO Instructors (fullName, bouns, salary, address, hourRate, deptId)
VALUES ('Mena Youssef', 500, 4500.00, 'Cairo', 100, @DeptId);

commit;


GO

Create Or Alter Procedure Sp_UpdateDepartmenById
(@Id int, @NewName nVarChar(20), @NewInstId int,@NewHiringDate Date = NULL)
As
Begin
	If @NewHiringDate is Null 
		SET @NewHiringDate = Cast(GetDate() As Date);

	Update Departments 
	SET name = @NewName,insId = @NewInstId,hiringDate = @NewHiringDate
	Where id = @Id;
End

GO
Execute Sp_UpdateDepartmenById 14,'Markting',4

Go 


Create Or Alter Procedure Sp_DeleteDepartmentById @id int
As
	Delete From Departments
	where id = @id;

Execute Sp_DeleteDepartmentById 15




Select *
from Students;

GO

Create Or Alter Procedure Sp_InsertStudent 
(@fName nVarChar(20), @lName nVarChar(20),@age int, @DeptId int,@address nvarchar(50) = NULL)
As
Begin
	Insert into Students
	Values (@fName,@lName,@age,@address,@DeptId);

	select SCOPE_IDENTITY();
End
GO

Execute Sp_InsertStudent 'kareem','Mohammad',20,1;

GO

Create Or Alter Procedure Sp_UpdateStudentById 
( @Id int, @NewFName nVarChar(20),@NewLName nVarChar(20), @NewAge int,@NewDeptId int ,@NewAddress nvarchar(50))
As
	Update Students
	Set fName = @NewFName, lName = @NewLName,
	age =@NewAge, deptId = @NewDeptId,
	address = @NewAddress
	where id = @Id;

GO

Exec Sp_UpdateStudentById 17,'Jhon','Hany',19,2,'Alex';

--select * from Departments
--select * from Students

