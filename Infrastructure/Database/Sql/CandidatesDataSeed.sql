declare @creationAuthor NVARCHAR(50) = 'systemseed'
declare @updateAuthor NVARCHAR(50) = 'systemseed'
declare @creationDate datetime2(7) = getdate()
declare @updateDate datetime2(7) = getdate()

BEGIN TRY

		INSERT INTO dbo.Candidates(Id, Name, LastName, OpinionBrief, Votes, CreationAuthor, CreationDate, UpdateAuthor, UpdateDate)
		VALUES (newid(), 'Filip', 'Nejezto', 'Chce postavit most', 0, @creationAuthor, @creationDate, @updateAuthor, @updateDate)

		INSERT INTO dbo.Candidates(Id, Name, LastName, OpinionBrief, Votes, CreationAuthor, CreationDate, UpdateAuthor, UpdateDate)
		VALUES (newid(), 'Jan', 'Majetný', 'Chce postavit most a silnici k němu', 0, @creationAuthor, @creationDate, @updateAuthor, @updateDate)

		INSERT INTO dbo.Candidates(Id, Name, LastName, OpinionBrief, Votes, CreationAuthor, CreationDate, UpdateAuthor, UpdateDate)
		VALUES (newid(), 'Pavel', 'Urputný', 'Chce postavit most a silnici k němu', 0, @creationAuthor, @creationDate, @updateAuthor, @updateDate)

		INSERT INTO dbo.Candidates(Id, Name, LastName, OpinionBrief, Votes, CreationAuthor, CreationDate, UpdateAuthor, UpdateDate)
		VALUES (newid(), 'Josef', 'Nebohatý', 'Nechce psotavit nic, chce peníze', 0, @creationAuthor, @creationDate, @updateAuthor, @updateDate)

END TRY
BEGIN CATCH
	PRINT ERROR_MESSAGE();
END CATCH