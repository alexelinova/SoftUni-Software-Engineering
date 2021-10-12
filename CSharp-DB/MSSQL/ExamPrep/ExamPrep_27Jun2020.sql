
/* ********************************
	Section 1. DDL
***********************************/

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone VARCHAR(12) NOT NULL,
	CHECK (LEN(Phone) = 12)
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) DEFAULT 'Pending'
	CHECK ([Status] IN('Pending', 'In Progress', 'Finished' )),
	ClientId INT REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 'False' NOT NULL
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL(18,2),
	CHECK (Price > 0),
	VendorId INT REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT DEFAULT 0 NOT NULL,
	CHECK (StockQty >= 0)
)

CREATE TABLE OrderParts
(
	OrderId INT REFERENCES Orders(OrderId) NOT NULL,
	PartId INT REFERENCES Parts(PartId) NOT NULL,
	CONSTRAINT PK_OrderId_PartId PRIMARY KEY (OrderId, PartId),
	Quantity INT DEFAULT 1 NOT NULL,
	CHECK (Quantity > 0)
)

CREATE TABLE PartsNeeded
(
	JobId INT REFERENCES Jobs(JobId),
	PartId INT REFERENCES Parts(PartId),
	CONSTRAINT PK_JobId_PartId PRIMARY KEY(JobId, PartId),
	Quantity INT DEFAULT 1 NOT NULL,
	CHECK (Quantity > 0)
)

/* ********************************
	Section 2. DML
***********************************/
--INSERT

