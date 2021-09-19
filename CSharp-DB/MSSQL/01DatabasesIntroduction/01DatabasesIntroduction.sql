/* ******************************************
	Problem 1. Create Database
*********************************************/

CREATE DATABASE Minions

USE Minions

/* ******************************************
	Problem 2. Create Tables
*********************************************/

CREATE TABLE Minions (
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Age INT
)

CREATE TABLE Towns (
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

/* ******************************************
	Problem 3. Alter Minions Table
*********************************************/

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--ALTER TABLE Minions
--ADD TownId INT NOT NULL

--ALTER TABLE Minions
--ADD Constraint FK_TownId FOREIGN KEY(TownId) REFERENCES Towns(Id)

/* ******************************************
	Problem 4. Insert Records in Both Tables
*********************************************/

INSERT INTO Towns(Id, [Name]) 
Values (1, 'Sofia'),
       (2, 'Plovdiv'),
	   (3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId) 
VALUES (1, 'Kevin', 22, 1),
       (2, 'Bob', 15, 3),
       (3, 'Steward', NULL, 2)

				
/* ******************************************
	Problem 5. Truncate Table Minions
*********************************************/

TRUNCATE TABLE Minions

/* ******************************************
	Problem 6. Drop All Tables
*********************************************/

DROP TABLE Minions

DROP TABLE Towns

/* ******************************************
	Problem 7. Create Table People
*********************************************/

CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	CHECK (DATALENGTH(Picture) <= 2 * 1024 * 1024),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
	CHECK (Gender LIKE '[m | f]'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Height, [Weight], Gender, Birthdate)
VALUES ('Petar Petrov', 1.84, 85.3, 'm', '2001-03-20'),
       ('Diana Ivanova', 1.67, 54.0, 'f', '1991-05-01'),
       ('Sotir Dimitrov', 1.75, 77.0, 'm', '1988-12-12'),
       ('Svetlana Todorova', 1.60, 52.0, 'f', '1967-02-15'),
       ('Todor Atanasov', 1.78, 103.3, 'f', '1997-07-08')


/* ******************************************
	Problem 8. Create Table Users
*********************************************/

CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
	CHECK (DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2,
	IsDeleted BIT DEFAULT 'false'
)

INSERT INTO Users (Username, [Password], LastLoginTime, IsDeleted)
VALUES  ('Petar Petrov', 'petar123', '2021-09-17', 0),
        ('Stoyan Ivanov', 'stoyan33', '2021-08-03', 1),
        ('Polina Dimitrowa', 'pdim129', '2020-11-02', 0),
	('Vesela Todorova', 'todorova1', '2021-09-26',0),
	('Krasimira Stoyanova', 'stoyanova2', '2020-09-03', 1)

/* ******************************************
	Problem 9. Change Primary Key
*********************************************/

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC072C3A5AC6

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername PRIMARY KEY (Id, Username)

/* ******************************************
	Problem 10. Add Check Constraint
*********************************************/

ALTER TABLE Users
ADD CONSTRAINT CK_MinPasswordLen CHECK (LEN(Password) >= 5)

/* ******************************************
	Problem 11. Set Default Value of a Field
*********************************************/

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

/* ******************************************
	Problem 12. Set Unique Field
*********************************************/

ALTER TABLE Users
DROP CONSTRAINT PK_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT UQ_Username UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT CK_Username CHECK (LEN(Username) >= 3)

/* ******************************************
	Problem 13. Movies Database
*********************************************/

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Directors (DirectorName)
VALUES ('Steven Spielberg'),
       ('Michael Bay'),
       ('James Cameron'),
       ('Pedro Almodovar'),
       ('Darren Aronofsky')

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Genres (GenreName)
VALUES ('comedy'),
       ('thriller'),
       ('action'),
       ('horror'),
       ('drama')

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Categories (CategoryName)
VALUES ('Children & Family'),
       ('Documentaries'),
       ('Romantic'),
       ('Sci-fi & Fantasy'),
       ('Adventure')

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear SMALLINT,
	[Length] SMALLINT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating REAL NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Movies (Title, DirectorId, [Length], GenreId, CategoryId, Rating)
VALUES ('Black Swan', 5, 108, 2, 4, 8.0),
       ('Terminator 2: Judgment Day', 3, 137, 3, 5, 8.5),
       ('Ready Player One', 1, 140, 3, 4, 7.4),
       ('Bad Boys for Life', 2, 124, 1, 5, 6.6),
       ('Pain and Glory', 4, 113, 5, 3, 7.5)


/* ******************************************
	Problem 14. Car Rental Database
*********************************************/

CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL(10,2) NOT NULL,
	WeeklyRate DECIMAL(10,2) NOT NULL,
	MonthlyRate DECIMAL(10,2) NOT NULL,
	WeekendRate DECIMAL(10,2) NOT NULL
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES ('Economy', 30.00, 210.00, 800.00, 35.00),
       ('Standard', 40.00, 280.00, 1100.00, 45.00),
       ('Luxury', 50.00, 350.00, 1350.00, 55.00)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(20) NOT NULL,
	Model VARCHAR(20) NOT NULL,
	CarYear SMALLINT NOT NULL, 
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors SMALLINT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(20),
	Available BIT DEFAULT 'true'
)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition)
VALUES ('A2568', 'Ford', 'Focus', 2018, 2, 4, 'new'),
       ('B6457', 'Daimler-Benz', 'Smart', 2015, 1, 2, 'good'),
       ('C4892', 'Ford', 'Mustang', 2021, 3, 4, 'new')

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title)
VALUES ('John', 'Smith', 'Mr'),
       ('Marry', 'Williams', 'Ms'),
       ('Anna', 'Brown', 'Ms')

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber VARCHAR(50) NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	City VARCHAR(50) NOT NULL,
	ZIPCode VARCHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode)
