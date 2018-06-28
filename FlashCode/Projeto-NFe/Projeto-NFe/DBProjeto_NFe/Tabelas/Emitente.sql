CREATE TABLE [dbo].[Emitente]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [NomeFantasia] VARCHAR(50) NOT NULL, 
    [RazaoSocial] VARCHAR(50) NOT NULL, 
    [CNPJ] VARCHAR(50) NOT NULL, 
    [InscricaoEstadual] VARCHAR(50) NULL, 
    [InscricaoMunicipal] VARCHAR(50) NULL, 
    [EnderecoID] BIGINT NOT NULL, 
    CONSTRAINT [FK_Endereco_Emitente] FOREIGN KEY ([EnderecoID]) REFERENCES [Endereco]([Id])
)
