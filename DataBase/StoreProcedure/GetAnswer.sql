--procedure to get answer
create procedure GetAnswer(@QuestionId numeric(10))
as
begin
select AnswerDescription from Question where QuestionId=@QuestionId
end
