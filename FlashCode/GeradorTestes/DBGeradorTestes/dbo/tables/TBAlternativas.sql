CREATE TABLE [dbo].[TBAlternativas]
(
	[Id] INT NOT NULL PRIMARY KEY identity (1,1), 
    [A] NVARCHAR(100) NOT NULL, 
    [B] NVARCHAR(100) NOT NULL, 
    [C] NVARCHAR(100) NOT NULL, 
    [D] NVARCHAR(100) NOT NULL, 
    [AlternativaCorreta] NCHAR(100) NOT NULL, 
    [QuestaoID] INT NOT NULL, 
    CONSTRAINT [FK_QuestaoID_AlternativaCorreta] FOREIGN KEY (QuestaoID) REFERENCES [TBQuestoes]([ID]),

)
