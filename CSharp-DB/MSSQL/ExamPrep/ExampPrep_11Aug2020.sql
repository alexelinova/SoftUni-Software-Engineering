
/* ********************************
	Section 1. DDL
***********************************/

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25) NOT NULL,
	LastName NVARCHAR(25) NOT NULL,
	Gender CHAR(1)
	CHECK (Gender LIKE '[m|f]'),
	Age INT,
	PhoneNumber CHAR(10),
	CountryId INT REFERENCES Countries(Id)
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	[Description] NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price DECIMAL(18,2)
	CHECK (Price >= 0)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(255),
	Rate DECIMAL(5,2)
	CHECK (Rate >= 0 AND Rate <=10),
	ProductId INT REFERENCES Products(Id),
	CustomerId INT REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[Description] NVARCHAR(200),
	OriginCountryId INT REFERENCES Countries(Id),
	DistributorId INT REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT REFERENCES Products(Id),
	IngredientId INT REFERENCES Ingredients(Id),
	PRIMARY KEY (ProductId, IngredientId)
)

/* ********************************
	Section 2. DML
***********************************/

--INSERT

INSERT INTO Distributors([Name], CountryId, AddressText, Summary)
VALUES ('Deloitte & Touche', 2 ,'6 Arch St #9757', 'Customizable neutral traveling'),
       ('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
       ('Kitchen People', 1, '3 E 31st St #77',	'Triple-buffered stable delivery'),
       ('General Color Co Inc',	21,	'6185 Bohn St #72', 'Focus group'),
       ('Beck Corporation',	23,	'21 E 64th Ave','Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
VALUES ('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
       ('Kendra', 'Loud', 22, 'F', '0063631526', 11),
       ('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
       ('Hannah', 'Edmison', 18, 'F', '0043343686',	1),
       ('Tom', 'Loeza',	31,	'M', '0144876096', 23),
       ('Queenie', 'Kramarczyk', 30, 'F', '0064215793',	29),
       ('Hiu', 'Portaro', 25, 'M',  '0068277755', 16),
       ('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

--UPDATE

UPDATE Ingredients
SET DistributorId = 35
WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--DELETE

DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

/* ********************************
	Section 3. Querying
***********************************/

--Products by Price

SELECT [Name],
       Price,
	   [Description]
FROM Products
ORDER BY Price DESC, [Name] ASC

--Negative Feedback

SELECT ProductId,
       Rate,
	   [Description],
	   CustomerId,
	   Age,
	   Gender
FROM Feedbacks f
JOIN Customers c ON f.CustomerId = c.Id
WHERE Rate < 5.0
ORDER BY ProductId DESC, Rate

--Customers without Feedback

SELECT CONCAT(FirstName, ' ', LastName) AS CustomerName,
       PhoneNumber,
	   Gender
From Customers c
     LEFT JOIN Feedbacks f ON c.Id = f.CustomerId
WHERE c.Id NOT IN (SELECT CustomerId FROM Feedbacks)
ORDER BY CustomerId

--Customers by Criteria

SELECT FirstName,
       Age,
	   PhoneNumber
FROM Customers c
     JOIN Countries ctr ON c.CountryId = ctr.Id
WHERE (Age >= 21 AND FirstName LIKE '%an%') OR (PhoneNumber LIKE '%38' AND ctr.[Name] != 'Greece')
ORDER BY FirstName, Age DESC

--Middle Range Distributors

SELECT d.Name AS DistributorName,
       i.Name AS IngredientName,
	   p.Name AS ProductName,
       AVG(Rate) AS AverageRate
FROM Distributors d
	 JOIN Ingredients i ON d.Id = i.DistributorId
	 JOIN ProductsIngredients pin ON i.Id = pin.IngredientId
	 JOIN Products p ON pin.ProductId = p.Id
	 JOIN Feedbacks f ON p.Id = f.ProductId
GROUP BY p.Id, p.[Name], i.[Name], d.[Name]
HAVING AVG(Rate) BETWEEN 5 AND 8
ORDER BY DistributorName, IngredientName, ProductName

--Country Representative
SELECT CountryName,
       DistributorName
FROM
		(SELECT *,
			   DENSE_RANK() OVER (Partition BY CountryName ORDER BY ProductsCount DESC) AS [RANK]
				FROM
				(SELECT c.[Name] AS CountryName,
					   d.[Name] AS DistributorName,
					   COUNT(i.Name) AS ProductsCount
				FROM Distributors d
				       LEFT JOIN Ingredients i ON d.Id = i.DistributorId
				       LEFT JOIN Countries c ON d.CountryId = c.Id
				GROUP BY c.[Name], d.[Name]) AS Distributors
		 ) AS RankedDistributors
WHERE [Rank] = 1
ORDER BY CountryName, DistributorName

/* ********************************
	Section 4. Programmability
***********************************/

--Customers with Countries

CREATE VIEW v_UserWithCountries 
AS
SELECT FirstName + ' ' + LastName AS CustomerName,
       Age, 
	   Gender,
	   ctr.[Name] AS CountryName
FROM Customers c
JOIN Countries ctr ON c.CountryId = ctr.Id

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

--Delete Products 

CREATE TRIGGER tr_DeleteProductRelations
ON PRODUCTS INSTEAD OF DELETE
AS
DELETE FROM Feedbacks
WHERE ProductId IN (SELECT Id FROM deleted)

DELETE FROM ProductsIngredients
WHERE ProductId IN (SELECT Id FROM deleted)

DELETE FROM Products WHERE Id IN (SELECT Id FROM deleted)

