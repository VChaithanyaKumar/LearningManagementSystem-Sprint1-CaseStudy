create procedure GetAnswers(@CourseTitle varchar(30))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	select AnswerDescription from Question where CourseId=@CourseId
end
exec GetAnswers 'Learn Python'