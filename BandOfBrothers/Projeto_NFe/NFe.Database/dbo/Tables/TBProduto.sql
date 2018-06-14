CREATE TABLE [dbo].[TBProduto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CodigoProduto] INT NOT NULL, 
    [Descricao] VARCHAR(50) NOT NULL, 
    [Quantidade] INT NOT NULL, 
    [ValorTotal] DECIMAL(28, 3) NOT NULL, 
    [ValorUnitario] DECIMAL(28, 3) NOT NULL, 
    [ImpostoICMS] DECIMAL(28, 3) NOT NULL, 
    [ImpostoIpi] DECIMAL(28, 3) NOT NULL
)
