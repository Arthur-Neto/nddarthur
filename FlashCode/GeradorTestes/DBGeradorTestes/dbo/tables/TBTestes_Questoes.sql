CREATE TABLE [dbo].[TBTestes_Questoes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [QuestaoID] INT NOT NULL, 
    [TesteID] INT NOT NULL, 
    CONSTRAINT [FK_TestesQuestao] FOREIGN KEY ([QuestaoID]) REFERENCES [TBQuestoes]([ID]), 
    CONSTRAINT [FK_TBTestes_Testes] FOREIGN KEY ([TesteID]) REFERENCES [TBTestes]([ID])
)
