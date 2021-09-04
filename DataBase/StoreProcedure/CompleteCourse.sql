create procedure CompleteCourse(@UserEmail varchar(30),@CourseTitle varchar(30))
as
begin
	declare @UserId numeric(10),@CourseId numeric(10)
	select @UserId=UserId from [User] where UserEmail=@UserEmail
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	if @UserId!=0 and @CourseId!=0
	begin
	update CourseEnroll set DateOfCompletion=getdate(),CourseStatus='Completed' where CourseId=@CourseId and UserId=@UserId
	print 'You Successfully Completed the Course'
	end
	else
	print 'Error: Entered CourseTile is wrong,Please try again!'
end

select * from [User]
select * from Course
select * from CourseEnroll
select * from Question
select * from Result

exec MarkComplete 'praveena.vella1999@gmail.com','Learn Python'