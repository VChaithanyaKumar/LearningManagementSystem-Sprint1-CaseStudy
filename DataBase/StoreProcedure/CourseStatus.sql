create procedure CourseStatus(@UserId numeric(10))
as
begin
Select C1.UserFirstName,C3.CourseTitle,C2.CourseStatus
From [User] C1
inner join CourseEnroll C2
on C1.UserId = C2.UserId
inner join Course C3
on C2.CourseId = C3.CourseId
where C1.UserId=@UserId
end