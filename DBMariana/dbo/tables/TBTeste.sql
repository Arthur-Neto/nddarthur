CREATE TABLE [dbo].[TBTeste]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [DataTesteGerado] DATETIME NOT NULL, 
    [Nome] VARCHAR(50) NOT NULL, 
    [IdDisciplina] INT NOT NULL, 
    [IdSerie] INT NOT NULL, 
    [IdMateria] INT NOT NULL, 
    [NumeroQuestoes] INT NOT NULL, 
    [CaminhoDestino] VARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_TBTeste_TBDisciplina] FOREIGN KEY ([IdDisciplina]) REFERENCES [TBDisciplina]([Id]), 
    CONSTRAINT [FK_TBTeste_TBSerie] FOREIGN KEY ([IdSerie]) REFERENCES [TBSerie]([Id]), 
    CONSTRAINT [FK_TBTeste_TBMateria] FOREIGN KEY ([IdMateria]) REFERENCES [TBMateria]([Id])
)
