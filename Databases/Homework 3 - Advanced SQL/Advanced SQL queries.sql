------------------------------ Task  1 -------------------------------

SELECT FirstName + ' ' + LastName AS [Employee Name], Salary
FROM Employees
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)

------------------------------ Task  2 -------------------------------

SELECT FirstName + ' ' + LastName AS [Employee Name], Salary
FROM Employees
WHERE Salary <=
  (SELECT MIN(Salary) FROM Employees) * 1.1
ORDER BY Salary

------------------------------ Task  3 -------------------------------

SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], e.Salary, d.Name
FROM Employees e 
  JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = d.DepartmentID)

------------------------------ Task  4 -------------------------------

SELECT AVG(Salary) [Average Salary], DepartmentID
FROM Employees
WHERE DepartmentID = 1
GROUP BY DepartmentID

------------------------------ Task  5 -------------------------------

SELECT AVG(Salary) [Average Salary]
FROM 
	Employees AS e
	JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

------------------------------ Task  6 -------------------------------

SELECT COUNT(*) AS [Employees count]
FROM
	Employees AS e 
	JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

------------------------------ Task  7 -------------------------------

SELECT COUNT(ManagerId) AS [Employees with manager count]
FROM Employees

------------------------------ Task  8 -------------------------------

SELECT COUNT(*) AS [Employees with no manager count]
FROM Employees
WHERE ManagerID IS NULL

------------------------------ Task  9 -------------------------------

SELECT d.Name, AVG(Salary) AS [Average Salary]
	FROM Employees AS e JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

------------------------------ Task 10 -------------------------------

SELECT d.Name AS Department, t.Name AS Town, COUNT(*) AS [Employee count]
	FROM Employees AS e 
	JOIN Departments AS d
		ON e.DepartmentID = d.DepartmentID
	JOIN Addresses AS a
		ON e.AddressID = a.AddressID
	JOIN Towns AS t
		ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY d.Name

------------------------------ Task 11 -------------------------------

SELECT m.FirstName + ' ' + m.LastName AS [Employee Name]
FROM Employees AS e
	JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName + ' ' + m.LastName
HAVING COUNT(m.EmployeeID) = 5

------------------------------ Task 12 -------------------------------

SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
	ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS [Manager Name]
FROM Employees AS m RIGHT JOIN Employees AS e
	ON e.ManagerID = m.EmployeeID

------------------------------ Task 13 -------------------------------

SELECT FirstName + ' ' + LastName AS [Employee Name]
FROM Employees
WHERE LEN(LastName) = 5

------------------------------ Task 14 -------------------------------

SELECT CONVERT(CHAR(10), GETDATE(), 104) + ' ' + CONVERT(CHAR(12), GETDATE(), 114)

------------------------------ Task 15 -------------------------------

CREATE TABLE Users (
  Id int IDENTITY,
  Username nvarchar(50) NOT NULL,
  Password nvarchar(50) NOT NULL,
  FullName nvarchar(100),
  LastLogin DATETIME,
  CONSTRAINT PK_User PRIMARY KEY(Id),
  CONSTRAINT UNQ_User UNIQUE(Username),
  CONSTRAINT CK_Pwd CHECK(LEN(Password) > 4)
)
GO

------------------------------ Task 16 -------------------------------

CREATE VIEW [Today Logins] AS
SELECT Username, FullName FROM Users
WHERE CONVERT (date, LastLogin) = CONVERT (date, SYSDATETIME())
GO

------------------------------ Task 17 -------------------------------

CREATE TABLE Groups (
  Id int IDENTITY,
  Groupname nvarchar(50) NOT NULL,
  CONSTRAINT PK_Group PRIMARY KEY(Id),
  CONSTRAINT UNQ_Group UNIQUE(Groupname)
)
GO

------------------------------ Task 18 -------------------------------

ALTER TABLE Users
ADD GroupId int
GO
INSERT INTO Groups(Groupname) VALUES ('GroupOne')
INSERT INTO Groups(Groupname) VALUES ('GroupTwo')
GO
UPDATE Users SET GroupId = 1 
GO
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupId)
  REFERENCES Groups(Id)
GO

------------------------------ Task 19 -------------------------------

INSERT INTO Groups(Groupname) VALUES ('GroupThree')
INSERT INTO Groups(Groupname) VALUES ('GroupFour')
INSERT INTO Users(Username, Password, FullName, LastLogin, GroupId)
  VALUES ('Alpha','Alpha','Alpha Alpha', GETDATE(), 1)
INSERT INTO Users(Username, Password, FullName, LastLogin, GroupId)
  VALUES ('Beta','Betaa','Beta Beta', GETDATE(), 2)
INSERT INTO Users(Username, Password, FullName, LastLogin, GroupId)
  VALUES ('Gama','Gamaa','Gama Gama', GETDATE(), 3)
