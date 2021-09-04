create procedure DeleteUser
@UserEmail varchar(30)
as
begin
declare @UserId numeric(10,0)
select @UserId=UserId from [User] where UserEmail=@UserEmail
delete from CourseEnroll where UserId=@UserId
delete from [User] where UserEmail=@UserEmail
end 


