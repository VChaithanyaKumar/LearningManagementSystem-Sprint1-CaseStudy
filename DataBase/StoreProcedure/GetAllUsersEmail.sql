--procedure to get all users
create procedure GetAllUsers
as
begin
select UserEmail from [User]
end