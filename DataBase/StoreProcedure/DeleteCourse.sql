--procedure to delete a course
create procedure DeleteCourse(@CourseTitle varchar(30))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	delete from Question where CourseId= @CourseId
	delete from CourseEnroll where CourseId=@CourseId
	delete from Course where CourseId=@CourseId
end