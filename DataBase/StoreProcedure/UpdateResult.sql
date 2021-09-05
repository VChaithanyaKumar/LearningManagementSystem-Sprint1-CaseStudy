alter procedure UpdateResult(@UserEmail varchar(30),@CourseTitle varchar(30),@Percentage float)
as
begin
	declare @UserId numeric(10),@CourseId numeric(10)
	select @UserId=UserId from [User] where UserEmail=@UserEmail
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	update Result set ResultDescription=@Percentage where UserId=@UserId and CourseId=@CourseId
end
select * from [User]
select * from Course
select * from CourseEnroll
select * from Question
select * from Result
delete from result where UserId=102