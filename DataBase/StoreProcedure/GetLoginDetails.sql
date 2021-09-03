create procedure GetLoginDetails(@UserEmail varchar(30))
as
begin
select UserType,UserEmail,UserPassword from [User] where UserEmail=@UserEmail
end

exec GetLoginDetails 'admin@gmail.com'