INSERT INTO Clients(FirstName, LastName, Phone)
VALUES
		('Teri', 'Ennaco', '570-889-5187'),
		('Merlyn', 'Lawler', '201-588-7810'),
		('Georgene', 'Montezuma', '925-615-5185'),
		('Jettie', 'Mconnell', '908-802-3564'),
		('Lemuel', 'Latzke', '631-748-6479'),
		('Melodie', 'Knipp', '805-690-1682'),
		('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts(SerialNumber, [Description], Price, VendorId)
VALUES 
		('WP8182119','Door Boot Seal', 117.86, 2),
		('W10780048','Suspension Rod', 42.81, 1),
		('W10841140','Silicone Adhesive', 6.77, 4),
		('WPY055980','High Temperature Adhesive', 13.94, 3)

--UPDATE

UPDATE Jobs
SET MechanicId = 3, Status = 'In Progress'
WHERE [Status] = 'Pending'

--DELETE

DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderID = 19

/* ********************************
	Section 3. Querying 
***********************************/

--Mechanic Assignments

SELECT CONCAT(Firstname, ' ', LastName) AS [Full Name],
       Status,
	   IssueDate
FROM Mechanics m
     LEFT JOIN Jobs j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, IssueDate, JobId

--Current Clients

SELECT CONCAT(Firstname, ' ', LastName) AS Client,
       DATEDIFF(DAY, IssueDate, '2017-04-24') AS [Days going],
	   Status
FROM Jobs j
JOIN Clients c ON j.ClientId = c.ClientId
WHERE Status != 'Finished'
ORDER BY [Days going] DESC, c.ClientId

--Mechanic Performance

SELECT CONCAT (FirstName, ' ', LastName) AS [Mechanic],
       AVG(DATEDIFF(DAY, IssueDate, FinishDate)) AS DaysToFinish
FROM Mechanics m
JOIN Jobs j ON m.MechanicId = j.MechanicId
WHERE Status = 'Finished'
GROUP BY CONCAT (FirstName, ' ', LastName), m.MechanicId
ORDER BY m.MechanicId

--Available Mechanics

SELECT (m.FirstName + ' '+ m.LastName)
 AS [Available]
FROM Mechanics m
LEFT JOIN Jobs j ON m.MechanicId = j.MechanicId
WHERE j.JobId IS NULL OR (SELECT Count(*)
							FROM Jobs j
							WHERE STATUS <> 'Finished' AND m.MechanicId = j.MechanicId
							GROUP BY MechanicId, Status) IS NULL
GROUP BY m.MechanicId, (m.FirstName + ' '+ m.LastName)

SELECT * 
FROM Mechanics m
LEFT JOIN Jobs j ON m.MechanicId = j.MechanicId

--Past Expenses

SELECT j.JobId,
       ISNULL(SUM(Price * op.Quantity),0.00) AS Total
FROM Jobs j 
      LEFT JOIN Orders o ON j.JobId = o.JobId
      LEFT JOIN OrderParts op ON o.OrderId = op.OrderId
      LEFT JOIN Parts p ON op.PartId = p.PartId
WHERE [Status] = 'Finished'
GROUP BY j.JobId
Order By Total DESC, JobId

--Missing Parts

SELECT PartId, 
       [Description], 
	   SUM([Required]) AS [Required],
	   Min([In Stock]) AS [In Stock],
	   Min(Ordered) AS Ordered
FROM
	(SELECT p.PartId, p.[Description], pn.Quantity AS [Required], ISNULL(p.StockQty, 0) AS [In Stock], ISNULL(op.Quantity, 0) AS Ordered
	FROM Jobs j
	LEFT JOIN PartsNeeded pn ON j.JobId = pn.JobId
	LEFT JOIN Parts p ON p.PartId = pn.PartId
	LEFT JOIN Orders o ON o.JobId = j.JobId
	LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
	WHERE [Status] != 'Finished' AND (pn.Quantity IS NOT NULL AND o.Delivered IS NULL)) AS [DATA]
GROUP BY PartId, [Description]
Having SUM([Required])- Min([In Stock])  >  Min(Ordered)
ORDER BY PartId

/* ********************************
	Section 4. Programmability 
***********************************/

--Place Order

CREATE PROCEDURE usp_PlaceOrder (@JobId INT, @SerialNumber VARCHAR(50), @Quantity INT)
AS

DECLARE @JobStatus VARCHAR(50) = (SELECT [Status] FROM Jobs WHERE JobId = @JobId)
DECLARE @PartID INT = (SELECT PartId FROM Parts WHERE SerialNumber = @SerialNumber)

IF (@Quantity <= 0)
	THROW 50012, 'Part quantity must be more than zero!', 1
ELSE IF (@JobStatus IS NULL)
	THROW 50013, 'Job not found!', 1
ELSE IF (@JobStatus = 'Finished')
	THROW 50011, 'This job is not active!', 1 
ELSE IF (@PartId IS NULL)
	THROW 50014, 'Part not found!', 1

DECLARE @OrderId INT = (SELECT OrderId FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL)

IF (@OrderId IS NULL)
BEGIN
    INSERT INTO Orders (JobId, IssueDate)
	VALUES (@JobId, NULL)
END

SET @OrderId = (SELECT OrderId FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL)
DECLARE @PartInORders INT = (SELECT OrderId FROM OrderParts WHERE PartId = @PArtID AND OrderId = @OrderId)

IF(@PartInORders IS NULL)
BEGIN
	INSERT INTO OrderParts(OrderId, PartId, Quantity)
	VALUES 
			(@OrderId, @PartID, @Quantity)	
END
ELSE
BEGIN
		UPDATE OrderParts
		SET Quantity += @Quantity
		WHERE OrderId = @OrderId AND PartId = @PartID
END

--Cost of Order

CREATE FUNCTION udf_GetCost (@JobId INT)
RETURNS DECIMAL(18,2)
AS
BEGIN
DECLARE @result DECIMAL(18,2) = ISNULL((SELECT SUM(p.Price * op.Quantity)
                                    FROM Orders o
                                    JOIN OrderParts op ON o.OrderId = op.OrderId
                                    JOIN Parts p ON op.PartId = p.PartId
                                    WHERE JobId = @JobId
                                    GROUP BY JobId),0)

RETURN @result
END
