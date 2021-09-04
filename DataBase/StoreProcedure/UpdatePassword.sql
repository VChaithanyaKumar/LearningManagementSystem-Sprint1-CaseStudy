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
go