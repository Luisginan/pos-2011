USE [master]
GO

/****** Object:  StoredProcedure [dbo].[RestoreDB]    Script Date: 02/17/2012 22:08:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Luis
-- Create date: 11-2-2012
-- Description:	Backup Database mandiri
-- =============================================
CREATE PROCEDURE [dbo].[RestoreDB]
	-- Add the parameters for the stored procedure here
	@Path varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	RESTORE DATABASE [Mandiri] 
	FROM  DISK = @Path
	WITH
		REPLACE,
		RECOVERY,
		STATS=10
END

GO

