/* ********************************
	Section 1. DDL
***********************************/

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT,
	CHECK (Age >= 5 AND Age <= 100),
	[Address] NVARCHAR(50),
	Phone NCHAR(10)
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL,
	CHECK (Lessons > 0)
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT REFERENCES Students(Id) NOT NULL,
	SubjectId INT REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(3,2) NOT NULL,
	CHECK (Grade >= 2 and Grade <= 6)
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	Date DATETIME2,
	SubjectId INT REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentId INT REFERENCES Students(Id) NOT NULL,
	ExamId INT REFERENCES Exams(Id) NOT NULL,
	PRIMARY KEY(StudentId, ExamId),
	Grade DECIMAL(3,2) NOT NULL,
	CHECK (Grade >= 2 AND Grade <= 6)
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers
(
	StudentId INT REFERENCES Students(Id),
	TeacherId INT REFERENCES Teachers(Id),
	PRIMARY KEY(StudentId, TeacherId)
)

/* ********************************
	Section 2. DML
***********************************/

--INSERT

INSERT INTO Teachers (FirstName, LastName, Address, Phone, SubjectId)
VALUES ('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
       ('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
       ('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
       ('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects ([Name], Lessons)
VALUES ('Geometry', 12),
       ('Health', 10),
       ('Drama', 7),
       ('Sports', 9)

--UPDATE

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN(1,2) AND Grade >= 5.50

--DELETE

DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

/* ********************************
	Section 3. Querying 
***********************************/

--Teen Students

SELECT FirstName, 
       LastName, 
	   Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName, Age

--Students Teachers

SELECT FirstName, 
       LastName,
	   Count(TeacherId) AS TeachersCount
FROM Students s
     JOIN StudentsTeachers st ON s.Id = st.StudentId
GROUP BY  s.FirstName, s.LastName

--Students to Go

SELECT FirstName + ' ' + LastName AS [Full Name] 
FROM Students s
     LEFT JOIN StudentsExams ste ON s.Id = ste.StudentId
WHERE s.Id NOT IN (SELECT StudentId FROM StudentsExams)
ORDER BY [Full Name]

--Top Students

SELECT TOP(10) FirstName, 
          LastName, 
	      CONVERT(DECIMAL(3,2),AVG(Grade)) AS Grade
FROM Students s
     JOIN StudentsExams ste ON s.Id = ste.StudentId
GROUP BY FirstName, LastName
ORDER BY Grade DESC, FirstName, LastName

--Not So In The Studying

SELECT CONCAT(FirstName, ISNULL(' ' + MiddleName, ''), ' ' + LastName) AS [Full Name]
FROM Students s
WHERE s.Id NOT IN (SELECT StudentId FROM StudentsSubjects)
ORDER BY [Full Name]

--Average Grade per Student

SELECT [Name],
       AVG(Grade) AS AverageGrade
FROM 
     StudentsSubjects ss 
     JOIN Subjects sub on sub.Id = ss.SubjectId
GROUP BY sub.Id, [Name]
ORDER BY sub.Id

/* ********************************
	Section 4. Programmability 
***********************************/
--Exam Grades

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS VARCHAR(MAX)
BEGIN

DECLARE @result VARCHAR(MAX)
DECLARE @studentIdInDatabase INT = (SELECT Id FROM Students WHERE Id = @studentId)

IF (@studentIdInDatabase IS NULL)
BEGIN
	SET @result = 'The student with provided id does not exist in the school!'
	RETURN @result
END

IF (@grade > 6)
BEGIN 
    SET @result = 'Grade cannot be above 6.00!'
	RETURN @result
END

DECLARE @countofGrades INT = (SELECT Count(*)
                              FROM StudentsSubjects ss
                                   JOIN Subjects sub ON ss.SubjectId = sub.Id
                              WHERE ss.StudentId = @studentId AND (Grade > @grade  AND Grade <= @grade + 0.5))
DECLARE @studentFirstName VARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)

SET @result = 'You have to update ' + CONVERT(VARCHAR, @countofGrades) + ' grades for the student ' + @studentFirstName

RETURN @result
END

--Exclude From School

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS

DECLARE @studentIdInDatabase INT = (SELECT Id FROM Students WHERE Id = @studentId)

IF (@studentIdInDatabase IS NULL)
	THROW 50001, 'This school has no student with the provided id!', 1

DELETE FROM StudentsSubjects
WHERE StudentId = @StudentId

DELETE FROM StudentsExams
WHERE StudentId = @studentId

DELETE FROM StudentsTeachers
WHERE StudentId = @studentId

DELETE FROM Students
WHERE Id = @StudentId

