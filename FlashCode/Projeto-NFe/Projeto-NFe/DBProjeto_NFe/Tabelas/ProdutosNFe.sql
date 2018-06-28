CREATE TABLE [dbo].[ProdutosNFe]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Quantidade] BIGINT NOT NULL, 
    [ProdutoID] BIGINT NOT NULL, 
    [NotaFiscalID] BIGINT NOT NULL, 
    [ValorICMS] DECIMAL(18, 2) NOT NULL, 
    [ValorIPI] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_ProdutosNFe_Produtos] FOREIGN KEY ([ProdutoID]) REFERENCES [Produto]([Id]), 
    CONSTRAINT [FK_ProdutosNFe_NotasFiscais] FOREIGN KEY ([NotaFiscalID]) REFERENCES [NotaFiscal]([Id])
)
