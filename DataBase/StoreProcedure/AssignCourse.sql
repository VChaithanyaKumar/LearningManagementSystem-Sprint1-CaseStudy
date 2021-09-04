alter procedure AssignCourse(@UserEmail varchar(30),@CourseTitle varchar(30),@AssignCourseReturnMsg varchar(100) out)
as
begin
	declare @UserId numeric(10),@CourseId numeric(10)
			,@EnrollId numeric(10)
	select @UserId=UserId from [User] where UserEmail=@UserEmail
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle	
	select @EnrollId=MAX(EnrollId) from CourseEnroll
	set @EnrollId=@EnrollId+1
	if @UserId!=0 and @CourseId!=0
	begin
		insert into CourseEnroll values(@EnrollId,@UserId,@CourseId,getdate(),null,0)
		set @AssignCourseReturnMsg= 'User is assigned to Course Successfully'
	end
	else
		set @AssignCourseReturnMsg='Entered User Email or CourseId is wrong.'
end
select * from [User]
select * from Course
select * from CourseEnroll
select * from Question
select * from Result

exec AddingUser Learner,'praveena.vella1999@gmail.com','10121999@Gmail','Praveena','Vella','F'

insert into CourseEnroll values(401,102,204,getdate(),null,0)
delete from CourseEnroll where CourseId=203