CREATE TABLE [dbo].[TBResultado]
(
	[Id] INT NOT NULL IDENTITY, 
    [Nota] NCHAR(10) NOT NULL, 
    [IdAluno] INT NOT NULL, 
    CONSTRAINT [PK_TBResultado] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_TBResultado_TBAluno] FOREIGN KEY ([IdAluno]) REFERENCES [TBResultado]([Id]) 
)
