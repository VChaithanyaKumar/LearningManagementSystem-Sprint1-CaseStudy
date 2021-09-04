--procedure to update the course outcome
alter procedure UpdateCourseOutcome(@CourseTitle varchar(30),@CourseOutcomes varchar(100))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	update Course set CourseOutcomes=@CourseOutcomes where CourseId=@CourseId
end
exec UpdateCourseOutcome'Learn ADO.NET','After Completion of this course, you will be able to write ADO.Net Basic Codes'