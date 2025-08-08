use Company_SD; 

select * from Dependent
select * from Employee
select * from Departments
select * from Project
select * from Works_for

-- Female dependents + female dependents of female employees
select d.Sex,Dependent_name from Dependent d where Sex = 'F'
UNION
select d.Sex,Dependent_name from Dependent d join Employee e on d.ESSN = e.SSN where e.Sex = 'F'and d.Sex = 'F'

-- Male dependents + male dependents of male employees
select d.Sex,Dependent_name from Dependent d where d.Sex = 'M'
UNION
select d.Sex,Dependent_name from Dependent d join Employee e on d.ESSN = e.SSN where e.Sex = 'M' and d.Sex = 'M'

-- Total hours per project
select p.pname,sum(w.hours) as [hours per week] from Project p join Works_for w on p.Pnumber = w.Pno 
GROUP BY p.Pname;

-- Department with smallest employee SSN
select * from Departments d join Employee on Dnum = Dno
where SSN = (
	select MIN(SSN) from Employee 
);

-- Max, min, avg salary per department
select dname,MAX(salary) as maximum,MIN(salary) as minimum,AVG(salary) as average from Departments d 
join Employee on d.Dnum = Dno
GROUP BY d.Dname

-- Managers with no dependents
select e.lname from Employee e join Departments d on e.SSN = d.MGRSSN
left join Dependent on e.SSN = ESSN
where ESSN IS NULL

-- Departments with avg salary < company avg salary
select dname,dnum,COUNT(e.SSN) as employees from Departments d join Employee e on Dnum = Dno
group by d.Dname,d.Dnum
having AVG(e.Salary) < (
	select AVG(salary) from Employee
)

-- Employees with projects, ordered by department and name
select e.fname,e.lname,d.dname,p.pname from Employee e join Departments d on Dno = d.Dnum
join Works_for w on e.SSN = w.ESSn
join Project p on w.Pno = p.Pnumber
order by d.Dname,e.Lname,e.Fname

-- Top 2 salaries using subquery
select E.Fname, E.Lname, E.Salary from Employee E
where Salary IN (
	select MAX(Salary) from Employee
	union
	select MAX(Salary) from Employee
	where Salary < (select MAX(Salary) from Employee)
)
order by salary desc

-- Employees whose first name matches any dependent name
select fname + ' ' + lname as fullname from Employee
where fname in (
	select d.Dependent_name from Dependent d
)

-- Increase salary by 30% for employees working in 'Al Rabwah'
update employee
set Salary += Salary * 0.3 from Employee e
join Works_for w on e.SSN = w.ESSn
join Project p on w.Pno = p.Pnumber
where p.Pname = 'Al Rabwah'

-- Employees who have at least one dependent
select e.SSN, e.Fname, e.Lname
from Employee e
where exists (
    select *
    from Dependent d
    where d.ESSN = e.SSN
)

-- Insert new department with manager
insert into Departments values('DEPT IT',100,'112233','1-11-2006')

-- Change manager of department 100 and 20, update supervision
update Departments
set MGRSSN = 968574 where Dnum = 100
update Departments
set MGRSSN = 102672 where Dnum = 20
update Employee
set Superssn = 102672 where SSN = 102660

-- Replace Mr. Kamel Mohamed's roles with your SSN and delete him
update Departments
set MGRSSN = 102672 where MGRSSN = 223344
update Employee
set Superssn = 102672 where Superssn = 223344
update Works_for
set ESSn = 102672 where ESSn = 223344
update Dependent
set ESSN = 102672 where ESSN = 223344
delete from Employee where SSN = 223344
