USE [LearningManagementSystem]
GO
/****** Object:  StoredProcedure [dbo].[EnrollCourse]    Script Date: 06-09-2021 14:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[EnrollCourse](@UserEmail varchar(30),@CourseTitle varchar(30))
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
		if not exists(select 1,2 from CourseEnroll with(nolock) where UserId=@UserId and CourseId=@CourseId)
		insert into CourseEnroll values(@EnrollId,@UserId,@CourseId,getdate(),null,0)
		print'User is Enrolled to Course Successfully!'
	end
	else
		print 'Entered CourseTile is wrong,Please try again!'
end