/* ***********************
	Section 1. DDL 
**************************/

CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL,
	CHECK ([Length] >= 10 AND [Length] <= 25),
	RingRange DECIMAL(3,2) NOT NULL
	CHECK (RingRange >= 1.5 AND RingRange <= 7.5)
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX) 
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT REFERENCES Brands(Id) NOT NULL,
	TastId INT REFERENCES Tastes(Id) NOT NULL,
	SizeId INT REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar DECIMAL(18,2) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars
(
	ClientId INT REFERENCES Clients(Id) NOT NULL,
	CigarId INT REFERENCES Cigars(Id) NOT NULL,
	CONSTRAINT PK_ClientId_CigarId PRIMARY KEY (ClientId,CigarId)
)

/* ***********************
	Section 2. DML 
**************************/

--INSERT

INSERT INTO Cigars (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
	('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
	('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
	('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
	('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
	('TRINIDAD COLONIALES', 2, 3, 8, 85.21,	'trinidad-coloniales-stick_30.jpg')
	
INSERT INTO Addresses(Town, Country, Streat, ZIP)
VALUES
	('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
	('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
	('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')
	
--UPDATE

UPDATE Cigars
SET PriceForSingleCigar = PriceForSingleCigar + PriceForSingleCigar * 0.2
WHERE TastId IN (SELECT ID From Tastes WHERE TasteType = 'Spicy')

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--DELETE

DELETE FROM Clients 
WHERE AddressId IN (SELECT Id FROM Addresses WHERE Country LIKE 'c%')

DELETE FROM Addresses
WHERE Country LIKE 'c%'

/* ***********************
	Section 3. Querying 
**************************/

--Cigars by Price

SELECT CigarName,
       PriceForSingleCigar,
	   ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar, CigarName

--Cigars by Taste

SELECT c.Id, 
       CigarName,
	   PriceForSingleCigar,
	   TasteType,
	   TasteStrength
FROM Cigars c
JOIN Tastes t ON c.TastId = t.Id
WHERE TasteType IN ('Earthy', 'Woody')
ORDER BY PriceForSingleCigar DESC

--Clients without Cigars

SELECT Id,
       CONCAT(FirstName, ' ', LastName) AS ClientName,
	   Email
FROM Clients 
WHERE Id NOT IN (SELECT ClientId FROM ClientsCigars)
ORDER BY ClientName

--First 5 Cigars

SELECT TOP(5) CigarName,
              PriceForSingleCigar,
			  ImageURL
FROM Cigars c
     JOIN Sizes s ON c.SizeId = s.Id
WHERE [Length] >= 12 AND ((CigarName LIKE '%ci%') OR (PriceForSingleCigar > 50 AND RingRange > 2.55))
ORDER BY CigarName, PriceForSingleCigar DESC

--Clients with ZIP Codes

SELECT FirstName + ' ' + LastName AS FullName,
       Country, 
	   ZIP,
	   '$' + CONVERT(VARCHAR, MAX(PriceForSingleCigar)) AS CigarPrice
FROM Clients c
     JOIN Addresses a ON c.AddressId = a.Id
     JOIN ClientsCigars cc ON c.Id = cc.ClientId
     JOIN Cigars cig ON cc.CigarId = cig.Id
WHERE ZIP NOT LIKE '%[^0-9]%'
GROUP BY c.Id, FirstName + ' ' + LastName, Country, ZIP
ORDER BY FullName

--Cigars by Size

SELECT LastName, 
       AVG(Length) AS CiagrLength,
	   CEILING(AVG(RingRange)) AS CiagrRingRange 
FROM Clients c
JOIN ClientsCigars cc ON c.Id = cc.ClientId
JOIN Cigars cig ON cig.Id = cc.CigarId
JOIN Sizes s ON cig.SizeId = s.Id
GROUP BY LastName
ORDER BY AVG(Length) DESC

/* ***********************
	Section 4. Programmability 
**************************/

--Client with Cigars

CREATE FUNCTION  udf_ClientWithCigars(@name VARCHAR(30)) 
RETURNS INT
AS
BEGIN

DECLARE @result INT = (SELECT COUNT(*) 
FROM Clients c
JOIN ClientsCigars cc ON c.Id = cc.ClientId
JOIN Cigars cig ON cc.CigarId = cig.Id
WHERE FirstName = @name)

RETURN @Result
END

--Search for Cigar with Specific Taste

CREATE PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN

SELECT CigarName, 
       '$' + CONVERT(VARCHAR,PriceForSingleCigar) AS Price,
	   TasteType,
	   BrandName,
	   CONVERT(VARCHAR, Length) + ' cm' AS CigarLength,
	   CONVERT(VARCHAR,RingRange) + ' cm' AS CigarRingRange
FROM Cigars c
JOIN Sizes s ON c.SizeId = s.Id
JOIN Tastes t ON c.TastId = t.Id
JOIN Brands b ON b.Id = c.BrandId
WHERE TasteType = @taste
ORDER BY CigarLength, CigarRingRange DESC

END

