Create database EmployeePayroll_ADO_MVC
USE EmployeePayroll_ADO_MVC

-----------------------------------------------Tables------------------------------------------------
Create Table Employee(
EmployeeId int identity(1,1) primary key,
Name varchar(100),
ProfileImage varchar(max),
Gender varchar(7),
Department varchar(50),
Salary int,
StartDate datetime,
Notes varchar(max)
);

select * from Employee
------------------------------------------------StoredProcedures------------------------------------------------
--Add Employee stored procedure
create procedure spAddEmployee(
@Name varchar(100),
@ProfileImage varchar(max),
@Gender varchar(7),
@Department varchar(50),
@Salary int,
@StartDate datetime,
@Notes varchar(max))
As
Begin try
insert into Employee(Name,ProfileImage,Gender,Department,Salary,StartDate,Notes) values(@Name,@ProfileImage,@Gender,@Department,@Salary,@StartDate,@Notes)
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spAddEmployee 'Megha','megha.jpg','Female','HR','100000','1900-01-01 08:20:05.123','Note2'


--GetAllEmployees stored procedure
create procedure spGetAllEmployees
As
Begin try
select * from Employee
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spGetAllEmployees


--UpdateEmployees stored procedure
create procedure spUpdateEmployee(
@EmployeeId int,
@Name varchar(100),
@ProfileImage varchar(max),
@Gender varchar(7),
@Department varchar(50),
@Salary int,
@StartDate datetime,
@Notes varchar(max)
)
As
Begin try
Update Employee set Name=@Name, ProfileImage=@ProfileImage,Gender=@Gender,Department=@Department,Salary=@Salary,StartDate=@StartDate,Notes=@Notes where EmployeeId=@EmployeeId
Select * from Employee where EmployeeId = @EmployeeId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH


--spDeleteEmployee stored procedure
create procedure spDeleteEmployee(@EmployeeId int)
As
Begin try
DELETE FROM Employee WHERE EmployeeId=@EmployeeId;
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

drop table Employee
drop procedure spAddEmployee
drop procedure spGetAllEmployees


SELECT * FROM Employee WHERE EmployeeId = 1