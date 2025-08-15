select * from Department
create function dbo.get_month
(
@date date
)
returns nvarchar(20)
as
begin
    return datename(month, @date)
end;
select dbo.get_month('2025-08-15') as month_name
--------------------------------------------
create function dbo.get_number
(
	@from int,
	@to int
)
returns @nums table (value int)
as
begin
	 while @from <= @to
    begin
        insert into @nums
        values (@from)

        set @from += 1
    end
	return
end
select * from get_number(5,10)
--------------------------------------
create function dbo.get_department
(
	@studentID int
)
returns table
as
return
(
	select s.St_Id , s.St_Fname + ' ' + s.St_Lname as fullname , d.Dept_Name from Student s
	join Department d on s.Dept_Id = d.Dept_Id
	where s.St_Id = @studentID
)
select * 
from dbo.get_department(1);
--------------------------------------------
create function dbo.check_name
(
	@studentID int
)
returns nvarchar(100)
as
begin
	 declare @fname nvarchar(50)
     declare @lname nvarchar(50)

	 select @fname = s.St_Fname, @lname = s.St_Lname from Student s
	 where s.St_Id = @studentID

	 if @fname is null and @lname is null
        return 'first name & last name are null'
    else if @fname is null
        return 'first name is null'
    else if @lname is null
        return 'last name is null'
    else
        return 'first name & last name are not null'

	return null
end
select dbo.check_name(1)
-----------------------------------------------
create function dbo.get_manager_data
(
	@managerID int
)
returns table
as
return
(
	   select 
        d.dept_name,
        i.Ins_Name as manager_name,
        d.Manager_hiredate
    from department d
    join Instructor i 
        on d.Dept_Id = i.Dept_Id
    where i.Ins_Id = @managerID
)
select * 
from dbo.get_manager_data(1);
--------------------------------------
create function dbo.get_name
(
	@name nvarchar(50)
)
returns @result table (name nvarchar(101))
as
begin
	 if @name = 'First name'
		insert into @result
		select isnull(s.St_Fname, 'no first name') from Student s
	else if @name = 'Last name'
		insert into @result
		select isnull(s.St_Lname, 'no last name') from Student s
	else if @name = 'Full name'
		insert into @result
		select isnull(s.St_Fname, 'no first name') + ' ' + isnull(s.St_Lname, 'no last name') from Student s
	return
end
select * from dbo.get_name('first name');
select * from dbo.get_name('last name');
select * from dbo.get_name('full name');
-------------------------------------------
select 
    s.St_Id,
    left(s.St_Fname, len(s.St_Fname) - 1) as firstname
from Student s;
-----------------------------------
update sc
set grade = null
from Stud_Course sc join Student s on sc.St_Id =s.St_Id 
join Department d on s.Dept_Id =d.Dept_Id
where d.Dept_name ='SD'