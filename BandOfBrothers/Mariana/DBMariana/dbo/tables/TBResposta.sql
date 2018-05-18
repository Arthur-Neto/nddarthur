CREATE TABLE [dbo].[TBResposta]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [IdQuestao] INT NOT NULL, 
    [CorpoResposta] VARCHAR(100) NOT NULL, 
    [Correta] BIT NOT NULL, 
    CONSTRAINT [FK_TBResposta_TBQuestao] FOREIGN KEY ([IdQuestao]) REFERENCES [TBQuestao]([Id])
)
