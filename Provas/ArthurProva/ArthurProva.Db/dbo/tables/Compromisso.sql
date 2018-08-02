CREATE TABLE [dbo].[Compromisso]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Assunto] VARCHAR(50) NOT NULL, 
    [Local] VARCHAR(50) NOT NULL, 
    [DataInicio] DATE NOT NULL, 
    [DataTermino] DATE NULL, 
    [DiaInteiro] BIT NOT NULL 
)
