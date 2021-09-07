--SP final

drop procedure AddCourseQuestion
--(SP) AddCourseQuestion
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

--(SP) AddUser
create procedure AddingUser(@UserType varchar(20),@UserEmail varchar(30),@UserPassword varchar(30),@UserFirstName varchar(30),@UserLastName varchar(30),@Gender char)
as
begin
declare @UserId numeric(10)
select @UserId=MAX(UserId) from [User]
set @UserId=@UserId+1
insert into [User] values(@UserType,@UserId,@UserEmail,@UserPassword,@UserFirstName,@UserLastName,@Gender)
end

drop procedure assigncourse

--(SP) AssignCourse
create procedure AssignCourse(@UserEmail varchar(30),@CourseTitle varchar(30),@AssignCourseReturnMsg varchar(100) out)
as
begin
	declare @UserId numeric(10),@CourseId numeric(10)
			,@EnrollId numeric(10)
	select @UserId=UserId from [User] where UserEmail=@UserEmail
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle	
	select @EnrollId=MAX(EnrollId) from CourseEnroll
	set @EnrollId=@EnrollId+1
	if @UserId!=0 and @CourseId!=0
	begin
		insert into CourseEnroll values(@EnrollId,@UserId,@CourseId,getdate(),null,0)
		set @AssignCourseReturnMsg= 'User is assigned to Course Successfully'
	end
	else
		set @AssignCourseReturnMsg='Entered User Email or CourseId is wrong.'
end
select * from [User]
select * from Course
select * from CourseEnroll
select * from Question
select * from Result

exec AddingUser Learner,'praveena.vella1999@gmail.com','10121999@Gmail','Praveena','Vella','F'

insert into CourseEnroll values(401,102,204,getdate(),null,0)
delete from CourseEnroll where CourseId=203
drop procedure CompleteCourse
--(SP) CompleteCourse
create procedure CompleteCourse(@UserEmail varchar(30),@CourseTitle varchar(30))
as
begin
	declare @UserId numeric(10),@CourseId numeric(10)
	select @UserId=UserId from [User] where UserEmail=@UserEmail
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	if @UserId!=0 and @CourseId!=0
	begin
	update CourseEnroll set DateOfCompletion=getdate(),CourseStatus='Completed' where CourseId=@CourseId and UserId=@UserId
	print 'You Successfully Completed the Course'
	end
	else
	print 'Error: Entered CourseTile is wrong,Please try again!'
end

select * from [User]
select * from Course
select * from CourseEnroll
select * from Question
select * from Result

exec MarkComplete 'praveena.vella1999@gmail.com','Learn Python'
drop procedure CourseQuestion
--(SP) CourseQuestion
create procedure CourseQuestion(@CourseId numeric(10))
as
begin
select QuestionId from question where CourseId=@CourseId
end
drop procedure CourseQuestionNo
--(SP) CourseQuestionNo
create procedure CourseQuestionNo(@CourseId numeric(10))
as
begin
select COUNT(QuestionId) from Question group by CourseId having CourseId=201
end
drop procedure CourseStatus
--(SP) CourseStatus
create procedure CourseStatus(@UserId numeric(10))
as
begin
Select C1.UserFirstName,C3.CourseTitle,C2.CourseStatus
From [User] C1
inner join CourseEnroll C2
on C1.UserId = C2.UserId
inner join Course C3
on C2.CourseId = C3.CourseId
where C1.UserId=@UserId
end
drop procedure DeleteCourse
--(SP) DeleteCourse
create procedure DeleteCourse(@CourseTitle varchar(30))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	delete from Question where CourseId= @CourseId
	delete from CourseEnroll where CourseId=@CourseId
	delete from Course where CourseId=@CourseId
end
exec DeleteCourse leaa
drop procedure DeleteUser
--(SP) DeleteUser
create procedure DeleteUser
@UserEmail varchar(30)
as
begin
declare @UserId numeric(10,0)
select @UserId=UserId from [User] where UserEmail=@UserEmail
delete from CourseEnroll where UserId=@UserId
delete from [User] where UserEmail=@UserEmail
end 
drop procedure EnrollCourse
--(SP) EnrollCourse
create procedure EnrollCourse(@UserEmail varchar(30),@CourseTitle varchar(30))
as
begin
	declare @UserId numeric(10),@CourseId numeric(10)
			,@EnrollId numeric(10)
	select @UserId=UserId from [User] where UserEmail=@UserEmail
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle	
	select @EnrollId=MAX(EnrollId) from CourseEnroll
	set @EnrollId=@EnrollId+1
	if @UserId!=0 and @CourseId!=0
	begin
		insert into CourseEnroll values(@EnrollId,@UserId,@CourseId,getdate(),null,null)
		print'User is Enrolled to Course Successfully!'
	end
	else
		print 'Entered CourseTile is wrong,Please try again!'
end


drop procedure EnrollCourse
select * from [User]
select * from Course
select * from CourseEnroll
select * from Question
select * from Result

exec AddingUser Learner,'praveena.vella1999@gmail.com','10121999@Gmail','Praveena','Vella','F'

