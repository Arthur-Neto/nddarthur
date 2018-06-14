CREATE TABLE [dbo].[TBNotaFiscal]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NaturezaOperacao] VARCHAR(50) NOT NULL, 
    [DataEmissao] DATETIME NULL, 
    [DataEntrada] DATETIME NOT NULL, 
    [ChaveAcesso] VARCHAR(50) NOT NULL, 
    [Emitido] BIT NOT NULL, 
    [ValorFrete] DECIMAL(28, 3) NULL, 
    [TotalProdutos] DECIMAL(28, 3) NULL, 
    [TotalNota] DECIMAL(28, 3) NULL, 
    [ImpostoICMS] DECIMAL(28, 3) NULL, 
    [ImpostoIPI] DECIMAL(28, 3) NULL, 
    [IdDestinatario] INT NOT NULL, 
    [IdEmitente] INT NOT NULL, 
    [IdTransportador] INT NOT NULL, 
    [XmlNota] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_TBNotaFiscal_TBDestinatario] FOREIGN KEY (IdDestinatario) REFERENCES TBDestinatario(Id), 
    CONSTRAINT [FK_TBNotaFiscal_TBEmitente] FOREIGN KEY (IdEmitente) REFERENCES TBEmitente(Id), 
    CONSTRAINT [FK_TBNotaFiscal_TBTransportador] FOREIGN KEY (IdTransportador) REFERENCES TBTransportador(Id)
)
