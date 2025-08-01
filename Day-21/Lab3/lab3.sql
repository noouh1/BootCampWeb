use Company_SD

select * from Employee

select* from Departments

select * from Project

select * from Works_for

-- Get department ID, name, and manager ID
select dnum as DepartmentID , dname as DepartmentName, mgrssn as MGRID from Departments
join Employee on MGRSSN=SSN

-- Get each department's name and its related project name
select d.dname,p.pname from Departments d join Project p on d.Dnum = p.Dnum 

-- Get dependent data along with the first name of the employee they depend on
select d.*, e.fname from Dependent d join Employee e on d.ESSN = e.SSN

-- Get projects located in Cairo or Alex
select pnumber,pname,plocation from Project
where project.City = 'Cairo' or project.City = 'Alex'

-- Get projects with names starting with 'a'
select * from Project
where pname like 'a%'

-- Get employees in department 30 with salary between 1000 and 2000
select * from Employee
join Departments on Dno=30 and Salary between 1000 and 2000

-- Get employees in department 10 working on 'AL Rabwah' project and worked 10+ hours
select fname + lname as fullname,dno,pname,Hours from Employee e join Project p on e.Dno = p.Dnum
join Works_for w on w.ESSn = e.SSN
where e.Dno = 10 and p.Pname = 'AL Rabwah' and w.Hours >= 10

-- Get employees whose manager is 'Kamel Mohamed'
select e1.*, e2.fname + e2.lname as manger from Employee e1 join Employee e2 on e1.Superssn = e2.SSN
where e2.fname+' '+e2.Lname ='Kamel Mohamed'

-- Get employee full name and project name, sorted by project name
select fname+lname as fullname, pname from Employee e join Project p on p.Dnum = e.Dno join Works_for w on w.Pno = p.Pnumber
order by Pname

-- Get project number, department name, manager last name, address, and birthdate for projects in Cairo
select p.Pnumber,d.Dname, e.lname ,e.Address,e.Bdate from Project p join Departments d on p.Dnum = d.Dnum 
join Employee e on d.MGRSSN = e.SSN
where p.City = 'Cairo'

-- Get all employees who are department managers
select e.* from Employee e join Departments d on d.MGRSSN=e.SSN

-- Get all employees who have dependents
select e.* from Employee e join Dependent d on e.SSN = d.ESSN

-- Insert a new employee with full details
insert into Employee values('Noouh', 'Ehab', '102672', '2004-05-17', 'Fayoum', 'M', 3000, '112233', 30)

-- View all employee records
select * from Employee

-- Insert a new employee with selected columns only
insert into Employee (Fname,Lname,SSN,Bdate,Address,Sex,Dno)
values('omar', 'sayed', '102660', '2004-05-17', 'Fayoum', 'M',30)

-- Update salary by increasing it by 20% for a specific employee
update Employee
set Salary *= 1.2
where SSN = 102672
