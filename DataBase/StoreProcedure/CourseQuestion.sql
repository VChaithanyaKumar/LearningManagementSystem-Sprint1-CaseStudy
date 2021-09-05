--procedure to get questionIds related to a course
alter procedure CourseQuestion(@CourseId numeric(10))
as
begin
select QuestionId from question where CourseId=@CourseId
end