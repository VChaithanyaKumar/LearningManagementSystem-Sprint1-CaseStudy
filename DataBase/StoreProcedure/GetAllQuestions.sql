create procedure GetAllQuestions(@CourseTitle varchar(30))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	select * from Question where CourseId=@CourseId
end