insert into CourseEnroll values(401,102,204,getdate(),null,0)
delete from CourseEnroll where CourseId=204
drop procedure GenerateReport
--(SP) GenerateReport
Create procedure GenerateReport(@UserEmail varchar(30))
as
begin
declare @UserId numeric(10)
select @UserId=UserId from [User] where UserEmail=@UserEmail
select t1.UserId,t2.UserEmail,t1.CourseId,t3.CourseTitle,t1.DateOfEnrollment,t1.DateOfCompletion,t1.CourseStatus 
from CourseEnroll t1
Join [User] t2 on t1.UserId=t2.UserId 
Join Course t3
on t1.CourseId=t3.CourseId 
where t1.UserId=@UserId
end
drop procedure GetAllQuestions
--(SP) GetAllQuestions
create procedure GetAllQuestions(@CourseTitle varchar(30))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	select * from Question where CourseId=@CourseId
end

--(SP) GetAllUerEmail
create procedure GetAllUsers
as
begin
select UserEmail from [User]
end
drop procedure GetAnswer
--(SP) GetAnswer
create procedure GetAnswer(@QuestionId numeric(10))
as
begin
select AnswerDescription from Question where QuestionId=@QuestionId
end
drop procedure GetAnswers
--(SP) GetAnswers
create procedure GetAnswers(@CourseTitle varchar(30))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	select AnswerDescription from Question where CourseId=@CourseId
end
exec GetAnswers 'Learn Python'
drop procedure GetCompletedCourses
--(SP) GetCompletedCourses
create procedure GetCompletedCourses(@UserEmail varchar(30))
as
begin
declare @UserId numeric(10)
select @UserId=UserId from [User] where UserEmail=@UserEmail
select t2.CourseTitle from CourseEnroll t1 join Course t2 on t1.CourseId=t2.CourseId where t1.UserId=@UserId and CourseStatus='Completed'
end

exec GetCompletedCourses 'praveena.vella1999@gmail.com'
drop procedure GetCourseTitles
--(SP) GetCourseTitles
create procedure GetCourseTitles
as
begin
select CourseTitle from Course
end
drop procedure GetLoginDetails
--(SP) GetLoginDetails
create procedure GetLoginDetails(@UserEmail varchar(30))
as
begin
select UserType,UserEmail,UserPassword from [User] where UserEmail=@UserEmail
end

exec GetLoginDetails 'admin@gmail.com'
drop procedure GetQuestion
--(SP) GetQuestion
create procedure GetQuestion(@QuestionId numeric(10))
as
begin
select QuestionDescription from Question where QuestionId=@QuestionId
end
drop procedure GetQuestionCount
--(SP) GetQuestionCount
create procedure GetQuestionCount(@CourseTitle varchar(30))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	select COUNT(QuestionId) from Question group by CourseId having CourseId=@CourseId
end
drop procedure GetQuestions
--(SP) GetQuestions
create procedure GetQuestions(@CourseTitle varchar(30))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	select QuestionDescription from Question where CourseId=@CourseId
end
exec GetQuestions 'Learn Python'
drop procedure GetResult
--(SP) GetResult
create procedure GetResult(@UserEmail varchar(30),@CourseTitle varchar(30))
as
begin
	declare @UserId numeric(10),@CourseId varchar(10),@UserCheck numeric(10)--Changes Praveena
	select @UserId=UserId from [User] where UserEmail=@UserEmail--Changes Praveena
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle--Changes Praveena
	select ResultDescription from Result where UserId=@UserId and CourseId=@CourseId
end
drop procedure GetUserDetails
--(SP) GetUserDetails
create procedure GetUserDetails(@UserEmail varchar(30))
as
begin
select UserFirstName,UserLastName from [User] where UserEmail=@UserEmail
end
exec GetUserDetails 'praveena.vella1999@gmail.com'
drop procedure StartTest
--(SP) StartTest
create procedure StartTest(@UserEmail varchar(30),@CourseTitle varchar(30))
as
begin
	declare @UserId numeric(10),@CourseId varchar(10),@UserCheck numeric(10)--Changes Praveena
	select @UserId=UserId from [User] where UserEmail=@UserEmail--Changes Praveena
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle--Changes Praveena
	if exists(select 1,2 from Result with(nolock) where UserId=@UserId and CourseId=@CourseId)--changes Praveena
	begin
		return
	end
	else
		insert into Result(UserId,CourseId) values(@UserId,@CourseId)
end
select * from Course
select * from CourseEnroll
select * from Question
select * from Result
select * from [User]
drop procedure UpdateCourseDescription
--(SP) UpdateCourseDescription
create procedure UpdateCourseDescription(@CourseTitle varchar(30),@CourseDescription varchar(100))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	update Course set CourseDescription=@CourseDescription where CourseId=@CourseId
end

select * from [User]
select * from Course
select * from CourseEnroll
select * from Question
select * from Result

