drop database LearningManagementSystem
--creating database named LearningManagementSystem
create database LearningManagementSystem

use LearningManagementSystem

--created a table named Users
create table [User](UserType varchar(20) ,
UserId numeric(10) primary key,
UserEmail varchar(30) unique,
UserPassword varchar(30) check((len(UserPassword)>=8) and (len(UserPassword)<=15)),
UserFirstName varchar(30) not null,
UserLastName varchar(30) default null,
Gender char check(Gender in('M','F','T')))


--preloding the admin details
insert into [User] values('Admin',101,'admin@gmail.com','Admin@1234','Admin','Admin','M')
select * from [User]



--created a table named Courses
create table Course(CourseId numeric(10) primary key,
CourseTitle varchar(30) not null,
CourseDescription varchar(100) not null,
CourseOutcomes varchar(100))

insert into Course values(201,'Learn C#','Learn C# with ease. Note: No pre-requisites.','By the end of this course, you will learn c# from scratch.')
insert into Course values(202,'Learn ADO.NET','Learn ADO.NET with ease. Note: Prior knowledge in c# required.','By the end of this course, you will learn ADO.NET from scratch.')
insert into Course values(203,'Learn JAVA','Learn JAVA with ease. Note: No pre-requisites.','By the end of this course, you will learn JAVA from scratch.')
insert into Course values(204,'Learn Python','Learn Python with ease. Note: No pre-requisites.','By the end of this course, you will learn Python from scratch.')
insert into Course values(205,'Learn C++','Learn C++ with ease. Note: No pre-requisites.','By the end of this course, you will learn C++ from scratch.')



--created a table named CourseEroll
create table CourseEnroll(EnrollId numeric(10) primary key,
UserId numeric(10) foreign key references [User](UserId),
CourseId numeric(10) foreign key references Course(CourseId),
DateOfEnrollment datetime default getdate(),
DateOfCompletion datetime default null,
CourseStatus varchar(10) default 'Started')

drop table CourseEnroll


--created a table named Question
create table Question(QuestionId numeric(10) primary key,
CourseId numeric(10) foreign key references Course(CourseId),
QuestionDescription varchar(100) not null,
AnswerDescription varchar(100) not null)


--questions related to C#
insert into Question values(301,201,'The ____ language allows more than one method in a single class.','C#')
insert into Question values(302,201,'All C# applications begin execution by calling the _____ method.','Main()')
insert into Question values(303,201,'A _______ is an identifier that denotes a storage location.','Variable')

--questions realetd to AD0.NET
insert into Question values(304,202,'In a connection string _____________ represents name of the database.','Initial Catalog')
insert into Question values(305,202,'Which ado.net class provide a disconnected environment?','DataSet')
insert into Question values(306,202,'Which database is the ADO.NET SqlConnection object designed for?','Microsoft SQL Server')

--questions related to Java
insert into Question values(307,203,'_____ is used to find and fix bugs in the Java programs.','JDB')
insert into Question values(308,203,'What is the return type of the hashCode() method in the Object class?','int')
insert into Question values(309,203,'In which process, a local variable has the same name as one of the instance variables?','Variable Shadowing')

--questions related to Python
insert into Question values(310,204,'Who developed the Python language?','Guido van Rossum')
insert into Question values(311,204,'In which year was the Python language developed?','1989')
insert into Question values(312,204,'In which language is Python written?','C')

--questions related to C++
insert into Question values(313,205,'The programming language that has the ability to create new data types is called___.','Extensible')
insert into Question values(314,205,'Which of the following is the original creator of the C++ language?','Bjarne Stroustrup')
insert into Question values(315,205,'The C++ language is ______ object-oriented language.','Semi Object-oriented or Partial Object-oriented')





--creating table named Result
create table Result(
UserId numeric(10) foreign key references [User](UserId),
CourseId numeric(10) foreign key references Course(CourseId),
ResultDescription float default null)










select * from Course
select * from CourseEnroll
select * from Question
select * from Result
select * from [User]

delete from [user] where UserId=106
delete from cou

select * from [User]




