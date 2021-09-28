/* *************************************************
Problem 1. Find Names of All Employees by First Name
****************************************************/

USE SoftUni

SELECT FirstName, LastName 
  FROM Employees
 WHERE FirstName LIKE 'Sa%'

/* *************************************************
Problem 2. Find Names of All Employees by Last Name
****************************************************/

Select FirstName, LastName 
  FROM Employees
 WHERE LastName LIKE '%ei%'

/* *************************************************
Problem 3. Find First Names of All Employees
****************************************************/

SELECT FirstName FROM Employees
 WHERE DepartmentID IN(3,10) 
	   AND DATEPART(YEAR,HireDate) BETWEEN 1995 AND 2005

/* *************************************************
Problem 4. Find All Employees Except Engineers
****************************************************/

SELECT FirstName, LastName 
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'

/* *************************************************
Problem 5. Find Towns with Name Length
****************************************************/

SELECT [Name] FROM Towns
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

/* *************************************************
Problem 6. Find Towns Starting With
****************************************************/

SELECT * FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

/* *************************************************
Problem 7. Find Towns Not Starting With
****************************************************/

SELECT * FROM Towns
WHERE LEFT([Name], 1) NOT LIKE '[RBD]'
ORDER BY [Name]

/* *************************************************
Problem 8. Create View Employees Hired After 2000 Year
****************************************************/

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
  FROM Employees
 WHERE DATEPART(YEAR, HireDate) > 2000

/* *************************************************
Problem 9. Length of Last Name
****************************************************/

SELECT FirstName, LastName
  FROM Employees
 Where LEN(LastName) = 5

 /* *************************************************
Problem 10. Rank Employees by Salary
****************************************************/

SELECT EmployeeID, FirstName, LastName, Salary, 
       DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [RANK]
  FROM Employees
  WHERE Salary BETWEEN 10000 AND 50000
  ORDER BY SALARY DESC

/* *************************************************
Problem 11. Find All Employees with Rank 2 
****************************************************/

SELECT  * 
    FROM
       (SELECT EmployeeID, FirstName, LastName, Salary, 
        DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	    FROM Employees
	    WHERE Salary BETWEEN 10000 AND 50000) AS Table_1
	WHERE Table_1.Rank = 2
    ORDER BY Salary DESC
   
/* *************************************************
Problem 12. Countries Holding ‘A’ 3 or More Times 
****************************************************/

USE Geography

SELECT CountryName, IsoCode FROM Countries
WHERE (LEN(CountryName) - LEN(REPLACE(CountryName,'A',''))) >= 3
ORDER BY IsoCode

/* *************************************************
Problem 13. Mix of Peak and River Names 
****************************************************/

SELECT PeakName, RiverName, LOWER(SUBSTRING(PeakName, 1, LEN(PeakName)- 1) + RiverName) AS Mix
  FROM Peaks, Rivers
  WHERE Right(PeakName, 1) = LEFT(RiverName, 1)
  ORDER BY Mix

/* *************************************************
Problem 14. Games from 2011 and 2012 year 
****************************************************/

USE Diablo

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
          FROM Games
         WHERE YEAR([Start]) IN(2011, 2012)
      ORDER BY [Start], [Name]

/* *************************************************
Problem 15. User Email Providers 
****************************************************/

SELECT Username,
       RIGHT(Email, LEN(Email) - CHARINDEX('@', Email, 1)) AS [Email Provider]
  FROM Users
 ORDER BY [Email Provider], Username

/* *************************************************
Problem 16. Get Users with IPAdress Like Pattern 
****************************************************/

SELECT Username, IpAddress 
    FROM Users
   WHERE IPAddress LIKE '___.1_%._%.___'
ORDER BY Username

/* *************************************************
Problem 17. Show All Games with Duration and Part of the Day 
****************************************************/

SELECT [Name] AS Game,
	    CASE
			WHEN  DATEPART(Hour, [Start]) >= 0 AND  DATEPART(Hour, [Start]) < 12 THEN 'Morning'
			WHEN  DATEPART(Hour, [Start]) >= 12 AND  DATEPART(Hour, [Start]) < 18 THEN 'Afternoon'
			ELSE 'Evening'
		END AS [Part of the Day],
		CASE 
			WHEN Duration <= 3 THEN 'Extra Short'
			WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
			WHEN Duration > 6 THEN 'Long'
			ELSE 'Extra Long'
		END AS Duration 
FROM Games as g
ORDER BY Game, Duration, [Part of the Day]

/* *************************************************
Problem 18. Orders Table 
****************************************************/

USE Orders

SELECT ProductName, OrderDate,
       DATEADD(day, 3, OrderDate) AS 'Pay Due',
	   DATEADD(month, 1, OrderDate) AS 'Deliver Due'
       FROM Orders

/* *************************************************
Problem 19. People Table 
****************************************************/

CREATE TABLE People (
   Id INT PRIMARY KEY IDENTITY,
   [Name] NVARCHAR(50) NOT NULL,
   Birthdate DATETIME2 NOT NULL
)

INSERT INTO People
VALUES ('Viktor', '2000-12-07'),
       ('Steven', '1992-09-10'),
	   ('Stephen', '1910-09-19'),
	   ('John', '2010-01-06')

SELECT [Name],
        DATEDIFF(YEAR, Birthdate, GETDATE()) AS 'Age in Years',
		DATEDIFF(Month, Birthdate, GETDATE()) AS 'Age in Months',
		DATEDIFF(Day, Birthdate, GETDATE()) AS 'Age in Days',
		DATEDIFF(MINUTE, Birthdate, GETDATE()) AS 'Age in Minutes'
FROM People