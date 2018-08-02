CREATE TABLE [dbo].[Compromisso_Contato]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdContato] INT NOT NULL, 
    [IdCompromisso] INT NOT NULL, 
    CONSTRAINT [FK_Compromisso_Contato_Contato] FOREIGN KEY ([IdContato]) REFERENCES [Contato]([Id]), 
    CONSTRAINT [FK_Compromisso_Contato_Compromisso] FOREIGN KEY ([IdCompromisso]) REFERENCES [Compromisso]([Id])
)
