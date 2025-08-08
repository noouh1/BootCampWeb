use ITI;

select * from Student
select * from Course
select * from Stud_Course
select * from Instructor
select * from Department
select * from Topic

-- count number of students where age is not null
select count(St_Id) as numberofstudents from Student where St_Age is not null

-- display distinct instructor names
select distinct Ins_name from Instructor

-- display student id, full name, and department name
select st_id as [Student ID],st_fname + ' '+ st_lname as [Student Fullname],dept_name as [Department Name] 
from Student s 
join Department d on s.Dept_Id = d.Dept_Id

-- display instructor id and department name
select ins_id,dept_name from Instructor i 
join Department d on i.Dept_Id = d.Dept_Id

-- display student full name and course name where grade is not null
select st_fname + ' '+ st_lname as [Student Fullname],crs_name as [course name] 
from Student s 
join Stud_Course sc on s.St_Id = sc.St_Id
join Course c on sc.Crs_Id = c.Crs_Id
where sc.Grade is not null

-- display topic name and count of courses per topic
select t.top_name, count(c.Crs_Id) as courseID 
from Topic t
join Course c on t.Top_Id = c.Top_Id
group by t.Top_Name

-- display max and min salary from instructor table
select MAX(salary) as maxsalary,MIN(salary) as minsalary from Instructor

-- display instructors with salary less than the average salary
select * from Instructor where Salary < (
	select AVG(Salary) from Instructor
)

-- display department name and instructor name with the minimum salary
select dept_name,ins_name 
from Department d 
join Instructor i on d.Dept_Id = i.Dept_Id
where salary = (select MIN(salary) from Instructor)

-- display top 2 salaries in descending order
select top(2) salary from Instructor
order by Salary desc

-- display instructor name and salary, if salary is null show degree instead
select ins_name , coalesce(salary,ins_degree) as final from Instructor

-- display average salary of all instructors
select avg(salary) as average from Instructor

-- display first name of students who are supervisors
select s.st_fname 
from Student s,Student sup
where sup.St_super = s.St_Id

-- display top 2 highest salaries with their dept id and instructor name using ranking
select salary, Dept_ID, Ins_Name 
from (
	select salary, Dept_ID,Ins_Name, dense_rank() over(order by salary desc) as rankingsalary
	from Instructor
)as rankedsalaries
where rankingsalary <= 2
