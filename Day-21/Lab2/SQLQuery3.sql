USE Company_SD;

-- Select all columns from the Employee
SELECT * FROM Employee;

-- Select first name, last name, salary, and department number from Employee
SELECT fname, lname, salary, dno FROM Employee;

-- Select project name, location, and department number from Project
SELECT * FROM Project;
SELECT pname, plocation, dnum FROM Project;

-- Get full name and 10% of salary as "annual commission" for each employee
SELECT fname + lname AS fullname, salary * 0.1 AS ANNUALCOMM FROM Employee;

-- Get SSN and full name of employees with salary greater than 1000
SELECT SSN, fname + lname AS fullname FROM Employee 
WHERE Salary > 1000;

-- Get SSN, full name, and annual salary for employees earning more than 10,000 annually
SELECT SSN, fname + lname AS fullname, Salary * 12 AS AnnualSalary FROM Employee 
WHERE Salary * 12 > 10000;

-- Get full name and salary of female employees
SELECT fname + lname AS fullname, Salary FROM Employee
WHERE Sex = 'F';

-- Get department number and full name of employees whose supervisor's SSN is 968574
SELECT dno, fname + lname AS fullname FROM Employee
WHERE Superssn = 968574;

-- Get ID, name, and location of projects that belong to department number 10
SELECT pnumber AS id, pname, plocation FROM Project
WHERE Dnum = 10;
