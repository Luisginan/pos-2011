USE [master]
GO

/****** Object:  StoredProcedure [dbo].[BackupDB]    Script Date: 02/17/2012 22:05:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Luis
-- Create date: 11-2-2012
-- Description:	Backup Database mandiri
-- =============================================
CREATE PROCEDURE [dbo].[BackupDB]
	-- Add the parameters for the stored procedure here
	@Path varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BACKUP DATABASE [Mandiri] TO  
	DISK = @Path
	WITH NOFORMAT, NOINIT,  NAME = N'mandiri-Full Database Backup', 
	SKIP, NOREWIND, NOUNLOAD,  STATS = 10
END

GO

