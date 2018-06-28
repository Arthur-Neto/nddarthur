CREATE TABLE [dbo].[TBQuestoes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Bimestre] NVARCHAR(50) NOT NULL, 
    [MateriaID] INT NOT NULL, 
    [Questao] NVARCHAR(500) NOT NULL, 
    CONSTRAINT [FK_TBQuestoes_ToMaterias] FOREIGN KEY ([MateriaID]) REFERENCES [TBMaterias]([ID]), 

)
