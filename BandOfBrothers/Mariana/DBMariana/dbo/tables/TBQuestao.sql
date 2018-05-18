CREATE TABLE [dbo].[TBQuestao]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [IdMateria] INT NOT NULL, 
    [Enunciado] VARCHAR(250) NOT NULL, 
    [Bimestre] INT NOT NULL, 
    [IdDisciplina] INT NOT NULL, 
    CONSTRAINT [FK_TBQuestao_TBMateria] FOREIGN KEY ([IdMateria]) REFERENCES [TBMateria]([Id]), 
    CONSTRAINT [FK_TBQuestao_TBDisciplina] FOREIGN KEY ([IdDisciplina]) REFERENCES [TBDisciplina]([Id]) 
)
