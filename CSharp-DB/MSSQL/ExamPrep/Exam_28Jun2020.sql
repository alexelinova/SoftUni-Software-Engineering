/* ********************************
	Section 1. DDL
***********************************/

CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME2 NOT NULL,
	JourneyEnd DATETIME2 NOT NULL,
	Purpose VARCHAR(11),
	CHECK (Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT REFERENCES Spaceships(Id) NOT NULL,
)

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber CHAR(10) UNIQUE NOT NULL,
	JobDuringJourney VARCHAR(8),
	CHECK (JobDuringJourney IN('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT REFERENCES Journeys(Id) NOT NULL
)

/* ********************************
	Section 1. DML
***********************************/

--INSERT 

INSERT INTO Planets([Name])
VALUES ('Mars'),
       ('Earth'),
       ('Jupiter'),
       ('Saturn')

INSERT INTO Spaceships([Name], [Manufacturer], LightSpeedRate)
VALUES ('Golf','VW', 3),
       ('WakaWaka', 'Wakanda', 4),
       ('Falcon9', 'SpaceX', 1),
       ('Bed', 'Vidolov', 6)

--UPDATE

UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

--DELETE

DELETE FROM TravelCards
WHERE JourneyId IN (1, 2, 3)

DELETE FROM Journeys
WHERE Id IN (1, 2, 3)

/* ********************************
	Section 3. Querying 
***********************************/

--Select all military journeys

SELECT Id, 
       FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart,
	   FORMAT(JourneyEnd,'dd/MM/yyyy') AS JourneyEnd
FROM Journeys j
WHERE Purpose = 'Military'
ORDER BY JourneyStart


--Select all pilots

SELECT c.Id,
       FirstName + ' ' + LastName AS full_name
FROM Colonists c
JOIN TravelCards tc ON c.Id = tc.ColonistId
WHERE JobDuringJourney = 'Pilot'
ORDER BY c.Id 

--Count colonists

SELECT Count(*) AS [count]
FROM Colonists c
JOIN TravelCards tc ON c.Id = tc.ColonistId
JOIN Journeys j ON tc.JourneyId = j.Id
WHERE Purpose = 'technical'

--Select spaceships with pilots younger than 30 years

SELECT DISTINCT s.[Name],
                Manufacturer
FROM Colonists c
	 JOIN TravelCards tc ON c.Id = tc.ColonistId
	 JOIN Journeys j ON tc.JourneyId = j.Id
	 JOIN Spaceships s ON j.SpaceshipId = s.Id
WHERE (Birthdate >= '1989-01-01') AND tc.JobDuringJourney = 'Pilot'
ORDER BY s.[Name]

--Select all planets and their journey count

SELECT [Name] AS PlanetName,
       SUM(SuccessfullJourney) AS JourneysCount
FROM
		(SELECT 
		        p.[Name],
				CASE 
				WHEN j.Id IS NULL THEN 0
				ELSE 1
				END AS SuccessfullJourney
		FROM Planets p 
			 LEFT JOIN Spaceports sp ON p.Id = sp.PlanetId
			 LEFT JOIN Journeys j ON sp.Id = j.DestinationSpaceportId) AS SuccessfullJourneys
GROUP BY [Name]
HAVING  SUM(SuccessfullJourney) != 0
ORDER BY JourneysCount DESC, PlanetName

--Select Second Oldest Important Colonist

SELECT * FROM
		(SELECT JobDuringJourney,
		        FirstName + ' ' + LastName AS FullName,
				DENSE_RANK() OVER (PARTITION BY JobDuringJourney ORDER BY c.BirthDate) AS JobRank
		FROM Colonists c
			 JOIN TravelCards tc ON c.Id = tc.ColonistId
			 JOIN Journeys j ON tc.JourneyId = j.Id
			 ) AS RANKED
WHERE JobRank = 2

/* ********************************
	Section 4. Programmability 
***********************************/

--Get Colonists Count

CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
DECLARE @countOfColonists INT =  (SELECT COUNT(*)
                                 FROM Colonists c
									  JOIN TravelCards tc ON c.Id = tc.ColonistId
									  JOIN Journeys j ON tc.JourneyId = j.Id
									  JOIN Spaceports sp ON j.DestinationSpaceportId = sp.Id
									  JOIN Planets p ON sp.PlanetId = p.Id
								 WHERE p.[Name] = @PlanetName)

RETURN @countOfColonists
END

--Change Journey Purpose

CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
DECLARE @findJourneyId INT = (SELECT Id FROM Journeys
                             WHERE Id = @JourneyId)

IF (@findJourneyId IS NULL)
	THROW 50001, 'The journey does not exist!', 1

DECLARE @existingPurpose VARCHAR(11) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)

IF (@existingPurpose = @NewPurpose)
	THROW 50002, 'You cannot change the purpose!', 1

UPDATE Journeys
SET Purpose = @NewPurpose
WHERE Id = @JourneyId

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'	