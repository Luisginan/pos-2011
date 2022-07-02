USE [master]
GO

/****** Object:  StoredProcedure [dbo].[sp_ListFiles]    Script Date: 02/17/2012 22:08:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_ListFiles]
    @PCWrite VARCHAR(2000) ,
    @DBTable VARCHAR(100) = NULL ,
    @PCIntra VARCHAR(100) = NULL ,
    @PCExtra VARCHAR(100) = NULL ,
    @DBUltra BIT = 0
AS 
    SET NOCOUNT ON
    DECLARE @Return INT
    DECLARE @Retain INT
    DECLARE @Status INT
    SET @Status = 0
    DECLARE @Task VARCHAR(2000)
    DECLARE @Work VARCHAR(2000)
    DECLARE @Wish VARCHAR(2000)

    SET @Work = 'DIR ' + '"' + @PCWrite + '"'

    CREATE TABLE #DBAZ
        (
          Name VARCHAR(400) ,
          Work INT IDENTITY(1, 1)
        )

    INSERT  #DBAZ
            EXECUTE @Return = master.dbo.xp_cmdshell @Work

    SET @Retain = @@ERROR

    IF @Status = 0 
        SET @Status = @Retain

    IF @Status = 0 
        SET @Status = @Return

    IF ( SELECT COUNT(*)
         FROM   #DBAZ
       ) < 4 
        BEGIN
            SELECT  @Wish = Name
            FROM    #DBAZ
            WHERE   Work = 1
            IF @Wish IS NULL 
                BEGIN
                    RAISERROR ('General error [%d]',16,1,@Status)
                END
            ELSE 
                BEGIN
                    RAISERROR (@Wish,16,1)
                END
        END
    ELSE 
        BEGIN
            DELETE  #DBAZ
            WHERE   ISDATE(SUBSTRING(Name, 1, 10)) = 0
                    OR SUBSTRING(Name, 40, 1) = '.'
                    OR Name LIKE '%.lnk'
            IF @DBTable IS NULL 
                BEGIN
                    SELECT  SUBSTRING(Name, 40, 100) AS Files
                    FROM    #DBAZ
                    WHERE   0 = 0
                            AND ( @DBUltra = 0
                                  OR Name LIKE '%.SDB%'
                                )
                            AND ( @DBUltra != 0
                                  OR Name NOT LIKE '%.SDB%'
                                )
                            AND ( @PCIntra IS NULL
                                  OR SUBSTRING(Name, 40, 100) LIKE @PCIntra
                                )
                            AND ( @PCExtra IS NULL
                                  OR SUBSTRING(Name, 40, 100) NOT LIKE @PCExtra
                                )
                    ORDER BY 1
                END
            ELSE 
                BEGIN
                    SET @Task = ' INSERT ' + REPLACE(@DBTable, CHAR(32),
                                                     CHAR(95))
                        + ' SELECT SUBSTRING(Name,40,100) AS Files'
                        + ' FROM #DBAZ' + ' WHERE 0 = 0'
                        + CASE WHEN @DBUltra = 0 THEN ''
                               ELSE ' AND Name LIKE ' + CHAR(39) + '% %'
                                    + CHAR(39)
                          END + CASE WHEN @DBUltra != 0 THEN ''
                                     ELSE ' AND Name NOT LIKE ' + CHAR(39)
                                          + '% %' + CHAR(39)
                                END + CASE WHEN @PCIntra IS NULL THEN ''
                                           ELSE ' AND SUBSTRING (Name,40,100) LIKE '
                                                + CHAR(39) + @PCIntra
                                                + CHAR(39)
                                      END + CASE WHEN @PCExtra IS NULL THEN ''
                                                 ELSE ' AND SUBSTRING

(Name,40,100) NOT LIKE ' + CHAR(39) + @PCExtra + CHAR(39)
                                            END + ' ORDER BY 1'
                    IF @Status = 0 
                        EXECUTE (@Task)
                    SET @Return = @@ERROR
                    IF @Status = 0 
                        SET @Status = @Return
                END
        END
    DROP TABLE #DBAZ
    SET NOCOUNT OFF
    RETURN (@Status)

GO

