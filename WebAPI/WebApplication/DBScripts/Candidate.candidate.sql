CREATE TABLE [candidate] (
    [id]      INT             IDENTITY (1, 1) NOT NULL,
    [city]    NVARCHAR (MAX)  NOT NULL,
    [country] NVARCHAR (MAX)  NOT NULL,
	[id_file] [uniqueidentifier] unique ROWGUIDCOL NOT NULL DEFAULT newid(),
    [curriculum_vitae]      VARBINARY (MAX) FILESTREAM NULL,
    [email]   NVARCHAR (MAX)  NOT NULL,
    [state]   NVARCHAR (MAX)  NOT NULL,
    [name]    NVARCHAR (MAX)  NOT NULL,
    CONSTRAINT [PK_candidate] PRIMARY KEY CLUSTERED ([id] ASC)
);