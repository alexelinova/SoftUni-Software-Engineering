/* ******************************************
	Problem 1. Create Table Logs
*********************************************/

CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT REFERENCES Accounts(Id) NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON Accounts FOR UPDATE
AS
INSERT INTO Logs(AccountId, OldSum, NewSum)
SELECT i.Id,
       d.Balance,
	   i.Balance
FROM deleted d
JOIN inserted i ON d.Id = i.Id
WHERE d.Balance != i.Balance

/* ******************************************
	Problem 2. Create Table Emails
*********************************************/

CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT REFERENCES Accounts(Id) NOT NULL,
	[Subject] NVARCHAR(200),
	Body NVARCHAR(MAX)
)

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
INSERT INTO NotificationEmails(Recipient, [Subject], Body)
SELECT 
AccountId,
'Balance change for account: ' + CONVERT(VARCHAR(20), AccountId),
'On ' + CONVERT(VARCHAR(30), GETDATE()) + ' your balace was changed from ' + CONVERT(VARCHAR(20), OldSum) + ' to ' + CONVERT(VARCHAR(20), NewSum) + '.' 
FROM inserted

/* ******************************************
	Problem 3. Deposit Money 
*********************************************/

CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN TRANSACTION

DECLARE @account INT = (Select Id FROM Accounts WHERE Id = @AccountId)

IF (@account IS NULL)
	THROW 50001, 'Invalid account', 1

IF (@MoneyAmount < 0)
	THROW 50002, 'Negative amount', 1

UPDATE Accounts
SET Balance += @MoneyAmount
WHERE Id = @AccountId
COMMIT

/* ******************************************
	Problem 4. Withdraw Money 
*********************************************/

CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION

DECLARE @account INT = (Select Id FROM Accounts WHERE Id = @AccountId)

IF (@account IS NULL)
	THROW 50001, 'Invalid account', 1

IF (@MoneyAmount < 0)
	THROW 50002, 'Negative amount', 1

DECLARE @currentBalance DECIMAL(18,4) = (SELECT Balance FROM Accounts WHERE Id = @AccountId)

--Added additional check for sufficient balance /Not accepted in judge/
IF	(@currentBalance < @MoneyAmount)
	THROW 50003, 'Insufficient amount', 1

UPDATE Accounts
SET Balance -= @MoneyAmount
WHERE Id = @AccountId
COMMIT

/* ******************************************
	Problem 5. Money Transfer 
*********************************************/

CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4))
AS
BEGIN TRANSACTION

EXEC usp_WithdrawMoney @SenderId, @Amount

EXEC  usp_DepositMoney @ReceiverId, @Amount

COMMIT

/* ******************************************
	Problem 6. Trigger
*********************************************/

--Trigger for restricting buying items with higher level than the users

CREATE TRIGGER tr_RestrictsBuyingItemsWithHigherLevelThanUsers
ON UserGameItems INSTEAD OF INSERT
AS
DECLARE @userGameId INT = (SELECT UserGameId from inserted)
DECLARE @userLevel INT = (SELECT Level from UsersGames WHERE Id = @userGameId)

DECLARE @itemId INT = (SELECT ItemId from inserted)
DECLARE @minItemLevel INT = (SELECT MinLevel from Items WHERE Id = @itemId)

IF	(@userLevel >= @minItemLevel)
BEGIN
	INSERT INTO UserGameItems(ItemId, UserGameId)
	SELECT ItemId, UserGameId FROM inserted
END

--Increase Cash for specific users playing the game 'Bali'

UPDATE UsersGames
SET Cash += 50000
WHERE GameId = (SELECT Id FROM Games WHERE [Name] = 'Bali')
      AND UserId IN (SELECT Id FROM Users WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))

--Buy items for specific users and deduct cash 

CREATE PROCEDURE usp_BuyItem @userId INT, @itemId INT, @gameId INT
AS
BEGIN TRANSACTION
DECLARE @user INT  = (SELECT Id FROM Users WHERE Id = @userId)
DECLARE @item INT = (SELECT Id FROM Items WHERE Id = @itemId)
DECLARE @game INT = (SELECT Id FROM Games WHERE Id = @gameId)

IF	(@user IS NULL OR @item IS NULL OR @game IS NULL)
	THROW 50001, 'Invalid user, item or game Id', 1

DECLARE @userCash DECIMAL(18,2) = (SELECT Cash FROM UsersGames WHERE GameId = @gameId AND UserId = @userId)
DECLARE @itemPrice DECIMAL(18,2) = (SELECT Price FROM Items WHERE Id = @itemId)

IF	(@userCash < @itemPrice)
	THROW 50002, 'Insufficient money', 1

