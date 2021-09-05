--procedure to get completed courses of a user using userid
alter procedure GetCompletedCourses(@UserEmail varchar(30))
as
begin
declare @UserId numeric(10)
select @UserId=UserId from [User] where UserEmail=@UserEmail
select t2.CourseTitle from CourseEnroll t1 join Course t2 on t1.CourseId=t2.CourseId where t1.UserId=@UserId and CourseStatus='Completed'
end

exec GetCompletedCourses 'praveena.vella1999@gmail.com'