create procedure AddCourseQuestion(@CourseTitle varchar(30),@QuestionDescription varchar(100),@AnswerDescription varchar(100))
as
begin
declare @QuestionId numeric(10)
select @QuestionId=MAX(QuestionId) from Question
set @QuestionId=@QuestionId+1
declare @CourseId numeric(10)
select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
insert into Question values(@QuestionId,@CourseId,@QuestionDescription,@AnswerDescription) 
end

exec AddCourseQuestion 'Learn C#','Is C# an object oriented programming language','True'