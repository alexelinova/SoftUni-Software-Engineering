/* ******************************************
	Problem 1.	One-To-One Relationship
*********************************************/

CREATE TABLE Passports (
	PassportID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	PassportNumber NVARCHAR(10) NOT NULL
)

CREATE TABLE Persons (
	PersonID INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	PassportID INT UNIQUE REFERENCES Passports(PassportID) NOT NULL
)

INSERT INTO Persons (FirstName, Salary, PassportID)
VALUES	('Roberto', 43300.00, 102),
		('Tom', 56100.00, 103),
		('Yana', 60200.00, 101)

INSERT INTO Passports (PassportNumber)
VALUES	('N34FG21B'),
		('K65LO4R7'),
		('ZE657QP2')

/* ******************************************
	Problem 2.	One-To-Many Relationship
*********************************************/

CREATE TABLE Manufacturers (
	ManufacturerID INT PRIMARY KEY IDENTITY NOT NULL, 
	[Name] VARCHAR(50) NOT NULL,
	EstablishedOn DATE
)

INSERT INTO Manufacturers ([Name], EstablishedOn)
VALUES	('BMW', '1916-03-07'),
		('Tesla', '2003-01-01'),
		('Lada', '1966-05-01')

CREATE TABLE Models (
	ModelID INT PRIMARY KEY IDENTITY (101,1) NOT NULL, 
	[Name] VARCHAR(50) NOT NULL,
	ManufacturerID INT REFERENCES Manufacturers(ManufacturerID) NOT NULL
)

INSERT INTO Models ([Name], ManufacturerID)
VALUES	('X1', 1),
		('i6', 1),
		('Model S', 2),
		('Model X', 2),
		('Model 3', 2),
		('Nova', 3)

/* ******************************************
	Problem 3.	Many-To-Many Relationship
*********************************************/

CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

INSERT INTO Students ([Name])
VALUES	('Mila'),
		('Toni'),
		('Ron')

CREATE TABLE Exams (
	ExamID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[Name] NVARCHAR(50)
)

INSERT INTO Exams([Name])
VALUES	('SpringMVC'),
		('Neo4j'),
		('Oracle 11g')

CREATE TABLE StudentsExams (
	StudentID INT REFERENCES Students(StudentID) NOT NULL,
	ExamID INT REFERENCES Exams(ExamId) NOT NULL,
	CONSTRAINT PK_StudentID_ExamID PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO StudentsExams
VALUES	(1, 101),
		(1, 102),
		(2, 101),
		(3, 103),
		(2, 102),
		(2, 103)

/* ******************************************
	Problem 4.	Self-Referencing
*********************************************/

CREATE TABLE Teachers (
	TeacherID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL, 
	ManagerID INT REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers ([Name], ManagerID)
VALUES	('John', NULL),
		('Maya', 106),
		('Silvia', 106),
		('Ted', 105),
		('Mark', 101),
		('Greta', 101)


/* ******************************************
	Problem 5.	Online Store Database
*********************************************/

CREATE DATABASE OnlineStore

USE OnlineStore

CREATE TABLE Cities (
	CityID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers (
	CustomerID INT PRIMARY KEY IDENTITY NOT NULL, 
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE ItemTypes (
	ItemTypeID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items (
	ItemID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Orders (
	OrderID INT PRIMARY KEY IDENTITY NOT NULL,
	CustomerID INT REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE OrderItems (
	OrderID INT REFERENCES Orders(OrderID) NOT NULL,
	ItemID INT REFERENCES Items(ItemID) NOT NULL,
	CONSTRAINT PK_OrderID_ItemID PRIMARY KEY (OrderID, ItemID)
)


/* ******************************************
	Problem 6.	University Database
*********************************************/

CREATE DATABASE University
GO

USE University

CREATE TABLE Majors (
	MajorID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students (
	StudentID INT PRIMARY KEY NOT NULL, 
	StudentNumber INT UNIQUE,
	StudentName VARCHAR(50),
	MajorID INT REFERENCES Majors(MajorID)
)

CREATE TABLE Payments (
	PaymentID INT PRIMARY KEY NOT NULL,
	PaymentDate DATETIME2 NOT NULL,
	PaymentAmount DECIMAL(10,2) NOT NULL,
	StudentID INT REFERENCES Students(StudentID)
)

CREATE TABLE Subjects (
	SubjectID INT PRIMARY KEY NOT NULL,
	SubjectName VARCHAR(100) NOT NULL
)

CREATE TABLE Agenda (
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID),
	CONSTRAINT PK_StudentID_SubjectID PRIMARY KEY (StudentID, SubjectID)
)

/* ******************************************
	Problem 9.	Peaks in Rila
*********************************************/

USE [Geography]

SELECT m.MountainRange, p.PeakName, p.Elevation 
FROM Peaks AS p
	JOIN Mountains AS m ON p.MountainId = m.Id
	WHERE m.MountainRange = 'Rila'
	ORDER BY p.Elevation DESC