CREATE TABLE [dbo].[Aposta]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Numeros] VARCHAR(50) NOT NULL, 
    [Data] DATETIME NOT NULL, 
    [IdConcurso] INT NOT NULL, 
    [Validade] DATETIME NOT NULL, 
    [Valor] FLOAT NOT NULL, 
    [IdBolao] INT NULL, 
    CONSTRAINT [FK_Aposta_Concurso] FOREIGN KEY ([IdConcurso]) REFERENCES [Concurso]([Id]), 
    CONSTRAINT [FK_Aposta_Bolao] FOREIGN KEY ([IdBolao]) REFERENCES [Bolao]([Id])
)
