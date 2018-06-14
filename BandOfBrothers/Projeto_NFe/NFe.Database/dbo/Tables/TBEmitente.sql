CREATE TABLE [dbo].[TBEmitente]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(50) NOT NULL, 
    [RazaoSocial] VARCHAR(50) NOT NULL, 
    [Cpf] VARCHAR(50) NULL, 
    [Cnpj] VARCHAR(50) NULL, 
    [InscricaoEstadual] VARCHAR(50) NOT NULL, 
    [InscricaoMunicipal] VARCHAR(50) NOT NULL, 
    [IdEndereco] INT NOT NULL, 
    CONSTRAINT [FK_TBEmitente_TBEndereco] FOREIGN KEY (IdEndereco) REFERENCES [TBEndereco]([Id])
)
