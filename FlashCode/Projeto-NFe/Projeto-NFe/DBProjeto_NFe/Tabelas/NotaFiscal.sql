CREATE TABLE [dbo].[NotaFiscal]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [ValorFrete] DECIMAL(18, 2) NOT NULL, 
    [ValorTotalNota] DECIMAL(18, 2) NOT NULL, 
    [NaturezaOperacao] VARCHAR(MAX) NOT NULL, 
    [DataEmissao] DATETIME NOT NULL, 
    [DataEntrada] DATETIME NOT NULL, 
    [Chave] VARCHAR(60) NOT NULL, 
    [DestinatarioID] BIGINT NOT NULL, 
    [EmitenteID] BIGINT NOT NULL, 
    [TransportadorID] BIGINT NOT NULL
)
