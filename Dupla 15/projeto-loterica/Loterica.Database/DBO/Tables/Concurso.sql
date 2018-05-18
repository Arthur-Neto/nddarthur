CREATE TABLE [dbo].[Concurso]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Data] DATETIME NOT NULL, 
    [IsFechado] BIT NOT NULL, 
    [Premio] REAL NOT NULL, 
    [IdResultado] INT NULL
)
