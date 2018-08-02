CREATE TABLE [dbo].[TBAluno]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Nome] VARCHAR(50) NOT NULL, 
    [Media] FLOAT NOT NULL, 
    [Idade] INT NOT NULL, 
    CONSTRAINT [PK_TBAluno] PRIMARY KEY ([Id])
)
