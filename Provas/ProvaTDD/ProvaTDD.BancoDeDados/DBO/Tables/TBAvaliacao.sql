CREATE TABLE [dbo].[TBAvaliacao]
(
	[Id] INT NOT NULL IDENTITY , 
    [Assunto] VARCHAR(50) NOT NULL, 
    [Data] DATETIME NOT NULL, 
    CONSTRAINT [PK_TBAvaliacao] PRIMARY KEY ([Id])
)
