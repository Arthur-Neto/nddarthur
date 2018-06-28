CREATE TABLE [dbo].[Produto]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Codigo] VARCHAR(50) NOT NULL, 
    [Descricao] VARCHAR(50) NOT NULL, 
    [ValorUnitario] DECIMAL(18, 2) NOT NULL
)
