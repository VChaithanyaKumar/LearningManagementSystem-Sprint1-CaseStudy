--procedure to update the course description
create procedure UpdateCourseDescription(@CourseTitle varchar(30),@CourseDescription varchar(100))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	update Course set CourseDescription=@CourseDescription where CourseId=@CourseId
end

select * from [User]
select * from Course
select * from CourseEnroll
select * from Question
select * from Result

exec UpdateCourseDescription 'Learn ADO.NET','Learn ADO.NET with ease. Note: Prior knowledge in c# required.'