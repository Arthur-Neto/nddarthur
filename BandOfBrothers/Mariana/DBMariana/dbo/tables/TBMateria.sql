CREATE TABLE [dbo].[TBMateria]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [IdDisciplina] INT NOT NULL, 
    [IdSerie] INT NOT NULL, 
    [Nome] VARCHAR(100) NOT NULL
)
