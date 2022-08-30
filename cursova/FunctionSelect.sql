CREATE FUNCTION dbo.GetDoneSubjects(@StudentID int)
	RETURNS TABLE
	RETURN (
		SELECT RS.SubjectID, DS_Marks.Marks 
		FROM dbo.RequiredSubjects AS RS
		JOIN (SELECT DSID, Marks FROM Marks WHERE StudentID = @StudentID) AS DS_Marks ON RS.DSID = DS_Marks.DSID
	)

CREATE FUNCTION dbo.GetAllSubjects(@StudentID int)
	RETURNS TABLE
	RETURN (
		SELECT SubjectID 
		FROM dbo.RequiredSubjects 
		WHERE SpecialityID in (SELECT SpecialityID 
								FROM Groups WHERE GroupID in (SELECT GroupID 
															  FROM Students WHERE StudentID = @StudentID))
	)
CREATE FUNCTION dbo.GetAllNotDoneSubjects(@StudentID int)
	RETURNS TABLE
	RETURN (
		SELECT * FROM dbo.GetAllSubjects(@StudentID)
				 WHERE SubjectID not in (SELECT GDS.SubjectID FROM dbo.GetDoneSubjects(@StudentID) AS GDS)
)

CREATE FUNCTION dbo.GetTableSubjForSpecility(@Speciality int)
	RETURNS TABLE
	RETURN (
		SELECT ST.Surname, ST.Name, S.SubjectsName, M.Marks FROM Marks AS M 
		join  RequiredSubjects AS RS ON M.DSID = RS.DSID 
		join Subjects AS S ON S.SubjectsID = RS.SubjectID 
		join Students AS ST ON ST.StudentID = M.StudentID
		where SpecialityID = @Speciality
)

CREATE FUNCTION dbo.GetSpecialityByGroup(@GrID int)
	RETURNS INT
	BEGIN
		RETURN (
		SELECT SpecialityID FROM Groups WHERE GroupID = @GrID
		)
	END
CREATE FUNCTION dbo.GetDepartamensBySpeciality(@SpID int)
	RETURNS INT
	BEGIN
		RETURN (
		SELECT DepartmentID FROM Speciality WHERE SpecialityID = @SpID
		)
	END
CREATE FUNCTION dbo.GetBadStudents(@DepartmenID int)
	RETURNS TABLE
	RETURN (
		SELECT S.Name AS StudentName, S.Surname, GR.Name, SU.SubjectsName, SUBJ.Mark
		FROM Students AS S
		CROSS APPLY (SELECT SubjectID, NULL AS Mark
					 FROM dbo.GetAllNotDoneSubjects(S.StudentID) 
					 UNION ALL SELECT RS.SubjectID , M.Marks
							   FROM Marks AS M 
							   JOIN RequiredSubjects AS RS ON RS.DSID = M.DSID
							   WHERE M.StudentID = S.StudentID and Marks<=2) AS SUBJ
		JOIN Subjects AS SU ON SU.SubjectsID = SUBJ.SubjectID
		JOIN Groups AS GR ON GR.GroupID = S.GroupID
		WHERE dbo.GetDepartamensBySpeciality(dbo.GetSpecialityByGroup(S.GroupID)) = @DepartmenID
)
CREATE FUNCTION dbo.GetDeparByFaculty(@FacultyID int)
	RETURNS INT
	BEGIN
		RETURN (
		SELECT DepartmentID FROM Departments WHERE FacultyID = @FacultyID
		)
	END
CREATE FUNCTION dbo.SpetialityByDepart(@DepID int)
RETURNS INT
	BEGIN
		RETURN (
		SELECT SpecialityID FROM Speciality WHERE DepartmentID = @DepID
		)
	END
CREATE FUNCTION dbo.GroupBySpetiality(@SpID int)
RETURNS INT
	BEGIN
		RETURN (
		SELECT GroupID FROM Groups WHERE SpecialityID = @SpID
		)
	END
CREATE FUNCTION dbo.GPAGroupFac(@FacultyID int)
		RETURNS TABLE
		RETURN(
		WITH ST AS
			(SELECT M.StudentID, AVG(CAST(M.Marks AS numeric)) AS Mark, ST.GroupID
					FROM Students AS ST
					JOIN Marks AS M ON M.StudentID = ST.StudentID
					Group by M.StudentID, ST.GroupID )
			SELECT G.GroupID, G.Name, AVG(CAST(ST.Mark AS numeric)) AS GPA_Marks 
			FROM (SELECT DepartmentID FROM Departments WHERE FacultyID = @FacultyID) AS D
			JOIN Speciality AS S ON S.DepartmentID = D.DepartmentID
			JOIN Groups AS G ON S.SpecialityID = G.SpecialityID
			JOIN  ST ON  ST.GroupID = G.GroupID
			GROUP BY G.GroupID, G.Name
)
CREATE FUNCTION dbo.GPASubject()
RETURNS TABLE
		RETURN(
		WITH M AS (
		SELECT RS.SubjectID, AVG(CAST(Marks.Marks AS numeric))  AS GPA_Marks
		FROM Marks 
		JOIN RequiredSubjects AS RS ON RS.DSID = Marks.DSID
		Group by RS.SubjectID)
		SELECT SUB.SubjectsName, M.GPA_Marks 
		FROM M 
		JOIN Subjects AS SUB ON M.SubjectID = SUB.SubjectsID
)
CREATE FUNCTION dbo.GetStudentsToScholaship()
RETURNS TABLE
	RETURN(
	SELECT st.StudentID, st.GroupID, 
			dbo.GetSpecialityByGroup(st.GroupID) AS speciality, 
			dbo.GetDepartamensBySpeciality(dbo.GetSpecialityByGroup(st.GroupID)) AS department
	FROM Students AS ST 
	WHERE ((SELECT COUNT (*) FROM dbo.GetAllNotDoneSubjects(ST.StudentID)) = 0) 
	and (SELECT COUNT (*) FROM dbo.GetDoneSubjects(ST.StudentID) WHERE Marks <= 3) = 0 
)
CREATE PROCEDURE dbo.GetScholaship(@PARAMETR int = null)
AS 
	UPDATE Students SET Students.Scholarship = 1
	WHERE StudentID in (SELECT StudentID FROM dbo.GetStudentsToScholaship())

