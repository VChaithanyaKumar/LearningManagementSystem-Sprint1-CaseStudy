--procedure to get number of questions related to a course
alter procedure CourseQuestionNo(@CourseId numeric(10))
as
begin
select COUNT(QuestionId) from Question group by CourseId having CourseId=201
end
