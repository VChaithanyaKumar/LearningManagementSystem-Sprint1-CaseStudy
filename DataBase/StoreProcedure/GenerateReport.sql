Create procedure GenerateReport(@UserEmail varchar(30))
as
begin
declare @UserId numeric(10)
select @UserId=UserId from [User] where UserEmail=@UserEmail
select t1.UserId,t2.UserEmail,t1.CourseId,t3.CourseTitle,t1.DateOfEnrollment,t1.DateOfCompletion,t1.CourseStatus 
from CourseEnroll t1
Join [User] t2 on t1.UserId=t2.UserId 
Join Course t3
on t1.CourseId=t3.CourseId 
where t1.UserId=@UserId
end

