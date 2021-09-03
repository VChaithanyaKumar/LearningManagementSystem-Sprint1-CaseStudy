create procedure AddingUser(@UserType varchar(20),@UserEmail varchar(30),@UserPassword varchar(30),@UserFirstName varchar(30),@UserLastName varchar(30),@Gender char)
as
begin
declare @UserId numeric(10)
select @UserId=MAX(UserId) from [User]
set @UserId=@UserId+1
insert into [User] values(@UserType,@UserId,@UserEmail,@UserPassword,@UserFirstName,@UserLastName,@Gender)
end