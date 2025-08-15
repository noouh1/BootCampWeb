select * from HR.Employee
select * from HR.Project
select * from Works_on
select * from Department
select * from Company.Department

create view v_clerk
as
select count(e.EmpNo) as emp#,count(p.ProjectNo) as project#,w.Enter_Date
from HR.Employee e join
Works_on w on e.EmpNo = w.EmpNo
join HR.Project p on w.ProjectNo = p.ProjectNo
where w.Job = 'Clerk'
group by w.Enter_Date

select * from v_clerk
----------------------------------
create view v_without_budget
as
select * from HR.Project
where Budget is null

select * from v_without_budget

--------------------------------------
create view v_count 
as
select p.ProjectName,count(w.Job) as jobnumber from hr.Project p
join Works_on w on p.ProjectNo = w.ProjectNo
group by p.ProjectName

select * from v_count
--------------------------------------
create view v_project_p2
as
select emp# from v_clerk
where project# = '2'

select * from v_project_p2
-----------------------------------
drop view v_clerk,v_count;
-----------------------------------
create view v_display
as
select count(e.EmpNo) as empnumber,e.EmpLname from hr.Employee e
join Company.Department d on e.DeptNo = d.DeptNo
where d.DeptNo = 2
group by e.EmpLname

select * from v_display
------------------------------------------------
select EmpLname from v_display
where EmpLname like '%j%'
------------------------------------------------
create view v_dept
as
select d.DeptNo as depnumber,d.DeptName from Company.Department d

select * from v_dept
-----------------------------------------
insert into v_dept values(4,'development')
------------------------------------------
create view v_2006
as
select w.EmpNo,p.ProjectNo from Works_on w
join hr.Project p on w.ProjectNo = p.ProjectNo
WHERE Enter_Date >= '2006-01-01'
  AND Enter_Date <= '2006-12-31'
with check option;

select * from v_2006