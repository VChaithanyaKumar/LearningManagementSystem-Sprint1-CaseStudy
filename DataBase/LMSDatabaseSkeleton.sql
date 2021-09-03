drop database LearningManagementSystem
--creating database named LearningManagementSystem
create database LearningManagementSystem

use LearningManagementSystem

--created a table named Users
create table [User](UserType varchar(20) check(UserType in('Admin','Learner')),
UserId numeric(10) primary key,
UserEmail varchar(30) unique,
UserPassword varchar(30) check((len(UserPassword)>=8) and (len(UserPassword)<=15)),
UserFirstName varchar(30) not null,
UserLastName varchar(30) default null,
Gender char check(Gender in('M','F','T')))


--preloding the admin details
insert into [User] values('Admin',10001,'admin@gmail.com','Admin@1234','Admin','Admin','M')
select * from [User]



--created a table named Courses
create table Course(CourseId numeric(10) primary key,
CourseTitle varchar(30) not null,
CourseDescription varchar(100) not null,
CourseOutcomes varchar(100))



--created a table named CourseEroll
create table CourseEnroll(EnrollId numeric(10) primary key,
UserId numeric(10) foreign key references [User](UserId),
CourseId numeric(10) foreign key references Course(CourseId),
DateOfEnrollment datetime default getdate(),
DateOfCompletion datetime default null,
CourseStatus bit default null)




--created a table named Question
create table Question(QuestionId numeric(10) primary key,
CourseId numeric(10) foreign key references Course(CourseId),
QuestionDescription varchar(100) not null,
AnswerDescription varchar(100) not null)





--creating table named Result
create table Result(
UserId numeric(10) foreign key references [User](UserId),
CourseId numeric(10) foreign key references Course(CourseId),
ResultDescription int not null)

select * from Course
select * from CourseEnroll
select * from Question
select * from Result
select * from [User]
