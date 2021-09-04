create procedure UpdatePassword
@UserEmail varchar(30),
@UserOldPassword varchar(30),
@UserNewPassword varchar(30)
as
begin

update [User]
set UserPassword=@UserNewPassword
where UserEmail=@UserEmail and UserPassword=@UserOldPassword;

end
select * from [User]
select * from Course
select * from CourseEnroll
select * from Question
select * from Result
exec UpdatePassword 'naveena.vella1999@gmail.com','05081997@Gmail','Gmail@05081997'