UPDATE UsersGames
SET Cash -= @itemPrice
WHERE UserId = @userId AND GameId = @gameId

DECLARE @userGameId INT  = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)

INSERT INTO UserGameItems (ItemId, UserGameId)
VALUES (@itemId, @userGameId)
COMMIT
GO

--Buy items with id between 251 and 299 and between 501 and 539 for users baleremuda, loosenoise, inguinalself, buildingdeltoid, monoxidecos

DECLARE @itemId INT = 251

WHILE (@itemId <= 299)
BEGIN
	EXEC usp_BuyItem 37, @itemId, 212
	EXEC usp_BuyItem 52, @itemId, 212
	EXEC usp_BuyItem 61, @itemId, 212
	EXEC usp_BuyItem 22, @itemId, 212

	SET @itemId += 1
END
GO

DECLARE @itemId INT = 501

WHILE (@itemId <= 539)
BEGIN
	EXEC usp_BuyItem 37, @itemId, 212
	EXEC usp_BuyItem 52, @itemId, 212
	EXEC usp_BuyItem 61, @itemId, 212
	EXEC usp_BuyItem 22, @itemId, 212

	SET @itemId += 1
END

--Select all users in the current game 'Bali' with their items. Display username, game name, cash and item name.

SELECT Username, 
       g.Name,
	   ug.Cash,
	   i.Name
FROM Users u
     JOIN UsersGames ug ON u.Id = ug.UserId
     JOIN Games g ON ug.GameId = g.Id
     JOIN UserGameItems ugi ON ugi.UserGameId = g.Id
	 JOIN Items i ON ugi.ItemId = i.Id
WHERE g.Name = 'Bali'
ORDER BY Username, i.Name

/* ******************************************
	Problem 7. Massive Shopping
*********************************************/
--Stamat Id 9
--Safflower Id 87
--Make Transactions for buying all items for 2 Level Ranges : from 11 to 12 and from 19 to 21

DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = 9 AND GameId = 87)

DECLARE @stamatCash DECIMAL(18,2) = (SELECT Cash FROM UsersGames
                                     WHERE Id = @userGameId)

DECLARE @itemPrice DECIMAL(18,2) = (SELECT SUM(Price) AS TotalPrice FROM Items
                                    WHERE MinLevel BETWEEN 11 AND 12)

IF	(@stamatCash >= @itemPrice)
BEGIN
	BEGIN TRANSACTION

	UPDATE UsersGames
	SET Cash -= @itemPrice
	WHERE Id = @userGameId
	
	INSERT INTO UserGameItems(ItemId, UserGameId)
	SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 11 AND 12
COMMIT
END

SET @stamatCash =(SELECT Cash FROM UsersGames WHERE Id = @userGameId)
SET @itemPrice = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 19 AND 21)

IF	(@stamatCash >= @itemPrice)
BEGIN
BEGIN TRANSACTION

UPDATE UsersGames
SET Cash -= @itemPrice
WHERE Id = @userGameId

INSERT INTO UserGameItems(ItemId, UserGameId)
SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 19 AND 21
COMMIT
END

SELECT i.[Name] AS [Item Name]
FROM Users u
     JOIN UsersGames ug ON u.Id = ug.UserId
	 JOIN Games g ON ug.GameId = g.Id
	 JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
	 JOIN Items i ON ugi.ItemId = i.Id
WHERE u.Username = 'Stamat' and g.[Name] = 'Safflower'
ORDER BY [Item Name]

/* ******************************************
	Problem 8. Employees with Three Projects
*********************************************/

CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION

DECLARE @employee INT = (SELECT EmployeeId FROM Employees WHERE EmployeeID = @emloyeeId)
DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @projectID)

IF (@employee IS NULL OR @project IS NULL)
BEGIN
    ROLLBACK
	RAISERROR('Invalid employee ID or project ID', 16, 1)
END
DECLARE @numberOfProjects INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)

IF	(@numberOfProjects >= 3)
BEGIN
    ROLLBACK
	RAISERROR('The employee has too many projects!', 16, 2)
END

INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
VALUES (@emloyeeId, @projectID)
COMMIT

/* ******************************************
	Problem 9. Delete Employees
*********************************************/

CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50),
	LastName VARCHAR(50), 
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(50),
	DepartmentId INT,
	Salary MONEY
)

CREATE TRIGGER tr_DeletedEmployees
ON Employees FOR DELETE
AS
INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
SELECT FirstName, 
	   LastName,
	   MiddleName, 
	   JobTitle, 
	   DepartmentId, 
	   Salary
FROM deleted