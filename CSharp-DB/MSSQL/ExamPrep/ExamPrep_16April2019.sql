/* ***********************
	Section 1. DDL 
**************************/

CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME2,
	ArrivalTime DATETIME2,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId VARCHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT REFERENCES Luggages(Id) NOT NULL,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets 
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL,
	FlightId INT REFERENCES Flights(Id) NOT NULL,
	LuggageId INT REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(18,2) NOT NULL
)

/* ***********************
	Section 2. DML 
**************************/

--INSERT

INSERT INTO Planes ([Name], Seats, [Range])
VALUES ('Airbus 336', 112, 5132),
       ('Airbus 330', 432, 5325),
       ('Boeing 369', 231, 2355),
       ('Stelt 297', 254, 2143),
       ('Boeing 338', 165, 5111),
       ('Airbus 558', 387, 1342),
       ('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes ([Type])
VALUES ('Crossbody Bag'),
       ('School Backpack'),
	   ('Shoulder Bag')

--UPDATE

UPDATE Tickets 
SET Price = Price + Price * 0.13
WHERE FlightId = (Select Id FROM FLights WHERE Destination = 'Carlsbad')

--DELETE

DELETE FROM Tickets
WHERE FlightId = (Select Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

/* ***********************
	Section 3. Querying  
**************************/

--The "Tr" Planes

SELECT * FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, Range

--Flight Profits

SELECT f.Id AS FlightId, 
       Sum(Price) AS Price
FROM Tickets t
     JOIN Flights f ON t.FlightId = f.Id
GROUP BY f.Id
ORDER BY Price DESC, FlightId

----Passenger Trips

SELECT FirstName + ' ' + LastName AS [Full Name],
       Origin, 
	   Destination
FROM Passengers p
     JOIN Tickets t ON p.Id = t.PassengerId
     JOIN Flights f ON t.FlightId = f.Id
ORDER BY [Full Name], Origin, Destination

----Non Adventures People

SELECT FirstName,
       LastName, 
	   Age
FROM Passengers
WHERE Id NOT IN (SELECT PassengerId FROM Tickets)
ORDER BY Age DESC, FirstName, LastName

----Full Info

SELECT FirstName + ' ' + LastName AS [Full Name],
       pl.[Name] AS [Plane Name],
	   CONCAT(Origin,' - ',Destination) AS Trip,
	   lt.[Type] AS [Luggage Type]
FROM Passengers p
     JOIN Tickets t ON p.Id = t.PassengerId
	 JOIN Luggages l ON t.LuggageId = l.Id
	 JOIN LuggageTypes lt ON l.LuggageTypeId = lt.Id
	 JOIN Flights f ON t.FlightId = f.Id
	 JOIN Planes pl ON pl.Id = f.PlaneId
ORDER BY [Full Name], [Plane Name], Trip, [Luggage Type]

------PSP

SELECT [Name],
       Seats,
	   Count(PassengerId) AS [Passengers Count]
FROM Planes p
     LEFT JOIN Flights f ON p.Id = f.PlaneId
	 LEFT JOIN Tickets t ON f.Id = t.FlightId
GROUP BY p.[Name], Seats
ORDER BY [Passengers Count] DESC, p.[Name], Seats

/* ***********************
	Section 4. Programmability  
**************************/

--Vacation

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(MAX)
BEGIN
DECLARE @result VARCHAR(MAX)
DECLARE @flightId INT = (SELECT Id FROM Flights 
                        WHERE Origin = @origin AND Destination = @destination)
DECLARE @price DECIMAL(18,2)

IF (@peopleCount <= 0)
BEGIN
    SET @result = 'Invalid people count!'
	RETURN @result
END

IF (@flightId IS NULL)
BEGIN
    SET @result ='Invalid flight!'
	RETURN @result
END

SET @price = @peopleCount * (SELECT Price FROM Tickets WHERE FlightId = @flightId)
SET @result = 'Total price '+ CONVERT(VARCHAR, @price)

RETURN @result
END

--Wrong Data

CREATE PROCEDURE usp_CancelFlights
AS

BEGIN
UPDATE Flights
SET DepartureTime = NULL, ArrivalTime = NULL
WHERE DepartureTime > ArrivalTime
END

