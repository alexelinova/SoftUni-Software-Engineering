/* ********************************
	Section 1. DDL
***********************************/
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT REFERENCES Repositories(Id),
	ContributorId INT REFERENCES Users(Id),
	CONSTRAINT PK_Repository_Contributor PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(20,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT REFERENCES Commits(Id) NOT NULL
)

/* ********************************
	Section 2. DML
***********************************/
--INSERT

INSERT INTO Files ([Name], Size, ParentId, CommitId)
VALUES  ('Trade.idk', 2598.0, 1, 1),
		('menu.net', 9238.31, 2, 2),
		('Administrate.soshy', 1246.93, 3, 3),
		('Controller.php', 7353.15, 4, 4),
		('Find.java', 9957.86, 5, 5),
		('Controller.json', 14034.87, 3, 6),
		('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId)
VALUES  ('Critical Problem with HomeController.cs file', 'open', 1, 4),
		('Typo fix in Judge.html', 'open', 4, 3),
		('Implement documentation for UsersService.cs', 'closed', 8, 2),
		('Unreachable code in Index.cs', 'open', 9,	8)

--UPDATE

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--DELETE

DELETE FROM RepositoriesContributors
WHERE RepositoryId = 3

DELETE FROM Issues
WHERE RepositoryId = 3

/* ********************************
	Section 3. Querying 
***********************************/

--Commits

SELECT Id, 
       [Message], 
	   RepositoryId, 
	   ContributorId
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

--Front-end

SELECT Id, 
       [Name],
	   Size
FROM Files
WHERE Size > 1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id, [Name]

----Issue Assignment

SELECT i.Id,
        Username + ' : ' + Title AS IssueAssignee
FROM Issues i
JOIN Users u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, IssueAssignee

----Single Files

SELECT  Id, 
        [Name],
        CONVERT(VARCHAR, Size) + 'KB' AS Size
FROM Files f
WHERE Id NOT IN (SELECT ParentId FROM Files
                 WHERE ParentID IS NOT NULL)
ORDER BY Id, [Name], f.Size DESC

----Commits in Repositories

SELECT TOP (5) r.Id,
               r.[Name],
               Count(*) AS Commits
FROM Users u
     JOIN RepositoriesContributors rc ON u.Id = rc.ContributorId
     JOIN Repositories r ON rc.RepositoryId = r.Id
     JOIN Commits c ON r.Id = c.RepositoryId
GROUP BY r.Id,r.[Name]
ORDER BY Commits DESC, r.Id, r.[Name]


----Average Size

SELECT Username, 
	   AVG(Size) AS Size
FROM Users u
	 JOIN Commits c ON c.ContributorId = u.Id
	 JOIN Files f ON c.Id = f.CommitId
GROUP BY Username
ORDER BY AVG(Size) DESC, Username


/* ********************************
Section 4. Programmability 
***********************************/

--All User Commits

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
BEGIN
DECLARE @contributorID INT= (SELECT Id FROM Users WHERE Username = @username)

DECLARE @result INT = (SELECT COUNT(*) FROM Commits
					WHERE ContributorId = @contributorID)

RETURN @result
END

--Search of Files

CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(20))
AS

SELECT Id,
       [Name],
	   Convert(VARCHAR, Size) + 'KB' AS Size
FROM Files f
WHERE [Name] LIKE '%.' + @fileExtension
ORDER BY Id, [Name], f.Size DESC


