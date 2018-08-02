CREATE TABLE [dbo].[TBResultado_Avaliacao]
(
	[Id] INT NOT NULL IDENTITY , 
    [IdResultado] INT NOT NULL, 
    [IdAvaliacao] INT NOT NULL, 
    CONSTRAINT [PK_TBResultado_Avaliacao] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_TBResultado_Avaliacao_Resultado] FOREIGN KEY ([IdResultado]) REFERENCES [TBResultado]([Id]), 
    CONSTRAINT [FK_TBResultado_Avaliacao_Avaliacao] FOREIGN KEY ([IdAvaliacao]) REFERENCES [TBAvaliacao]([Id])
)
