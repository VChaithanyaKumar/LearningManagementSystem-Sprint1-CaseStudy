--inserting into result table before starting the test
alter procedure StartTest(@UserEmail varchar(30),@CourseTitle varchar(30))
as
begin
	declare @UserId numeric(10),@CourseId varchar(10),@UserCheck numeric(10)--Changes Praveena
	select @UserId=UserId from [User] where UserEmail=@UserEmail--Changes Praveena
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle--Changes Praveena
	if exists(select 1,2 from Result with(nolock) where UserId=@UserId and CourseId=@CourseId)--changes Praveena
	begin
		return
	end
	else
		insert into Result(UserId,CourseId) values(@UserId,@CourseId)
end
select * from Course
select * from CourseEnroll
select * from Question
select * from Result
select * from [User]
