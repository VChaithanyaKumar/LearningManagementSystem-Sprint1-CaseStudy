create procedure GetUserDetails(@UserEmail varchar(30))
as
begin
select UserFirstName,UserLastName from [User] where UserEmail=@UserEmail
end
exec GetUserDetails 'praveena.vella1999@gmail.com'