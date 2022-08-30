DELETE Marks
Alter table Marks add constraint def default rand()+rand()+rand()+rand()+ 1 for Marks
Declare @count int = 75
while(@count<=148)
	begin
		Declare @subjects int = rand()*3+1
		Insert into Marks (DSID, StudentID, Semester)
				Select top (@subjects) DSID, @count, 2
					from dbo.RequiredSubjects 
						where SpecialityID in (Select SpecialityID 
												from Groups where GroupID in (Select GroupID 
																				from Students where StudentID = @count)) order by rand() 
		Set @count = @count + 1
	end;
Alter table Marks drop constraint def 
update Marks set Marks = rand()*3+3 where MarksID = round(rand()*142 + 457, 0)