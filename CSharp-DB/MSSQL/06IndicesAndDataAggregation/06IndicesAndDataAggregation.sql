/* *************************************************
Problem 1. Records’ Count
****************************************************/

SELECT COUNT(*) 
FROM WizzardDeposits

/* *************************************************
Problem 2. Longest Magic Wand
****************************************************/

SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

/* *************************************************
Problem 3. Longest Magic Wand per Deposit Groups
****************************************************/

SELECT DepositGroup, 
       Max(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

/* *************************************************
Problem 4. Smallest Deposit Group Per Magic Wand Size
****************************************************/

SELECT TOP (2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) 

/* *************************************************
Problem 5. Deposits Sum
****************************************************/

SELECT DepositGroup,
       Sum(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

/* *************************************************
Problem 6. Deposits Sum for Ollivander Family
****************************************************/

SELECT DepositGroup,
       Sum(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

/* *************************************************
Problem 7. Deposits Filter
****************************************************/

SELECT DepositGroup,
       Sum(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING Sum(DepositAmount) < 150000
ORDER BY TotalSum DESC

/* *************************************************
Problem 8. Deposit Charge
****************************************************/

SELECT DepositGroup,
       MagicWandCreator,
	   MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

/* *************************************************
Problem 9. Age Groups
****************************************************/
Select AgeGroup,
       COUNT(*) AS WizardCount
FROM
   (SELECT 
      CASE
	       WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
		   WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
		   WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
		   WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
		   WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
		   WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
		   ELSE '[61+]'
	 END AS AgeGroup
   FROM WizzardDeposits) AS GroupedByAge
GROUP BY AgeGroup


/* *************************************************
Problem 10. First Letter
****************************************************/

SELECT Left(FirstName, 1) AS FirstLetter 
  FROM WizzardDeposits
 WHERE DepositGroup = 'Troll Chest'
 GROUP BY Left(FirstName, 1) 
ORDER BY FirstLetter


/* *************************************************
Problem 11. Average Interest
****************************************************/

SELECT DepositGroup,
       IsDepositExpired,
	   AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

/* *************************************************
Problem 12. Rich Wizard, Poor Wizard
****************************************************/
SELECT Sum([Difference]) AS SumDifference
       FROM
			(SELECT wd.FirstName AS [Host Wizard],
				   wd.DepositAmount AS [Host Wizard Deposit],
				   wg.FirstName AS [Guest Wizard],
				   wg.DepositAmount AS [Guest Wizard Deposit],
				   wd.DepositAmount - wg.DepositAmount AS [Difference]
			FROM WizzardDeposits wd
			JOIN WizzardDeposits wg ON wd.Id = wg.Id - 1
			) DepositDifference

/* Alternative solution */

SELECT SUM([Difference]) AS SumDifference
FROM
			(SELECT FirstName AS [Host Wizard],
				   DepositAmount AS [Host Wizard Deposit],
				   LEAD(FirstName, 1) OVER (ORDER BY Id) AS [GuestWizard],
				   LEAD(DepositAmount, 1) OVER (ORDER BY Id) AS [Guest Wizard Deposit],
				   DepositAmount - LEAD(DepositAmount, 1) OVER (ORDER BY Id) AS [Difference]
			FROM WizzardDeposits
			) AS [DepositDiff]

/* *************************************************
Problem 13. Departments Total Salaries
****************************************************/

USE SoftUni

SELECT DepartmentID,
       Sum(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

/* *************************************************
Problem 14. Employees Minimum Salaries
****************************************************/

SELECT DepartmentID,
       MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN(2, 5, 7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

/* *************************************************
Problem 15. Employees Average Salaries
****************************************************/

SELECT *
INTO EmployeesWithSalariesAbove30000
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithSalariesAbove30000
WHERE ManagerID = 42

UPDATE EmployeesWithSalariesAbove30000
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID,
       AVG(Salary) AS AverageSalary
FROM EmployeesWithSalariesAbove30000
GROUP BY DepartmentID


/* *************************************************
Problem 16. Employees Maximum Salaries
****************************************************/

SELECT DepartmentID,
       MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

/* *************************************************
Problem 17. Employees Count Salaries
****************************************************/

SELECT Count(*) AS Count
FROM Employees
WHERE ManagerID IS NULL

/* *************************************************
Problem 18. 3rd Highest Salary
****************************************************/
SELECT DepartmentID,
       [Salary] AS ThirdHighestSalary
FROM
				(SELECT *,
					   DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Rank]
				FROM Employees
				) AS RankedSalaries
WHERE [Rank] = 3
GROUP BY DepartmentID, Salary

/* *************************************************
Problem 19. Salary Challenge
****************************************************/

SELECT TOP (10) FirstName,
                LastName,
	            DepartmentID
FROM Employees as e
WHERE Salary > (SELECT AVG(Salary)
                FROM Employees as em
                WHERE e.DepartmentID = em.DepartmentID)
				