exec UpdateCourseDescription 'Learn ADO.NET','Learn ADO.NET with ease. Note: Prior knowledge in c# required.'
drop procedure UpdateCourseOutcome
--(SP) UpdateCourseOutcome
create procedure UpdateCourseOutcome(@CourseTitle varchar(30),@CourseOutcomes varchar(100))
as
begin
	declare @CourseId numeric(10)
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	update Course set CourseOutcomes=@CourseOutcomes where CourseId=@CourseId
end
exec UpdateCourseOutcome'Learn ADO.NET','After Completion of this course, you will be able to write ADO.Net Basic Codes'
drop procedure UpdateResult
--(SP) UpdateResult
create procedure UpdateResult(@UserEmail varchar(30),@CourseTitle varchar(30),@Percentage float)
as
begin
	declare @UserId numeric(10),@CourseId numeric(10)
	select @UserId=UserId from [User] where UserEmail=@UserEmail
	select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
	update Result set ResultDescription=@Percentage where UserId=@UserId and CourseId=@CourseId
end
select * from [User]
select * from Course
select * from CourseEnroll
select * from Question
select * from Result
delete from result where UserId=102
drop procedure updateuser


--(SP) UpdateUserpassword
create procedure UpdatePassword(
@UserEmail varchar(30),
@UserNewPassword varchar(30))
as
begin

update [User]
set UserPassword=@UserNewPassword
where UserEmail=@UserEmail

end

drop procedure UpdatePassword
select * from [User]
select * from Course
select * from CourseEnroll
select * from Question
select * from Result
exec UpdatePassword 'naveena.vella1999@gmail.com','05081997@Gmail','Gmail@05081997'

drop procedure UpdatePassword

create procedure GetPassword(@UserEmail varchar(20))
as
begin
select UserPassword from [User] where UserEmail=@UserEmail
end


drop procedure AddCourse

create procedure AddCourse(@CourseTitle varchar(20),@CourseDescription varchar(100),@CourseOutcomes varchar(100))
as
begin
declare @CourseId numeric(10)
select @CourseId=MAX(CourseId) from Course
set @CourseId=@CourseId+1
insert into Course values(@CourseId,@CourseTitle,@CourseDescription,@CourseOutcomes)
end

select * from [user]

exec GetAllUsers

drop procedure AssignCourse
select * from CourseEnroll
select * from [User]
select * from Course


create procedure AssignCourse(@UserEmail varchar(30),@CourseTitle varchar(20))
as
begin
declare @EnrollId numeric(10),@UserId numeric(10),@CourseId numeric(10)
select @EnrollId=MAX(EnrollId) from CourseEnroll
set @EnrollId=@EnrollId+1
select @UserId=UserId from [User] where UserEmail=@UserEmail
select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
insert into CourseEnroll(EnrollId,UserId,CourseId,DateOfEnrollment)  values(@EnrollId,@UserId,@CourseId,GETDATE())
end


create procedure AssignCoursebyAdmin(@UserEmail varchar(30),@CourseTitle varchar(20))
as
begin
declare @EnrollId numeric(10),@UserId numeric(10),@CourseId numeric(10)
select @EnrollId=MAX(EnrollId) from CourseEnroll
set @EnrollId=@EnrollId+1
select @UserId=UserId from [User] where UserEmail=@UserEmail
select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
insert into CourseEnroll(EnrollId,UserId,CourseId,DateOfEnrollment)  values(@EnrollId,@UserId,@CourseId,GETDATE())
end

create procedure GetUserIdEmail
as
begin
select UserId,UserEmail from [User]
end

create procedure GetEnrolledCourses(@UserEmail varchar(30))
as
begin
declare @UserId numeric(10)
	select @UserId=UserId from [User] where UserEmail=@UserEmail
select t1.CourseId,t2.CourseTitle from CourseEnroll t1 join Course t2 on t1.CourseId=t2.CourseId where t1.UserId=@UserId
end
drop procedure GetEnrolledCourses
select * from Question
select * from Course

create procedure GenerateReport
as
begin

select t1.UserId,t2.UserEmail,t1.CourseId,t3.CourseTitle,t1.DateOfEnrollment,t1.DateOfCompletion,t1.CourseStatus 
from CourseEnroll t1
Join [User] t2 on t1.UserId=t2.UserId 
Join Course t3
on t1.CourseId=t3.CourseId 
where t1.UserId=t2.UserId
end

drop procedure GenerateReport

create procedure GetAllUserDetails
as
begin
select UserType,UserId,UserEmail from [User]
end

exec  GetAllUserDetails
select * from CourseEnroll

create procedure RemoveResult(@UserEmail varchar(20))
as
declare @UserId numeric(10)
select @UserId=UserId from [User] where UserEmail=@UserEmail
begin
delete from Result where UserId=@UserId
end
drop procedure RemoveResult
delete from Result where UserId=106

create procedure RemoveResultcourse(@CourseTitle varchar(20))
as
declare @CourseId numeric(10)
select @CourseId=CourseId from Course where CourseTitle=@CourseTitle
begin
delete from Result where CourseId=@CourseId
end


update CourseEnroll set CourseStatus='started' where EnrollId=402
select * from CourseEnroll