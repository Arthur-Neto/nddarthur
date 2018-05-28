CREATE TABLE [dbo].[Concurso]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Data] DATETIME NOT NULL, 
    [IsFechado] BIT NOT NULL, 
    [Premio] REAL NOT NULL, 
    [IdResultado] INT NULL, 
    [PremioQuadra] REAL NOT NULL, 
    [PremioQuina] REAL NOT NULL, 
    [PremioSena] REAL NOT NULL, 
    [GanhadoresQuadra] INT NOT NULL, 
    [GanhadoresQuina] INT NOT NULL, 
    [GanhadoresSena] INT NOT NULL
)
