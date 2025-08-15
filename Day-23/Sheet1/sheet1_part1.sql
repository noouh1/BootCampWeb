select * from Topic
select * from Department
select * from Instructor
select * from Ins_Course
select * from Course
------------------------------------------------
CREATE VIEW vw_CourseName
AS
select St_Fname + ' ' + St_Lname as FullName,Crs_Name from Student s
join Stud_Course sc on s.St_Id = sc.St_Id
join Course c on sc.Crs_Id = c.Crs_Id
where sc.Grade > 50

select * from vw_CourseName

---------------------------------------------------------
create view vw_InsNameForTopic
WITH ENCRYPTION
AS
select Ins_Name,Top_Name from Instructor i
join Ins_Course ic on i.Ins_Id = ic.Ins_Id
join Course c on ic.Crs_Id= c.Crs_Id
join Topic t on c.Top_Id=t.Top_Id

select * from vw_InsNameForTopic
SP_HELPTEXT vw_InsNameForTopic
-----------------------------------------------

create view vw_InsNameForDepartment
AS
select Ins_Name,Dept_Name from Instructor i
join Department d on i.Dept_Id = d.Dept_Id
where Dept_Name = 'SD' or Dept_Name = 'Java'

select * from vw_InsNameForDepartment
-------------------------------------------------------

create view vw_DisplayData
AS
select * from Student
where St_Address = 'Alex' or St_Address = 'Cairo'


CREATE TRIGGER trg_PreventAlexUpdate
on vw_DisplayData
instead of update
as
begin
   print 'cahnges are not allowed!';  
end

select * from vw_DisplayData
UPDATE vw_DisplayData
SET st_address = 'Alex'
WHERE st_address = 'tanta';
---------------------------------------------
create view vw_EmployeeNum
AS
select p.Pname,COUNT(e.SSN) as number from Project p
join Works_for w on p.Pnumber = w.Pno
join Employee e on w.ESSn = e.SSN
group by p.Pname
----------------------------------------
create nonclustered index IX_Department
on Department (Manager_hiredate)
---------------------------
create nonclustered index IX_Student_Age
on Student (St_Age);
--------------------------------------------------
create table d_transaction
(
userid int unique,
transaction_amount int
)

create table l_transaction
(
userid int unique,
transaction_amount int
)
insert into d_transaction values(1,1000),(2,2000),(3,1000)
insert into l_transaction values(1,4000),(4,2000),(2,10000)

Merge into d_transaction as t 
using l_transaction as s
On t.userid = s.userid
When matched then
update set t.transaction_amount = s.transaction_amount 
When not matched by target Then 
insert (userid,transaction_amount)
values(s.userid,s.transaction_amount)
When not matched by Source
Then delete;
select * from d_transaction

---------------------------------------
