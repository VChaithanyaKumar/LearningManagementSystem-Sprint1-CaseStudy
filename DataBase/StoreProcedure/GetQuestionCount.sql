--procedure to get number of questions related to a course
create procedure GetQuestionCount(@CourseTitle varchar(30))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	select COUNT(QuestionId) from Question group by CourseId having CourseId=@CourseId
end