/* ***********************
	Section 1. DDL 
**************************/

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INT,
	CHECK (Age >=14 AND Age <= 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT,
	CHECK (Age >= 18 and Age <= 110),
	DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT REFERENCES Categories(Id) NOT NULL,
	StatusId INT REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT REFERENCES Users(Id) NOT NULL,
	EmployeeId INT REFERENCES Employees(Id)
)

/* ***********************
	Section 2. DML  
**************************/
--INSERT

INSERT INTO Employees (FirstName, LastName, BirthDate, DepartmentId)
VALUES  ('Marlo', 'O''Malley', '1958-9-21', 1),
		('Niki', 'Stanaghan', '1969-11-26', 4),
		('Ayrton', 'Senna', '1960-03-21', 9),
		('Ronnie', 'Peterson', '1944-02-14', 9),
		('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES  (1, 1,	'2017-04-13', NULL, 'Stuck Road on Str.133', 6,	2),
		(6, 3,	'2015-09-05', '2015-12-06',	'Charity trail running', 3, 5),
		(14, 2,	'2015-09-07', NULL,	'Falling bricks on Str.58', 5, 2),
		(4, 3,	'2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--UPDATE

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--DELETE

DELETE FROM Reports
WHERE [StatusId] = 4

/* ***********************
	Section 3. Querying 
**************************/

--Unassigned Reports

SELECT [Description], 
       FORMAT(OpenDate, 'dd-MM-yyy') AS OpenDate
FROM Reports r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, [Description]

--Reports & Categories

SELECT [Description],
       c.[Name] AS CategoryName
FROM Reports r
     JOIN Categories c ON r.CategoryId = c.Id
ORDER BY [Description], CategoryName

--Most Reported Category

SELECT TOP(5) c.[Name] AS CategoryName,
       COUNT(*) AS ReportsNumber
FROM Reports r
     JOIN Categories c ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, CategoryName


--Birthday Report

SELECT Username, 
       c.[Name] AS CategoryName
FROM Users u
     JOIN Reports r ON u.Id = r.UserId
	 JOIN Categories c ON r.CategoryId = c.Id
WHERE DAY(Birthdate) = DAY(OpenDate)
ORDER BY Username, c.[Name]

--Users per Employee

SELECT FullName,
       SUM([Count]) AS UsersCount
FROM
	(SELECT DISTINCT UserId,
		   FirstName + ' ' + LastName AS FullName,
		   Case
		      WHEN UserId IS NULL THEN 0
			  ELSE 1
		   END AS [COUNT]
	FROM Employees e
		   LEFT JOIN Reports r ON e.Id = r.EmployeeId) AS UniqueId
GROUP BY FullName
ORDER BY UsersCount DESC, FullName


--Full Info

SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
       ISNULL(d.[Name], 'None') AS Department,
	   c.Name AS Category,
	   [Description],
	   Format(r.OpenDate, 'dd.MM.yyy') AS OpenDate,
	   s.[Label] AS [Status],
	   u.[Name] AS [User]
FROM Reports r
     LEFT JOIN Employees e ON r.EmployeeId = e.Id
	 LEFT JOIN Departments d ON e.DepartmentId = d.Id
	 LEFT JOIN Categories c ON r.CategoryId = c.Id
	 LEFT JOIN Users u ON r.UserId = u.Id
	 LEFT JOIN [Status] s ON r.StatusId = s.Id
ORDER BY e.FirstName DESC, 
         e.LastName DESC, 
		 Department, 
		 Category, 
		 [Description], 
		 r.OpenDate, 
		 [Status], 
		 [User]

/* ***********************
	Section 4. Programmability  
**************************/

--Hours to Complete

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
BEGIN

IF (@StartDate IS NULL OR @EndDate IS NULL)
  RETURN 0

DECLARE @totalHours INT = DATEDIFF(HOUR, @StartDate, @EndDate)
RETURN @totalHours

END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

----Assign Employee

CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS

DECLARE @employeesDep INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)
DECLARE @reportDep INT = (SELECT DepartmentId FROM Reports r JOIN Categories c ON r.CategoryId = c.Id WHERE r.Id = @ReportId)

IF	(@employeesDep != @reportDep)
	THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1

UPDATE Reports
SET EmployeeId = @EmployeeId
WHERE Id = @ReportId