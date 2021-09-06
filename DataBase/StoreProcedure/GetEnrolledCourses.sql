alter procedure GetEnrolledCourses(@UserEmail varchar(30))
as
begin
declare @UserId numeric(10)
	select @UserId=UserId from [User] where UserEmail=@UserEmail
select t1.CourseId,t2.CourseTitle from CourseEnroll t1 join Course t2 on t1.CourseId=t2.CourseId where t1.UserId=@UserId and CourseStatus='Completed'
end