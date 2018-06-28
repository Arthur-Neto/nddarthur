CREATE TABLE [dbo].[Transportador]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(50) NULL, 
    [RazaoSocial] VARCHAR(50) NULL, 
    [CPF] VARCHAR(50) NULL, 
    [CNPJ] VARCHAR(50) NULL, 
    [EnderecoID] BIGINT NOT NULL,
	[Responsabilidade_Frete] BIT NOT NULL,
    CONSTRAINT [FK_Endereco_Transportador] FOREIGN KEY ([EnderecoID]) REFERENCES [Endereco]([Id])
)
