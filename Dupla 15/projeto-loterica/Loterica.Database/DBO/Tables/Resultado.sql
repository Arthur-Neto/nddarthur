CREATE TABLE [dbo].[Resultado]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NumerosSorteados] VARCHAR(50) NOT NULL, 
    [MediaQuadra] REAL NOT NULL, 
    [MediaQuina] REAL NOT NULL, 
    [MediaSena] REAL NOT NULL 
)
