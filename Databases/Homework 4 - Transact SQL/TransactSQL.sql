------------------------------ Task  1 -------------------------------

CREATE TABLE Persons (
	PersonId int IDENTITY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN nvarchar(50) NOT NULL,
	CONSTRAINT PK_PersonId PRIMARY KEY(PersonId),
	CONSTRAINT PK_Persons PRIMARY KEY(PersonId)
)

CREATE TABLE Accounts (
	AccountId int IDENTITY,
	Balance money NOT NULL,
	PersonId int NOT NULL,
	CONSTRAINT PK_Accounts PRIMARY KEY(AccoundId),
	CONSTRAINT FK_PersonAccounts FOREIGN KEY (PersonId)
	REFERENCES Persons(PersonId),
)
GO

INSERT Persons VALUES ('Svetlin', 'Nakov', '137984312974')
INSERT Persons VALUES ('Nikolay', 'Kostov', '123124343243')
INSERT Persons VALUES ('George', 'Georgiev', '123456789123')
INSERT Persons VALUES ('Doncho', 'Minkov', '789645132247')

INSERT Accounts VALUES (124000, 1);
INSERT Accounts VALUES (1000, 1);
INSERT Accounts VALUES (80000, 2);
INSERT Accounts VALUES (500, 2);
INSERT Accounts VALUES (5000, 3);
INSERT Accounts VALUES (2500, 4);
GO

CREATE PROC usp_GetFullName
AS
  SELECT FirstName + ' ' + LastName
   FROM Persons
GO

EXEC usp_GetFullName

------------------------------ Task  2 -------------------------------

CREATE PROC usp_SelectPersonsByAccountBalance( @minBalance money )
AS
  SELECT FirstName + ' ' + LastName AS [Full Name], a.Balance AS  Balance
  FROM Persons as p
	JOIN Accounts as a
	ON p.PersonId = a.PersonId
  WHERE a.Balance >
    @minBalance
  ORDER BY a.Balance
GO

EXEC usp_SelectPersonsByAccountBalance 1000

------------------------------ Task  3 -------------------------------

CREATE FUNCTION ufn_AddInterest( @sum money, @interestRate money, @months int )
RETURNS money AS
BEGIN
  RETURN (@sum * (1.0 + (@interestRate / 100) * (@months / 12)))
END
GO

SELECT dbo.ufn_AddInterest(1000, 6.5, 8)

------------------------------ Task  4 -------------------------------

CREATE PROC usp_CalculateMonthlyInterest ( @accountId int, @interest money ) AS
BEGIN
	UPDATE dbo.Accounts
		SET Balance = dbo.ufn_AddInterest(Balance, @interest, 1)
		WHERE AccountID = @accountId
END		
GO

EXEC dbo.usp_CalculateMonthlyInterest 3, 6.5

------------------------------ Task  5 -------------------------------

CREATE PROC usp_WithdrawMoney ( @accountId int, @sum money ) AS
BEGIN
	DECLARE @balance money
	BEGIN TRAN
	SELECT @balance = Balance FROM dbo.Accounts
		WHERE AccountId = @accountId
	IF (@sum > 0 AND @balance - @sum >= 0)
	BEGIN
		UPDATE dbo.Accounts
		SET Balance = @balance - @sum
		WHERE AccountID = @accountId
		COMMIT TRAN
	END
	ELSE
		ROLLBACK TRAN
END		
GO

CREATE PROC usp_DepositMoney ( @accountId int, @sum money ) AS
BEGIN
	DECLARE @balance money
	BEGIN TRAN
	SELECT @balance = Balance FROM dbo.Accounts
		WHERE AccountId = @accountId
	IF (@sum > 0)
	BEGIN
		UPDATE dbo.Accounts
		SET Balance = @balance + @sum
		WHERE AccountID = @accountId
		COMMIT TRAN
	END
	ELSE
		ROLLBACK TRAN
END		
GO

EXEC dbo.usp_WithdrawMoney 3, 100000
EXEC dbo.usp_WithdrawMoney 3, 10000
EXEC dbo.usp_DepositMoney 3, 100000

------------------------------ Task  6 -------------------------------

CREATE TABLE BalanceLogs (
  LogId int IDENTITY,
  AccountId int NOT NULL,
  OldBalance money NOT NULL,
  NewBalance money NOT NULL,
  CONSTRAINT PK_BalanceLogs PRIMARY KEY(LogId),
  CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountId) REFERENCES Accounts(AccountId)
)
GO

