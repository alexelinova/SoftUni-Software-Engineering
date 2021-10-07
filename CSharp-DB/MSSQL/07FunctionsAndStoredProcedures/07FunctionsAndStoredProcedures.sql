/* *************************************************
1. Employees with Salary Above 35000
****************************************************/

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
   SELECT FirstName AS [First Name],
          LastName AS [Last Name]
     FROM Employees
    WHERE Salary > 35000

/* *************************************************
2. Employees with Salary Above Number
****************************************************/

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@MinSalary MONEY)
AS
   SELECT FirstName AS [FirstName],
          LastName AS [LastName]
     FROM Employees
	WHERE Salary  >= @MinSalary

/* *************************************************
3. Town Names Starting With
****************************************************/

CREATE PROC usp_GetTownsStartingWith (@SubName VARCHAR(50))
AS
	SELECT [Name] AS Town
	  FROM Towns
	WHERE [Name] Like @SubName + '%'

/* *************************************************
4. Employees from Town
****************************************************/

CREATE PROC usp_GetEmployeesFromTown (@TownName VARCHAR(50))
AS
	SELECT FirstName AS [First Name], 
		   LastName AS [Last Name]
	FROM Employees e
		 JOIN Addresses a ON e.AddressID = a.AddressID
		 JOIN Towns t ON a.TownID = t.TownID
	WHERE t.Name = @TownName

/* *************************************************
5. Salary Level Function
****************************************************/

CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(10)
	IF (@Salary < 30000)
		SET @result = 'Low'
	ELSE IF (@Salary <= 50000)
	    SET @result = 'Average'
	ELSE 
	    SET @result = 'High'

	RETURN @result
END

/* *************************************************
6. Employees by Salary Level
****************************************************/

CREATE PROC usp_EmployeesBySalaryLevel (@LevelOfSalary VARCHAR(50))
AS
  SELECT FirstName AS [First Name],
         LastName AS [Last Name]
  FROM Employees
 WHERE dbo.ufn_GetSalaryLevel(Salary) = @LevelOfSalary

/* *************************************************
7. Define Function
****************************************************/

CREATE FUNCTION ufn_IsWordComprised (@SetOfLetters VARCHAR(50), @Word VARCHAR(50))
RETURNS BIT
AS
BEGIN
    DECLARE @currentIndex INT = 1;
	WHILE (@currentIndex <= LEN(@Word))
	BEGIN
	   DECLARE @currentLetter CHAR = SUBSTRING(@Word,@currentIndex, 1);
	   IF (CHARINDEX(@currentLetter,@SetOfLetters) = 0)
	   BEGIN
	        RETURN 0;
	   END;
	   SET @currentIndex += 1
    END;
RETURN 1
END;

/* *************************************************
8. Delete Employees and Departments
****************************************************/

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
  ALTER TABLE Departments
  ALTER COLUMN ManagerID INT NULL

  DELETE FROM EmployeesProjects
  WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId)

  UPDATE Employees
  SET ManagerID = NULL
  WHERE EmployeeID IN(SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId)

  UPDATE Employees
  SET ManagerID = NULL
  WHERE ManagerID IN(SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId)

  UPDATE Departments
  SET ManagerID = NULL
  WHERE DepartmentID = @DepartmentId

  DELETE FROM Employees
  WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId)

  DELETE FROM Departments
  WHERE DepartmentID = @DepartmentId

  SELECT * FROM Employees
  WHERE DepartmentID = @DepartmentId

  SELECT Count(*)
  FROM Employees
  WHERE DepartmentID = @DepartmentID

 /* *************************************************
9. Find Full Name
****************************************************/

CREATE PROCEDURE usp_GetHoldersFullName
AS
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders

/* *************************************************
10. People with Balance Higher Than
****************************************************/

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@MinBalance DECIMAL(15,2))
AS
SELECT FirstName, 
       LastName 
FROM AccountHolders ah
	   JOIN Accounts a ON ah.Id = a.AccountHolderId 
GROUP BY FirstName, LastName
HAVING SUM(Balance) > @MinBalance
ORDER BY FirstName, LastName

/* *************************************************
11. Future Value Function
****************************************************/

CREATE FUNCTION ufn_CalculateFutureValue (@Amount DECIMAL(15,4), @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS DECIMAL(15, 4)
AS
BEGIN
DECLARE @result DECIMAL(15, 4)
		SET @result = @Amount *(POWER (1 + @YearlyInterestRate, @NumberOfYears))
RETURN @result
END
       
/* *************************************************
12. Calculating Interest
****************************************************/

CREATE PROCEDURE usp_CalculateFutureValueForAccount (@AccountID INT, @InterestRate FLOAT)
AS
SELECT a.Id,
       ah.FirstName,
	   ah.LastName,
	   a.Balance,
	   dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5)
From AccountHolders ah
JOIN Accounts a ON a.AccountHolderId = ah.Id
WHERE a.Id = @AccountID

/* *************************************************
13. Scalar Function: Cash in User Games Odd Rows
****************************************************/

USE Diablo

CREATE FUNCTION ufn_CashInUsersGames (@GamesName VARCHAR(50))
RETURNS TABLE
AS 
RETURN SELECT(
	SELECT SUM(Cash) AS SumCash
	FROM(
	     SELECT g.Name,
		        ug.Cash,
		        ROW_NUMBER() OVER (Partition BY g.Name ORDER BY Cash DESC) AS RowNumber
		 FROM Games g
		        JOIN UsersGames ug ON g.ID = ug.GameId
		 WHERE g.Name = @GamesName
		) AS RowNumbers
		WHERE RowNumber % 2 != 0
	         ) AS SumCash


