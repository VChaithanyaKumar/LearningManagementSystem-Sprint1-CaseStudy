--creating database named LearningManagementSystem
create database LearningManagementSystem

using LearningManagementSystem

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

--created a table named Author
create table Author(AuthorId numeric(10) primary key,
AuthorFirstName varchar(20) not null,
AuthorLastName varchar(20),
Gender char check(Gender in('M','F','T')),
AuthorEmail varchar(20))


--inserting into author table
insert into Author values(10001,'P.J. Allen',' ','M','p.j.allen@gmail.com')
insert into Author values(10002,'H. Schild',' ','M','h.schild@gmail.com')
insert into Author values(10003,'B.C. Desai',' ','F','b.c.desai@gmail.com')
insert into Author values(10004,'Cormen',' ','M','cormen@gmail.com')
insert into Author values(10005,'Millan',' ','F','millan@gmail.com')


--created a table named Courses
create table Course(CourseId numeric(10) primary key,
CourseTitle varchar(30) not null,
CourseDescription varchar(100) not null,
AuthorId numeric(10) foreign key references Author(AuthorId),
CourseOutcomes varchar(100))


--inserting into courses table
insert into Course values(10011,'Learn C#','Learn C# with ease. Note: No pre-requisites.',10001,'By the end of this course, you will learn c# from scratch.')
insert into Course values(10012,'Learn ADO.NET','Learn ADO.NET with ease. Note: Prior knowledge in c# required.',10002,'By the end of this course, you will learn ADO.NET from scratch.')
insert into Course values(10013,'Learn JAVA','Learn JAVA with ease. Note: No pre-requisites.',10003,'By the end of this course, you will learn JAVA from scratch.')
insert into Course values(10014,'Learn Python','Learn Python with ease. Note: No pre-requisites.',10004,'By the end of this course, you will learn Python from scratch.')
insert into Course values(10015,'Learn C++','Learn C++ with ease. Note: No pre-requisites.',10005,'By the end of this course, you will learn C++ from scratch.')


--created a table named CourseEroll
create table CourseEnroll(EnrollId numeric(10) primary key,
UserId numeric(10) foreign key references [User](UserId),
CourseId numeric(10) foreign key references Course(CourseId),
DateOfEnrollment datetime default getdate(),
DateOfCompletion datetime ,
CourseStatus bit)


--created a table named Question
create table Question(QuestionId numeric(10) primary key,
CourseId numeric(10) foreign key references Course(CourseId),
QuestionDescription varchar(100) not null,
AnswerDescription varchar(100) not null)


--inserting into Question table

--questions related to C#
insert into Question values(10021,10011,'The ____ language allows more than one method in a single class.','C#')
insert into Question values(10022,10011,'All C# applications begin execution by calling the _____ method.','Main()')
insert into Question values(10023,10011,'A _______ is an identifier that denotes a storage location.','Variable')

--questions realetd to AD0.NET
insert into Question values(10024,10012,'In a connection string _____________ represents name of the database.','Initial Catalog')
insert into Question values(10025,10012,'Which ado.net class provide a disconnected environment?','DataSet')
insert into Question values(10026,10012,'Which database is the ADO.NET SqlConnection object designed for?','Microsoft SQL Server')

--questions related to Java
insert into Question values(10027,10013,'_____ is used to find and fix bugs in the Java programs.','JDB')
insert into Question values(10028,10013,'What is the return type of the hashCode() method in the Object class?','int')
insert into Question values(10029,10013,'In which process, a local variable has the same name as one of the instance variables?','Variable Shadowing')

--questions related to Python
insert into Question values(10130,10014,'Who developed the Python language?','Guido van Rossum')
insert into Question values(10131,10014,'In which year was the Python language developed?','1989')
insert into Question values(10132,10014,'In which language is Python written?','C')

--questions related to C++
insert into Question values(10133,10015,'The programming language that has the ability to create new data types is called___.','Extensible')
insert into Question values(10134,10015,'Which of the following is the original creator of the C++ language?','Bjarne Stroustrup')
insert into Question values(10135,10015,'The C++ language is ______ object-oriented language.','Semi Object-oriented or Partial Object-oriented')


--creating table named Result
create table Result(
UserId numeric(10) foreign key references [User](UserId),
CourseId numeric(10) foreign key references Course(CourseId),
ResultDescription int not null)


