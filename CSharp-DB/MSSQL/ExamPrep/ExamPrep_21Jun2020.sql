/* ********************************
	Problem 1. DDL
***********************************/

CREATE TABLE Cities 
( 
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(5,2)
)


CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT REFERENCES Rooms(Id) NOT NULL,
	BookDate DATE NOT NULL,
	CONSTRAINT check_bookDate CHECK (BookDate < ArrivalDate),
	ArrivalDate DATE NOT NULL,
	Constraint check_arrivalDate CHECK (ArrivalDate < ReturnDate),
	ReturnDate DATE NOT NULL,
	CancelDate DATE
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT REFERENCES Cities(Id),
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips
(
	AccountId INT REFERENCES Accounts(Id) NOT NULL,
	TripId INT REFERENCES Trips(Id) NOT NULL,
	CONSTRAINT PK_AccountId_TripId PRIMARY KEY (AccountId, TripId),
	Luggage INT NOT NULL,
	CONSTRAINT check_luggage CHECK(Luggage >= 0)
)

/* ********************************
	Problem 2. INSERT
***********************************/

INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES  ('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
        ('Gosho', NULL, 'Petrov', 11, '1978-05-16','g_petrov@gmail.com'),
		('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
		('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES  (101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
        (102, '2015-07-07',	'2015-07-15', '2015-07-22',	'2015-04-29'),
        (103, '2013-07-17',	'2013-07-23', '2013-07-24',	NULL),
        (104, '2012-03-17',	'2012-03-31', '2012-04-01', '2012-01-10'),
        (109, '2017-08-07',	'2017-08-28', '2017-08-29',	NULL)

/* ********************************
	Problem 3. UPDATE
***********************************/

UPDATE Rooms
SET Price = Price + 0.14 * PRICE
WHERE HotelId IN (5, 7, 9)

/* ********************************
	Problem 4. DELETE
***********************************/

DELETE FROM AccountsTrips
WHERE AccountId = 47

/* ********************************
	Problem 5. EEE-Mails
***********************************/

SELECT a.FirstName, 
       a.LastName,
	   FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate,
	   c.Name AS Hometown, 
	   a.Email
FROM Accounts a
     JOIN Cities c ON a.CityId = c.Id
WHERE a.Email LIKE 'e%'
ORDER BY Hometown

/* ********************************
	Problem 6. City Statistics
***********************************/

SELECT c.[Name] AS City, COUNT(*) AS Hotels
FROM Cities c
     JOIN Hotels h ON c.Id = h.CityId
GROUP BY c.[Name]
ORDER BY COUNT(*) DESC, c.[Name]

/* ********************************
	Problem 7. Longest and Shortest Trips
***********************************/

SELECT AccountId, 
       Concat(FirstName, ' ' + LastName) AS FullName,
       MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip, 
	   MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
   FROM Accounts a
        JOIN AccountsTrips atr ON a.Id = atr.AccountId
        JOIN Trips tr ON atr.TripId = tr.Id
   WHERE MiddleName IS NULL AND CancelDate IS NULL
   GROUP BY AccountId, Concat(FirstName, ' ' + LastName)
   ORDER BY LongestTrip DESC, ShortestTrip

/* ********************************
	Problem 8. Metropolis
***********************************/

SELECT TOP (10) c.Id,
                 c.[Name], 
				 c.CountryCode, 
				 Count(*) AS Accounts
 FROM Accounts a
      JOIN Cities c ON a.CityId = c.Id
 GROUP BY c.Id, c.[Name], c.CountryCode
 ORDER BY Accounts DESC

/* ********************************
	Problem 9. Romantic Getaways
***********************************/

SELECT a.Id, Email, cit.[Name] as City, Count(*) AS Trips FROM Accounts a
       JOIN Cities c ON a.CityId = c.Id
       JOIN AccountsTrips atr ON atr.AccountId = a.Id
       JOIN Trips tr ON atr.TripId = tr.Id
       JOIN Rooms r ON tr.RoomId = r.Id
       JOIN Hotels h ON r.HotelId = h.Id
       JOIN Cities cit ON h.CityId = cit.Id
WHERE cit.[Name] =c.[Name]
GROUP BY a.Id, Email, cit.[Name]
ORDER BY Trips DESC, Id

/* ********************************
	Problem 10. GDPR Violation
***********************************/

SELECT tr.Id, 
	   REPLACE(Concat(FirstName,' ', MiddleName, ' ', LastName),'  ', ' ')  AS [Full Name],
	   c.[Name] AS [From],
	   cit.[Name] AS [To],
	   CASE
			WHEN tr.CancelDate IS NULL THEN CAST(DATEDIFF(DAY, ArrivalDate, ReturnDate) AS VARCHAR) + ' ' + 'days'
			ELSE 'Canceled'
	   END AS Duration
FROM Accounts a
     JOIN Cities c ON a.CityId = c.Id
	 JOIN AccountsTrips atr ON a.Id = atr.AccountId
	 JOIN Trips tr ON atr.TripId = tr.Id
	 JOIN Rooms r ON tr.RoomId = r.Id
	 JOIN Hotels h ON r.HotelId = h.Id
	 JOIN Cities cit ON h.CityId = cit.Id
ORDER BY [Full Name], tr.Id

/* ********************************
	Problem 11. Available Room
***********************************/

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN

DECLARE @RoomInfo VARCHAR(MAX) = 
(
	SELECT TOP(1) 'Room ' + CONVERT(VARCHAR, r.Id) + ': ' + r.Type + ' (' + CONVERT(VARCHAR, r.Beds) +' beds) - $' + 
	CONVERT(VARCHAR,(Price + BaseRate) * @People)
	FROM Rooms r
		  JOIN Hotels h ON r.HotelId = h.Id
	WHERE Beds >= @People AND HotelId = @HotelId AND
		  NOT EXISTS(SELECT * FROM Trips t WHERE t.RoomId = r.Id AND CancelDate IS NULL 
		  AND @Date BETWEEN ArrivalDate AND ReturnDate)
	ORDER BY (Price + BaseRate) * @People DESC
)

IF @RoomInfo IS NULL
   RETURN 'No rooms available';

RETURN @RoomInfo
END


/* ********************************
	Problem 12.	Switch Room
***********************************/

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS

DECLARE @HotelIdOriginalRoom INT =	(SELECT HotelId FROM Trips t 
									JOIN Rooms r ON t.RoomId = r.Id 
									WHERE t.Id = @TripID)
DECLARE @HotelIdNewRoom INT = (SELECT HotelId FROM Rooms
                               WHERE Id = @TargetRoomId)

IF (@HotelIdNewRoom != @HotelIdOriginalRoom)
   Throw 50001, 'Target room is in another hotel!', 1

DECLARE @NumberOfAccounts INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId)
DECLARE @NumberOfBeds INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)

IF	(@NumberOfAccounts > @NumberOfBeds)
   THROW 50002, 'Not enough beds in target room!', 1

UPDATE Trips
SET RoomId = @TargetRoomId
WHERE Id = @TripId

