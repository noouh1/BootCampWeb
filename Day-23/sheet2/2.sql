use ITI
use Company_SD
select * from Employee
select * from Project
select * from Works_for
create procedure usp_StudentNum
as
begin
	select count(s.St_Id)as numstudents,d.dept_name from Student s
	join Department d on s.Dept_Id = d.Dept_Id
	group by d.Dept_Name
end;
exec usp_StudentNum
----------------------------------
create procedure usp_CheckEmployee
as
begin
	declare @EmpCount INT;
	select @EmpCount = count(*) from Employee e
	join Project p on e.Dno = p.Dnum
	where p.Pname = 'AL Solimaniah'
	if @EmpCount >3
	begin
		PRINT 'The number of employees in the project p1 is 3 or more';
	end
	else
	begin
		 PRINT 'The following employees work for the project p1';
		 select e.Fname,e.Lname from Employee e
		join Project p on e.Dno = p.Dnum
		where p.Pname = 'AL Solimaniah' 
	end
	
end;
exec usp_CheckEmployee

------------------------------------------------
create procedure usp_UpdateTable
	@old INT,
	@new INT,
	@projectno INT
as
begin
	update Works_for
	set ESSn = @new
	where ESSn = @old
	and Pno = @projectno
end;
-------------------------------------------
alter table Project 
add budget money
update Project 
set budget = 3000;

create table AuditTable
(
	ProjectNo int,
	UserName nvarchar(100),
	ModifitedTime Datetime,
	Budget_Old money,
	Budget_New money

);
create trigger trg_Auditproject
on Project
after update
as
begin
	if update(budget)
    begin
        insert into AuditTable(ProjectNo, UserName, ModifitedTime, Budget_Old, Budget_New)
        select
            d.Pnumber,
            system_user,
            getdate(),
            d.budget as budget_old,
            i.budget as budget_new
        from deleted d
        join inserted i on d.Pnumber = i.Pnumber;
    end
end;

select * from AuditTable
------------------------------------------------------
create trigger trg_PreventInsert
on department
instead of insert
as
begin
	 print 'you can’t insert a new record in the department table';
end
insert into Department(Dept_Id, Dept_Name)
values (1,'test');
-------------------------------------------
create trigger trg_PreventInsert
on Employee
instead of insert
as
begin
    if exists (
        select 1
        from inserted
        where month(bdate) = 3
    )
    begin
        rollback transaction;
        print 'you can’t insert a new employee with birth month in march';
    end
end

------------------------------------
create table student_audit
(
    server_user_name nvarchar(100),
    audit_date datetime,
    note nvarchar(500)
);
create trigger trg_studentInsert
on student
after insert
as
begin
    insert into student_audit(server_user_name, audit_date, note)
    select
        system_user,
        getdate(),
        system_user + ' insert new row with key=' + cast(i.St_Id as nvarchar(50)) + ' in table student'
    from inserted i;
end;
insert into student (St_Id, St_Fname, St_Lname, St_Age)
values (101, 'ahmed', 'ali', 21);
select * from student_audit
-----------------------------------------------
create trigger trg_studentDelete
on student
instead of delete
as
begin
    insert into student_audit (server_user_name, audit_date, note)
    select
        system_user,
        getdate(),
        'try to delete row with key=' + cast(d.St_Id as nvarchar(50))
    from deleted d;
end;
delete from student where St_Id = 1;
select * from student_audit;
------------------------------------------

