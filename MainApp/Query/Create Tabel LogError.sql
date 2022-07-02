-- EntitiesModel.ErrorLog
CREATE TABLE [ErrorLog] (
    [ErrorText] text NULL,                  -- _errorText
    [FormName] varchar(50) NULL,            -- _formName
    [HostName] varchar(50) NULL,            -- _hostName
    [ID] int IDENTITY NOT NULL,             -- _iD
    [ModulName] varchar(50) NULL,           -- _modulName
    [QueryText] text NULL,                  -- _queryText
    CONSTRAINT [pk_ErrorLog] PRIMARY KEY ([ID])
)


