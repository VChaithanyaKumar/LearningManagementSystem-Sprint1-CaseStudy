--procedure to get question
create procedure GetQuestion(@QuestionId numeric(10))
as
begin
select QuestionDescription from Question where QuestionId=@QuestionId
end