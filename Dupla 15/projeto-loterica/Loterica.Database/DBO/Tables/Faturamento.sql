CREATE TABLE [dbo].[Faturamento]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdConcurso] INT NOT NULL, 
    [ValorGanho] REAL NOT NULL, 
    CONSTRAINT [FK_Faturamento_Concurso] FOREIGN KEY ([IdConcurso]) REFERENCES [Concurso]([Id])
)
