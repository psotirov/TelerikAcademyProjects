CREATE DATABASE CheckPerformance;
USE CheckPerformance;

CREATE TABLE Logs(
	LogId int NOT NULL AUTO_INCREMENT,
	Message NVARCHAR(50),
	MsgDate DATETIME,
	CONSTRAINT PK_Logs_LogId PRIMARY KEY(LogId, MsgDate)
) PARTITION BY RANGE(YEAR(MsgDate))(
	PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
	PARTITION p2 VALUES LESS THAN (2010),
	PARTITION p3 VALUES LESS THAN MAXVALUE
);

DELIMITER // -- changes default command line delimiter in order to send the procedure as single command to the server
CREATE PROCEDURE sp_FillLogs()
BEGIN
	DECLARE counter INT DEFAULT 0;
	WHILE counter < 1000000 DO
		INSERT INTO Logs(Message, MsgDate)
		VALUES(CONCAT('Message ', CAST(counter as CHAR)),
			TIMESTAMPADD(DAY, FLOOR(1 + RAND() * 8500), '1990-01-01')); -- (2014 - 1990) * 52 * 7 = 8736 days
		SET counter = counter + 1;
	END WHILE;
END//
DELIMITER ;

CALL sp_FillLogs();

SELECT * FROM Logs PARTITION(p2);

SELECT * FROM Logs WHERE YEAR(MsgDate) = 2013;