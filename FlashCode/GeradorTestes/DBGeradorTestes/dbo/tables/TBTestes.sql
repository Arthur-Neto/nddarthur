CREATE TABLE [dbo].[TBTestes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DataGeracao] DATETIME NOT NULL, 
    [Descricao] TEXT NOT NULL, 
    [QuantidadeQuestoes] INT NOT NULL 
)
