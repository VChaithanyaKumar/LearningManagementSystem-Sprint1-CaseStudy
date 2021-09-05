create table Result(
UserId numeric(10) foreign key references [User](UserId),
CourseId numeric(10) foreign key references Course(CourseId),
ResultDescription float null)
drop table Result