VALUES (4760900263, 'Stoyan Ivanov', 'Hristo Botev 58', 'Sofia', 1000),
       (6578922674, 'Ivayla Todorova', 'Tsar Osvoboditel 77', 'Plovdiv', 4000),
       (8809167234, 'Petar Petrov', 'Tsar Simeon Veliki 166', 'Stara Zagora', 6000)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel REAL NOT NULL,
	KilometrageStart INT, 
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied DECIMAL(10,2),
	TaxRate DECIMAL(10,2),
	OrderStatus VARCHAR(50),
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, StartDate, EndDate)
VALUES (1, 2, 1, 50, '2021-05-03', '2021-05-10'),
       (2, 1, 3, 50, '2021-09-09', '2021-09-15'),
       (1, 3, 2, 100, '2021-12-22', '2022-01-02')

/* ******************************************
	Problem 15. Hotel Database
*********************************************/

CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(3) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title)
VALUES ('Peter', 'Jones', 'Mr'),
       ('Anna', 'Smith', 'Ms'),
       ('Emma', 'Peters','Mrs')

CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	EmergencyName VARCHAR(50),
	EmergencyNumber VARCHAR(20),
	Notes VARCHAR(MAX)
)

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber)
VALUES (1, 'Oliver', 'Smith', '89839374'),
       (2, 'William', 'Davies','89023445'),
       (3, 'Sophia', 'Thompson', '23458985')

CREATE TABLE RoomStatus (
	RoomStatus VARCHAR(50) PRIMARY KEY NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus)
VALUES ('available'),
       ('booked'),
       ('reserved')

CREATE TABLE RoomTypes (
	RoomType VARCHAR(50) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes (RoomType)
VALUES ('twin'),
       ('double'),
       ('apartment')

CREATE TABLE BedTypes (
	BedType VARCHAR(50) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

INSERT INTO BedTypes (BedType)
VALUES ('single'),
       ('double'),
       ('king')

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType VARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate DECIMAL(10,2) NOT NULL, 
	RoomStatus VARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus)
VALUES (101, 'double', 'double', 200.00, 'available'),
       (102, 'apartment', 'king', 350.00, 'reserved'),
       (103, 'double', 'double', 200.00, 'booked')

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL, 
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATE NOT NULL, 
	LastDateOccupied DATE NOT NULL, 
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL(10,2) NOT NULL, 
	TaxRate DECIMAL(10,2) NOT NULL,
	TaxAmount DECIMAL(10,2) NOT NULL,
	PaymentTotal DECIMAL(10,2) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxAmount, TaxRate, PaymentTotal)
VALUES (1, '2021-09-20', 1, '2021-09-19', '2021-09-20', 200.00, 0.00, 0.00, 200.00),
       (2, '2021-09-22', 1, '2021-09-20', '2021-09-22', 700.00, 0.00, 0.00, 700.00),
       (1, '2021-09-25', 1, '2021-09-19', '2021-09-25', 1400.00, 0.00, 0.00, 1400.00)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied DECIMAL(10,2) NOT NULL,
	PhoneCharge DECIMAL(10,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied)
VALUES (1, '2022-01-01', 1, 101, 200),
       (3, '2021-11-11', 1, 103, 200),
       (2, '2021-12-05', 1, 101, 350)

/* ******************************************
	Problem 16. Create SoftUni Database
*********************************************/

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL
)

CREATE TABLE Addresses (
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	LastName VARCHAR(50) NOT NULL,
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

/* ******************************************
	Problem 17. Backup Database
*********************************************/

BACKUP DATABASE SoftUni TO DISK = 'D:\softuni-backup.bak'

USE Hotel

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni FROM DISK = 'D:\softuni-backup.bak'

/* ******************************************
	Problem 18. Basic Insert
*********************************************/

INSERT INTO Towns([Name])
VALUES ('Sofia'),
       ('Plovdiv'),
       ('Varna'),
       ('Burgas')

INSERT INTO Departments([Name])
VALUES ('Engineering'),
       ('Sales'),
       ('Marketing'),
       ('Software Development'),
       ('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
       ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
       ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
       ('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
       ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)

/* ******************************************
	Problem 19. Basic Select All Fields
*********************************************/

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

/* ******************************************
	Problem 20. Basic Select All Fields and Order Them
*********************************************/

SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

/* ******************************************
	Problem 21. Basic Select Some Fields
*********************************************/

SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

/* ******************************************
	Problem 22. Increase Employees Salary
*********************************************/

UPDATE Employees
  SET Salary *= 1.10

SELECT Salary FROM Employees

/* ******************************************
	Problem 23. Decrease Tax Rate
*********************************************/

USE Hotel

UPDATE Payments
  SET TaxAmount = TaxAmount - (TaxAmount * 0.03)

SELECT TaxRate FROM Payments


/* ******************************************
	Problem 24.Delete All Records
*********************************************/

DELETE FROM Occupancies
