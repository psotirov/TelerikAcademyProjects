--Databases Homework 2 - SQL Intro
--================================

-- TASKS 1-3 - NO QUERIES 

-- TASK 4
--------------------------------
SELECT d.Name, e.FirstName + ' ' + e.LastName AS [Manager Name]
FROM
 Departments AS d
 JOIN Employees AS e
    ON d.ManagerID = e.EmployeeID

-- TASK 5
--------------------------------
SELECT Name FROM Departments

-- TASK 6
--------------------------------
SELECT FirstName + ' ' + LastName AS [Employee Name], Salary
FROM Employees

-- TASK 7
--------------------------------
SELECT FirstName + ISNULL(' ' + MiddleName, '') + ' ' + LastName AS [Employee Full Name]
FROM Employees

-- TASK 8
--------------------------------
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Employee E-Mail]
FROM Employees

-- TASK 9
--------------------------------
SELECT DISTINCT Salary FROM Employees

-- TASK 10
--------------------------------
SELECT *
FROM Employees
WHERE JobTitle = 'Sales Representative'

-- TASK 11
--------------------------------
SELECT FirstName + ' ' + LastName AS [Employee Name]
FROM Employees
WHERE FirstName LIKE 'SA%'

-- TASK 12
--------------------------------
SELECT FirstName + ' ' + LastName AS [Employee Name]
FROM Employees
WHERE LastName LIKE '%ei%'

-- TASK 13
--------------------------------
SELECT FirstName + ' ' + LastName AS [Employee Name], Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
ORDER BY Salary

-- TASK 14
--------------------------------
SELECT FirstName + ' ' + LastName AS [Employee Name], Salary
FROM Employees
WHERE Salary IN (12500, 14000, 23600, 25000)
ORDER BY Salary

-- TASK 15
--------------------------------
SELECT FirstName + ' ' + LastName AS [Employee Name]
FROM Employees
WHERE ManagerId IS NULL

-- TASK 16
--------------------------------
SELECT FirstName + ' ' + LastName AS [Employee Name], Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

-- TASK 17
--------------------------------
SELECT TOP 5 FirstName + ' ' + LastName AS [Employee Name], Salary
FROM Employees
ORDER BY Salary DESC

-- TASK 18
--------------------------------
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], a.AddressText
FROM
 Employees AS e
 JOIN Addresses AS a
    ON e.AddressID = a.AddressID

-- TASK 19
--------------------------------	
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], a.AddressText
FROM Employees AS e, Addresses AS a
WHERE e.AddressID = a.AddressID	

-- TASK 20
--------------------------------
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
  m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM
 Employees AS e
 JOIN Employees AS m
    ON e.ManagerID = m.EmployeeID

-- TASK 21
--------------------------------	
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
  a.AddressText AS [Employee Address],
  m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM
 Employees AS e
 JOIN Employees AS m
    ON e.ManagerID = m.EmployeeID
 JOIN Addresses AS a
    ON e.AddressID = a.AddressID

-- TASK 22
--------------------------------	
SELECT Name FROM Departments
UNION
SELECT Name FROM Towns

-- TASK 23
--------------------------------
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
  m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM
 Employees AS e
 RIGHT JOIN Employees AS m
    ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
  m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM
 Employees AS m
 LEFT JOIN Employees AS e
    ON e.ManagerID = m.EmployeeID

-- TASK 24
--------------------------------
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],YEAR(e.HireDate) 
FROM 
  Employees AS e
  JOIN Departments AS d
    ON d.DepartmentID = e.DepartmentID
WHERE d.Name IN ('Sales','Finance') AND (YEAR(e.HireDate) BETWEEN 2000 AND 2005) 
-- WHERE d.Name IN ('Sales','Finance') AND (YEAR(e.HireDate) BETWEEN 1995 AND 2000) 
