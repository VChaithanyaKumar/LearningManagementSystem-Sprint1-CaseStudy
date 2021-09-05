create procedure GetResult(@UserEmail varchar(30),@CourseTitle varchar(30))
as
begin
	declare @UserId numeric(10),@CourseId varchar(10),@UserCheck numeric(10)--Changes Praveena
	select @UserId=UserId from [User] where UserEmail=@UserEmail--Changes Praveena
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle--Changes Praveena
	select ResultDescription from Result where UserId=@UserId and CourseId=@CourseId
end