CREATE TRIGGER tr_UpdateBalance ON Accounts FOR UPDATE AS
BEGIN
	DECLARE 
		@NewBalance money, 
		@OldBalance money,
		@Account int
 
	-- TODO: "inserted" and "deleted" could contain more than one record
	-- the below code must be wrapped in loop, using CURSOR and FETCH NEXT  
	SELECT @NewBalance = Balance, 
			@Account = AccountId 
	FROM inserted

	SELECT @OldBalance = Balance
	FROM deleted
 
	INSERT INTO BalanceLogs(AccountId, OldBalance, NewBalance)
	VALUES (@Account, @OldBalance, @NewBalance)
END
GO

EXEC dbo.usp_WithdrawMoney 3, 100000
EXEC dbo.usp_WithdrawMoney 3, 10000
EXEC dbo.usp_DepositMoney 3, 100000

------------------------------ Task  7 -------------------------------

USE TelerikAcademy
GO
CREATE FUNCTION ufn_CheckString( @testString nvarchar(50), @letterset nvarchar(50) )
RETURNS int AS
BEGIN
	DECLARE
		@check int,
		@index int
	SET @index = LEN(@testString)
	
	IF (@testString IS NULL OR @index < 2)
		RETURN 0
	
	WHILE (@index > 0)
	BEGIN
		SET @check = CHARINDEX(SUBSTRING(@testString, @index, 1), @letterset)
		IF (@check IS NULL OR @check = 0)
			RETURN 0
		SET @index = @index - 1
	END
	RETURN 1
END
GO

CREATE FUNCTION ufn_GetNamesEmployeesTowns( @letterset nvarchar(50) )
RETURNS TABLE AS
	RETURN (
		SELECT FirstName FROM Employees
			WHERE dbo.ufn_CheckString(FirstName, @letterset) > 0
		UNION
		SELECT MiddleName FROM Employees
			WHERE dbo.ufn_CheckString(MiddleName, @letterset) > 0
		UNION
		SELECT LastName FROM Employees
			WHERE dbo.ufn_CheckString(LastName, @letterset) > 0
		UNION
		SELECT Name FROM Towns
			WHERE dbo.ufn_CheckString(Name, @letterset) > 0
)
GO

SELECT * FROM dbo.ufn_GetNamesEmployeesTowns ('oistmiahf')

------------------------------ Task  8 -------------------------------

CREATE PROC usp_PrintEmployeePairsPerTown AS
BEGIN
	DECLARE
		@employee1 nvarchar(50),
		@employee2 nvarchar(50),
		@town nvarchar(50)

	PRINT '-------- Employee Pairs per Town --------'
	
	DECLARE emp_cursor CURSOR FOR 
		SELECT
			e1.FirstName + ' ' + e1.LastName AS [First Employee],
			e2.FirstName + ' ' + e2.LastName AS [Second Employee],
			t.Name AS [Town]
		FROM Employees AS e1
		JOIN Addresses AS a1
			ON e1.AddressID = a1.AddressID
		JOIN Towns AS t
			ON a1.TownID = t.TownID,
		Employees AS e2
		JOIN Addresses AS a2
			ON e2.AddressID = a2.AddressID
		WHERE a1.TownID = a2.TownID AND e1.EmployeeID > e2.EmployeeID
		
    OPEN emp_cursor
    FETCH NEXT FROM emp_cursor INTO @employee1, @employee2, @town

    IF @@FETCH_STATUS <> 0 
        PRINT '<<None>>'     

    WHILE @@FETCH_STATUS = 0
    BEGIN
        PRINT @employee1 + SPACE(40 - LEN(@employee1)) + '- ' + @employee2 + SPACE(40 - LEN(@employee2)) + '- ' + @town
        FETCH NEXT FROM emp_cursor INTO  @employee1, @employee2, @town
    END

    CLOSE emp_cursor
    DEALLOCATE emp_cursor
END
GO

EXEC usp_PrintEmployeePairsPerTown

------------------------------ Task 10 -------------------------------

USE TelerikAcademy
GO

CREATE PROC usp_AggregateQuery (@query nvarchar(100), @tbl nvarchar(100)) AS
BEGIN
	DECLARE @name nvarchar(MAX)
	DECLARE @names nvarchar(MAX)
	DECLARE @cmd AS NVARCHAR(max)
	DECLARE @ParmDefinition AS NVARCHAR(max)
	SET @cmd = 'DECLARE @tmp nvarchar(max) SET @tmp='''' SELECT @tmp+= ' + @query + ' + '', '' FROM ' + @tbl + ' SET @name_out = @tmp'
	SET @ParmDefinition = '@name_out varchar(MAX) OUTPUT'

	EXECUTE sp_executesql @cmd, @ParmDefinition, @name_out=@name OUTPUT
	PRINT '-------------------'
	PRINT @name
END
GO

EXEC dbo.usp_AggregateQuery 'FirstName + '' '' + LastName','Employees'