CREATE FUNCTION dbo.GetStudentsToScholashipforDepart(@DepartID int)
RETURNS TABLE
	RETURN(
	SELECT S.Surname, S.Name
	FROM  (SELECT GSTS.StudentID 
	FROM dbo.GetStudentsToScholaship() AS GSTS
	WHERE GSTS.department = @DepartID) AS STUD
	JOIN Students AS S ON S.StudentID = STUD.StudentID	
)
CREATE FUNCTION dbo.GetStudentsToBYEBYE(@FacultyID int)
RETURNS TABLE
	RETURN(
	WITH BEBE AS
	(
		SELECT * FROM Students
		WHERE 
			(SELECT COUNT(*) FROM 
							 (SELECT SubjectID 
							 FROM dbo.GetAllNotDoneSubjects(StudentID)
							 UNION ALL 
							 SELECT SubjectID 
							 From dbo.GetDoneSubjects(StudentID)
							 WHERE Marks <= 2) AS DS
			) > 2
	), 
	GroupsByDep AS(
	SELECT G.GroupID 
	From (SELECT * FROM Departments WHERE FacultyID = @FacultyID) AS D 
	JOIN Speciality AS S ON S.DepartmentID = D.DepartmentID
	JOIN Groups AS G ON G.SpecialityID = S.SpecialityID
	)
	SELECT ST.StudentID, ST.Surname, ST.Name, ST.GroupID  
	FROM Students AS ST WHERE ST.GroupID in (SELECT* FROM GroupsByDep)
	AND StudentID in (SELECT StudentID FROM BEBE)
)
CREATE FUNCTION dbo.GetBADSubjects()
RETURNS TABLE
	RETURN(
	WITH NOTE AS(
	SELECT SubjectID FROM Marks
	JOIN RequiredSubjects AS RS ON Marks.DSID = RS.DSID
	WHERE Marks.Marks <= 2
	)
	SELECT SubjectID, COUNT(*) AS amount FROM NOTE 
	GROUP BY SubjectID
)
CREATE FUNCTION dbo.AllStofFac(@FacID int)
RETURNS TABLE
	RETURN(
		SELECT COUNT(1) AS HowMuch FROM (SELECT * FROM Departments AS D WHERE D.FacultyID = @FacID) AS DEP 
		JOIN Speciality AS S ON DEP.DepartmentID = S.DepartmentID
		JOIN Groups AS G ON S.SpecialityID = G.SpecialityID
		Join Students AS ST ON G.GroupID = ST.GroupID
)
SELECT DepartmentName, DepartmentID From Departments

SELECT * FROM dbo.GetStudentsToScholashipforDepart(1)
SELECT * FROM dbo.GetBADSubjects() ORDER BY 2 DESC 
SELECT * FROM dbo.GetBADSubjects() ORDER BY 2
EXEC dbo.GetScholaship
SELECT * FROM dbo.GPAGroupFac()
SELECT * FROM dbo.GPAGroupFac(1) 		
DROP FUNCTION dbo.GetStudentsToScholashipforDepart
SELECT * FROM dbo.GetAllNotDoneSubjects(140)
DROP FUNCTION dbo.GroupBySpetiality
DROP PROC dbo.GetScholaship
SELECT * FROM dbo.AllStofFac(1)
SELECT COUNT(1) FROM(SELECT * FROM dbo.GetStudentsToScholashipforDepart({Facultyeis[faculty_select.SelectedItem as string]})) AS GSTS

SELECT S.SubjectsName FROM dbo.GetBADSubjects() AS SB 
JOIN Subjects AS S ON S.SubjectsID = SB.SubjectID ORDER BY SB.amount DESC


CREATE PROC dbo.AddStudent(@GroupID nvarchar(10), @Name nvarchar(50), @SurName nvarchar(50), @SecondName nvarchar(50))
	AS
		DECLARE @GroupIDInt INT;
		SET @GroupIDInt = dbo.FindIDGroup(@GroupID);
		INSERT INTO dbo.Students
				([Surname], [Name], [LastName], [GroupID])
		VALUES      (@SurName, @Name, @SecondName, @GroupIDInt)

CREATE PROC dbo.UpdateGroupId(@GroupID int, @StId int)
	AS
		UPDATE dbo.Students 
			SET 
				[GroupID] = @GroupID
			WHERE
				StudentID = @StId;

CREATE PROC dbo.DeleteStudent(@IDSt int)
	AS
		DELETE FROM dbo.Marks WHERE StudentID = @IDSt
		DELETE FROM dbo.Students WHERE StudentID = @IDSt;

CREATE FUNCTION dbo.FindIDGroup(@Group nvarchar(10))
RETURNS INT
	BEGIN
		RETURN (
		SELECT GroupID FROM Groups WHERE Name = @Group
		)
	END
DROP PROC dbo.DeleteStudent
SELECT dbo.FindIDGroup('ÊÏ-12')
EXEC dbo.DeleteStudent 140