INSERT INTO Users(Username, Password, FullName, LastLogin, GroupId)
  VALUES ('Theta','Theta','Theta Theta', GETDATE(), 4)
INSERT INTO Users(Username, Password, FullName, LastLogin, GroupId)
  VALUES ('Sigma','Sigma','Sigma Sigma', GETDATE(), 3)
GO

------------------------------ Task 20 -------------------------------

UPDATE Users SET GroupId = 3 WHERE GroupId = 1 AND Id > 2 
UPDATE Users SET Password = 'Testing' WHERE Password LIKE '%aa%' 
GO

------------------------------ Task 21 -------------------------------

UPDATE Users SET GroupId = NULL WHERE GroupId = 4 -- remove constraints
DELETE FROM Groups WHERE Id = 4 
DELETE FROM Users WHERE Username = 'Gama' 
GO

------------------------------ Task 22 -------------------------------

INSERT INTO Users (Username, Password, FullName, LastLogin, GroupId)
SELECT
    SUBSTRING(FirstName, 1, 1) + LOWER(LastName) AS Username,
	SUBSTRING(FirstName, 1, 1) + LOWER(LastName) + 
	  ISNULL((SELECT 'pass' WHERE LEN(LastName) < 4),'') AS Password,
	FirstName + ' ' + LastName AS FullName,
	NULL AS LastLogin,
	1 AS GroupId
  FROM Employees

------------------------------ Task 23 -------------------------------

-- TODO: DISABLE CONSTRAINT
UPDATE Users
SET Password = NULL
WHERE CONVERT(date, LastLogin) < CONVERT(date, '10.03.2010')

------------------------------ Task 24 -------------------------------

DELETE FROM Users
WHERE Password IS NULL

------------------------------ Task 25 -------------------------------

SELECT e.JobTitle, d.Name AS Department, AVG(e.Salary) AS [Average Salary]
FROM Employees AS e
JOIN Departments AS d
  ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name
ORDER BY e.JobTitle

------------------------------ Task 26 -------------------------------

SELECT e.JobTitle, d.Name AS Department, MIN(e.Salary) AS [Average Salary],
  MIN(e.FirstName + ' ' + e.LastName) AS [Employee Name]
FROM Employees AS e
JOIN Departments AS d
  ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name
ORDER BY MIN(e.Salary)

------------------------------ Task 27 -------------------------------

SELECT TOP 1 t.Name AS Town, COUNT(t.TownID) AS[Number of Emmployees] FROM Employees AS e
JOIN Addresses AS a
  ON a.AddressID = e.AddressID
JOIN Towns AS t
  ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(t.TownID)DESC

------------------------------ Task 28 -------------------------------

SELECT mt.[Town Name], COUNT(mt.[Managers Count]) FROM 
(SELECT MIN(t.Name) AS [Town Name], COUNT(t.Name) AS [Managers Count] FROM Employees AS e
JOIN Employees AS m
  ON e.ManagerID = m.EmployeeID
JOIN Addresses AS a
  ON a.AddressID = m.AddressID
JOIN Towns AS t
  ON a.TownID = t.TownID
WHERE m.EmployeeID IS NOT NULL
GROUP BY m.EmployeeID) AS mt
GROUP BY mt.[Town Name]

------------------------------ Task 29 -------------------------------

CREATE TABLE WorkHours (
  WorkHourId int IDENTITY,
  EmployeeId int NOT NULL,
  WorkDate datetime NOT NULL,
  Task nvarchar(50) NOT NULL,
  WorkHours int NOT NULL CHECK (WorkHours > 0),
  Comments nvarchar(100),
  CONSTRAINT FK_EmployeeWorkHours FOREIGN KEY (EmployeeId)
  REFERENCES Employees(EmployeeId),
  CONSTRAINT PK_WorkHours PRIMARY KEY(WorkHourId),
)

CREATE TABLE WorkHoursLogs (
  LogId int IDENTITY,
  Command NVARCHAR(50) NOT NULL,
  OldRecord NVARCHAR(255),
  NewRecord NVARCHAR(255),
  CONSTRAINT PK_WorkHoursLogs PRIMARY KEY(LogId),
  CONSTRAINT CK_WorkHoursLogs CHECK (OldRecord IS NOT NULL OR NewRecord IS NOT NULL)
)
GO

