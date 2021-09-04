create procedure AddCourse(@CourseTitle varchar(30),@CourseDescription varchar(100),@CourseOutcomes varchar(100))
as
begin
declare @CourseId numeric(10)
select @CourseId=MAX(CourseId) from Course
set @CourseId=@CourseId+1
insert into Course values(@CourseId,@CourseTitle,@CourseDescription,@CourseOutcomes)
end