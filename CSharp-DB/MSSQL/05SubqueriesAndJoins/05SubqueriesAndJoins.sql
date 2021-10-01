/* *************************************************
Problem 1. Employee Address
****************************************************/

SELECT TOP (5) e.EmployeeID, 
               e.JobTitle, 
			   e.AddressID, 
			   a.AddressText
FROM Employees e
     LEFT JOIN Addresses a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

/* *************************************************
Problem 2. Addresses with Towns
****************************************************/

SELECT TOP (50) e.FirstName,
                e.LastName,
	            t.Name AS Town,
	            a.AddressText
FROM Employees e
     LEFT JOIN Addresses a ON e.AddressID = a.AddressID
	 LEFT JOIN Towns t ON a.TownID = t.TownID
ORDER BY FirstName, LastName


/* *************************************************
Problem 3. Sales Employees
****************************************************/

SELECT e.EmployeeID,
       e.FirstName,
	   e.LastName,
	   d.Name AS DepartmentName
FROM Employees e
     JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID

/* *************************************************
Problem 4. Employee Departments
****************************************************/

SELECT TOP (5) e.EmployeeID,
               e.FirstName,
			   e.Salary,
			   d.Name AS DepartmentName
FROM Employees e
    LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID

/* *************************************************
Problem 5. Employees Without Project
****************************************************/

SELECT TOP (3) e.EmployeeID,
               e.FirstName
FROM Employees e
     LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

/* *************************************************
Problem 6. Employees Hired After
****************************************************/

SELECT e.FirstName,   
       e.LastName,
	   e.HireDate,
	   d.Name AS DeptName
FROM Employees e
  JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND d.Name IN ('Sales', 'Finance')
ORDER BY HireDate 

/* *************************************************
Problem 7. Employees Hired After
****************************************************/

SELECT TOP (5) e.EmployeeID,
               e.FirstName,
			   p.Name as ProjectName
FROM Employees e
     JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
     JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

/* *************************************************
Problem 8. Employee 24
****************************************************/

SELECT e.EmployeeID,
       e.FirstName,
	   CASE
           WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		   ELSE p.Name
	   END AS ProjectName
FROM Employees e
     JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
	 JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

/* *************************************************
Problem 9. Employee Manager
****************************************************/

SELECT e.EmployeeID,
       e.FirstName,
	   e.ManagerID,
	   m.FirstName AS ManagerName
FROM Employees e
     JOIN Employees m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID

/* *************************************************
Problem 10. Employee Summary
****************************************************/

SELECT TOP (50) e.EmployeeID,
                Concat(e.FirstName, ' ', e.LastName) AS EmployeeName,
				Concat(m.FirstName, ' ', m.LastName) AS ManagerName,
				d.Name AS DepartmentName
FROM Employees e
     LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
	 LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

/* *************************************************
Problem 11. Employee Summary
****************************************************/

SELECT TOP (1)
       AVG(Salary) AS MinAverageSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY AVG(Salary)

/* *************************************************
Problem 12. Highest Peaks in Bulgaria
****************************************************/

SELECT mc.CountryCode,
       m.MountainRange,
	   p.PeakName,
	   p.Elevation
FROM Peaks p
     JOIN Mountains m ON p.MountainId = m.Id
	 JOIN MountainsCountries mc ON p.MountainId = mc.MountainId
	 JOIN Countries c ON mc.CountryCode = c.CountryCode
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

/* *************************************************
Problem 13. Count Mountain Ranges
****************************************************/

SELECT c.CountryCode,
       Count(*) AS MountainRanges
FROM Countries c
     JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	 JOIN Mountains m ON mc.MountainId = m.Id
WHERE CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode

/* *************************************************
Problem 14. Countries with Rivers
****************************************************/

SELECT TOP (5) c.CountryName,
               r.RiverName
FROM Countries c
     LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	 LEFT JOIN Rivers r ON cr.RiverId = r.Id
WHERE ContinentCode = 'AF'
ORDER BY c.CountryName

/* *************************************************
Problem 15. Continents and Currencies
****************************************************/
SELECT rk.ContinentCode, 
       rk.CurrencyCode,
	   rk.CurrencyUsage
FROM
 (SELECT ccu.ContinentCode,
         ccu.CurrencyCode,
		 ccu.CurrencyUsage,
         Dense_Rank() OVER (Partition BY ccu.ContinentCode ORDER BY ccu.CurrencyUsage DESC) AS CurrencyRank
  FROM 
      (SELECT ContinentCode,
              CurrencyCode,
	          Count(CurrencyCode) AS CurrencyUsage
       FROM Countries
       GROUP BY ContinentCode, CurrencyCode
       HAVING Count(CurrencyCode) > 1
	   ) AS ccu
	 ) AS rk
WHERE CurrencyRank = 1
ORDER BY rk.ContinentCode

/* *************************************************
Problem 16. Countries Without Any Mountains
****************************************************/

SELECT Count(*) AS [Count]
FROM Countries c
     LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
GROUP BY mc.MountainId
HAVING MountainID IS NULL

/* *************************************************
Problem 17. Highest Peak and Longest River by Country
****************************************************/

SELECT TOP (5) CountryName,
               MAX(Elevation) AS HighestPeakElevation,
	           MAX([Length]) AS LongestRiverLength
FROM Countries c
     LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
     LEFT JOIN Mountains m ON m.ID = mc.MountainId
     LEFT JOIN Peaks p ON p.MountainId = m.Id
     LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
     LEFT JOIN Rivers r ON cr.RiverId = r.Id
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

/* *************************************************
Problem 18. Highest Peak and Longest River by Country
****************************************************/

SELECT TOP (5) CountryName AS Country,
       ISNULL(PeakName, ('(no highest peak)')) AS [Highest Peak Name],
	   ISNULL(Elevation, 0) AS [Highest Peak Elevation],
	   ISNULL(MountainRange, '(no mountain)') AS Mountain
FROM
    (SELECT c.CountryName,
            p.PeakName ,
	        p.Elevation,
	        m.MountainRange,
            DENSE_RANK () OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS RankedELevation
     FROM Countries c
          LEFT JOIN  MountainsCountries mc ON c.CountryCode = mc.CountryCode
	      LEFT JOIN Mountains m ON mc.MountainId = m.Id
	      LEFT JOIN Peaks p ON m.Id = p.MountainId) AS Ranked
WHERE RankedELevation = 1
ORDER BY Country, [Highest Peak Name]
	 
	 