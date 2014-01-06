--------------------- TASK 1 ---------------------

CREATE DATABASE CheckPerformance
GO

USE CheckPerformance

CREATE TABLE Logs(
  LogId int NOT NULL IDENTITY,
  Message NVARCHAR(50),
  MsgDate DATETIME,
  CONSTRAINT PK_Logs_LogId PRIMARY KEY(LogId)
  )
GO

CREATE PROC usp_FillLogs AS
DECLARE @Counter int = 0
SET NOCOUNT ON
WHILE @Counter < 1000000
BEGIN
	INSERT INTO Logs(Message, MsgDate)
	VALUES('Message ' + CONVERT(varchar, @Counter), GETDATE())
	IF (@Counter % 10000 = 0) PRINT '.'
	IF (@Counter % 100000 = 0) PRINT @Counter
	SET @Counter = @Counter + 1
END
GO

EXEC dbo.usp_FillLogs

DECLARE @StartDate datetime = GETDATE()
SELECT * FROM Logs
WHERE MsgDate >= '2013-07-21 13:00:08.140' AND MsgDate <= '2013-07-21 13:10:08.140'
PRINT DATEDIFF(millisecond, @StartDate, GETDATE())
GO
-- query execution time - 31 706 ms


--------------------- TASK 2 ---------------------

CHECKPOINT;
DBCC DROPCLEANBUFFERS;
GO

CREATE INDEX IDX_Logs_Date ON Logs(MsgDate)
GO

DECLARE @StartDate datetime = GETDATE()
SELECT MsgDate FROM Logs
WHERE MsgDate >= '2013-07-21 13:00:08.140' AND MsgDate <= '2013-07-21 13:10:08.140'
PRINT DATEDIFF(millisecond, @StartDate, GETDATE())
GO
-- query execution time - 26 250 ms


--------------------- TASK 3 ---------------------

CHECKPOINT;
DBCC DROPCLEANBUFFERS;
GO

DECLARE @StartDate datetime = GETDATE()
SELECT Message FROM Logs
WHERE Message > 'Message 1' AND Message < 'Message 3'
PRINT DATEDIFF(millisecond, @StartDate, GETDATE())
GO
-- query execution time - 28 963 ms

CREATE FULLTEXT CATALOG LogsCatalog
WITH ACCENT_SENSITIVITY = OFF

-- SELECT SERVERPROPERTY('IsFullTextInstalled')
-- 0 = Cannot use full-text services on my SQL Server 2008 R2
-- Follows only the idea how to do this fulltext index
CREATE FULLTEXT INDEX ON Logs(Message)
KEY INDEX PK_Logs_LogId
ON LogsCatalog
GO

DECLARE @StartDate datetime = GETDATE()
SELECT Message FROM Logs
WHERE Message > 'Message 1' AND Message < 'Message 3'
PRINT DATEDIFF(millisecond, @StartDate, GETDATE())
GO
-- query execution time - in any case less than 28 963 ms