CREATE TRIGGER tr_UpdateWorkHours ON WorkHours FOR UPDATE AS
BEGIN
	DECLARE 
		@NewRecord NVARCHAR(255), 
		@OldRecord NVARCHAR(255),
		@Command NVARCHAR(50)
 
	-- TODO: "inserted" and "deleted" could contain more than one record
	-- the below code must be wrapped in loop, using CURSOR and FETCH NEXT  
	SET @Command = 'UPDATE'
	SELECT @NewRecord = CONVERT(VARCHAR, inserted.EmployeeId) + ' ' + 
			CONVERT(CHAR(10), inserted.WorkDate, 120) + ' ' + 
			CONVERT(VARCHAR, inserted.Task) + ' ' + 
			CONVERT(VARCHAR, inserted.WorkHours) + ' ' + 
			inserted.Comments
	FROM inserted

	SELECT @OldRecord = CONVERT(VARCHAR, deleted.EmployeeId) + ' ' + 
			CONVERT(CHAR(10), deleted.WorkDate, 120) + ' ' + 
			CONVERT(VARCHAR, deleted.Task) + ' ' + 
			CONVERT(VARCHAR, deleted.WorkHours) + ' ' + 
			deleted.Comments
	FROM deleted
 
	INSERT INTO WorkHoursLogs(Command, OldRecord, NewRecord)
	VALUES (@Command, @OldRecord, @NewRecord)
END
GO

CREATE TRIGGER tr_InsertWorkHours ON WorkHours FOR INSERT AS
BEGIN
	DECLARE 
		@NewRecord NVARCHAR(255), 
		@OldRecord NVARCHAR(255),
		@Command NVARCHAR(50)
 
	-- TODO: "inserted" could contain more than one record
	-- the below code must be wrapped in loop, using CURSOR and FETCH NEXT  
	SET @Command = 'INSERT'
	SET @OldRecord = NULL
	SELECT @NewRecord = CONVERT(VARCHAR, inserted.EmployeeId) + ' ' + 
			CONVERT(CHAR(10), inserted.WorkDate, 120) + ' ' + 
			CONVERT(VARCHAR, inserted.Task) + ' ' + 
			CONVERT(VARCHAR, inserted.WorkHours) + ' ' + 
			inserted.Comments
	FROM inserted
 
	INSERT INTO WorkHoursLogs(Command, OldRecord, NewRecord)
	VALUES (@Command, @OldRecord, @NewRecord)
END
GO

CREATE TRIGGER tr_DeleteWorkHours ON WorkHours FOR DELETE AS
BEGIN
	DECLARE 
		@NewRecord NVARCHAR(255), 
		@OldRecord NVARCHAR(255),
		@Command NVARCHAR(50)
 
	-- TODO: "deleted" could contain more than one record
	-- the below code must be wrapped in loop, using CURSOR and FETCH NEXT  
	SET @Command = 'DELETE'
	SET @NewRecord = NULL
	SELECT @OldRecord = CONVERT(VARCHAR, deleted.EmployeeId) + ' ' + 
			CONVERT(CHAR(10), deleted.WorkDate, 120) + ' ' + 
			CONVERT(VARCHAR, deleted.Task) + ' ' + 
			CONVERT(VARCHAR, deleted.WorkHours) + ' ' + 
			deleted.Comments
	FROM deleted
 
	INSERT INTO WorkHoursLogs(Command, OldRecord, NewRecord)
	VALUES (@Command, @OldRecord, @NewRecord)
END
GO

INSERT WorkHours VALUES (9, '2013-07-14', 'Task 1', 3, '3 hours...')
INSERT WorkHours VALUES (10, '2013-07-13', 'Task 2', 4, '4 Hours...')
INSERT WorkHours VALUES (11, '2010-07-12', 'Task 3', 5, '5 Hours...')
INSERT WorkHours VALUES (12, '2010-07-11', 'Task 4', 15, '15 Hours...')
DELETE FROM WorkHours WHERE Task = 'Task 3'
UPDATE WorkHours
	SET Task = 'Task 15'
	WHERE Task = 'Task 4'
GO

------------------------------ Task 30 -------------------------------

-- set "on delete" constraints over dependent child tables
--   - remove all projects of the deleted employee
--   - remove departments of the deleted employee that is manager of  
BEGIN TRAN
--	ALTER TABLE Departments -- alternate update - allow NULLs for ManagerID column
--	ALTER COLUMN ManagerID int
	ALTER TABLE Departments
	ADD CONSTRAINT FK_Departments_Employees FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID)
  	ON DELETE CASCADE
-- 	ON DELETE SET NULL -- alternate update - leave department but without manager (NULL)
	
	ALTER TABLE EmployeesProjects
	ADD CONSTRAINT FK_Employees_Projects FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
	ON DELETE CASCADE

	DELETE FROM Employees
	WHERE DepartmentID =
	(SELECT DepartmentID FROM Departments
		WHERE Name = 'Sales')
		
	-- Finally it is not needed to delete above constraints since they are part of the rollback transaction
ROLLBACK TRAN

------------------------------ Task 31 -------------------------------

BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

------------------------------ Task 32 -------------------------------

BEGIN TRAN
	SELECT * INTO #TempTable 
	FROM EmployeesProjects;

	DROP TABLE EmployeesProjects;

	SELECT * INTO EmployeesProjects
	FROM #TempTable;

	DROP TABLE #TempTable
COMMIT TRAN

