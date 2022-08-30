CREATE FUNCTION dbo.GetTableSubjForSpecility(@Speciality int)
	RETURNS TABLE
	RETURN (
		SELECT * FROM  AS M 
		join  RequiredSubjects AS RS ON M.DSID = RS.DSID 
		join Subjects AS S ON S.SubjectsID = RS.SubjectID 
		where RS.SpecialityID = @Speciality
	)