CREATE TABLE [dbo].[TBDestinatario]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Nome] VARCHAR(50) NULL, 
    [Cnpj] VARCHAR(50) NULL , 
    [Cpf] VARCHAR(50) NULL , 
    [RazaoSocial] VARCHAR(50) NULL, 
    [InscricaoEstadual] VARCHAR(50) NOT NULL, 
    [IdEndereco] INT NOT NULL, 
    CONSTRAINT [FK_TBDestinatario_TBEndereco] FOREIGN KEY ([IdEndereco]) REFERENCES [TBEndereco]([Id])
)
