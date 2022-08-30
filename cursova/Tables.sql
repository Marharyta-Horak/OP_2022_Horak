drop table Marks
drop table RequiredSubjects
drop table Students
drop table Groups
drop table Speciality
drop table Departments
drop table Faculty
drop table Subjects

create table Faculty(
	[FacultyID] [int] NOT NULL identity(1,1) primary key clustered,
	[FacultyName] [nvarchar](10) NOT NULL,	
) 
create table Departments(
	[DepartmentID] [int] NOT NULL identity(1,1) primary key clustered,
	[DepartmentName] [nvarchar](10) NOT NULL,
	[FacultyID] [int] NOT NULL,
	CONSTRAINT [FK_Departments_Faculty] FOREIGN KEY([FacultyID]) REFERENCES [dbo].[Faculty] ([FacultyID])
) 
create table Speciality(
	[SpecialityID] [int] NOT NULL identity(1,1) primary key clustered,
	[SpecialityName] [nvarchar](10) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	CONSTRAINT [FK_Speciality_Departments] FOREIGN KEY([DepartmentID]) REFERENCES [dbo].[Departments] ([DepartmentID])
) 
create table Groups(
	[GroupID] [int] NOT NULL identity(1,1) primary key clustered,
	[Name] [nvarchar](10) NOT NULL,
	[Year] [int] NOT NULL,
	[SpecialityID] [int] NOT NULL
	CONSTRAINT [FK_Groups_Speciality] FOREIGN KEY([SpecialityID]) REFERENCES [dbo].[Speciality] ([SpecialityID])
) 
create table Students(
	[StudentID] [int] NOT NULL identity(1,1) primary key clustered,
	[FirstName] [nvarchar](50) NOT NULL,
    [SecondName][nvarchar](50) NOT NULL,
    [LastName] [nvarchar](50) NOT NULL,
	[Scholarship][bit] NOT NULL DEFAULT 0,
	[GroupID] [int] NOT NULL
	CONSTRAINT [FK_Students_Groups] FOREIGN KEY([GroupID]) REFERENCES [dbo].[Groups] ([GroupID])
) 
create table Subjects(
	[SubjectsID] [int] NOT NULL identity(1,1) primary key clustered,
	[SubjectsName] [nvarchar](50) NOT NULL,
) 
create table RequiredSubjects(
	[DSID] [int] NOT NULL identity(1,1) primary key clustered,
	[SpecialityID] [int] NOT NULL,
    [SubjectID] [int] NOT NULL,
	[Semester][int] NOT NULL,
	CONSTRAINT [FK_RS_Departments] FOREIGN KEY([SpecialityID]) REFERENCES [dbo].[Speciality] ([SpecialityID]),
	CONSTRAINT [FK_RS_Subjects] FOREIGN KEY([SubjectID]) REFERENCES [dbo].[Subjects] ([SubjectsID])
) 
create table Marks(
	[MarksID] [int] NOT NULL identity(1,1) primary key clustered,
    [DSID] [int] NOT NULL,
	[Marks] [int] NULL,
	[StudentID] [int] NOT NULL,
	[Semester][int] NOT NULL,
	CONSTRAINT [FK_Marks_Subjects] FOREIGN KEY([DSID]) REFERENCES [dbo].[RequiredSubjects] ([DSID]), 
	CONSTRAINT [FK_Marks_Students] FOREIGN KEY([StudentID]) REFERENCES [dbo].[Students] ([StudentID])
) 
