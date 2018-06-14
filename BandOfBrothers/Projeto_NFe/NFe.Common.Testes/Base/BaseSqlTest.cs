using NFe.Infra;

namespace NFe.Common.Testes.Base
{
    public static class BaseSqlTest
    {
        #region Sql Endereco
        private const string DELETE_ENDERECO_TABLE = "DELETE FROM [dbo].[TBEndereco] DBCC CHECKIDENT('[dbo].[TBEndereco]', RESEED, 0)";

        private const string INSERT_ENDERECO = "Insert into TBEndereco(Bairro,Estado,Logradouro,Municipio,Numero,Pais)values('@Bairro','@Estado','@Logradouro','@Municipio','@Numero','@Pais')";
        private const string INSERT_ENDERECOSEMVINCULO = "Insert into TBEndereco(Bairro,Estado,Logradouro,Municipio,Numero,Pais)values('@Bairro1','@Estado1','@Logradouro1','@Municipio1','@Numero1','@Pais1')";
        #endregion

        #region Sql Transportador
        private const string DELETE_TRANSPORTADOR_TABLE = "DELETE FROM [dbo].[TBTransportador] DBCC CHECKIDENT('[dbo].[TBTransportador]', RESEED, 0)";

        private const string INSERT_TRANSPORTADOR = "Insert into TBTransportador(Cnpj,Cpf,InscricaoEstadual,Nome,RazaoSocial,ResponsabilidadeFrete,IdEndereco)values('06255692000103', '05919707917','12345678','NDD','NDDIGITAL - SOFTWARE LTDA',0,1)";

        private const string INSERT_TRANSPORTADOR_FRETE_DESTINATARIO = "Insert into TBTransportador(Cnpj,Cpf,InscricaoEstadual,Nome,RazaoSocial,ResponsabilidadeFrete, IdEndereco)values('06255692000103', '05919707917','12345678','NDD','NDDIGITAL - SOFTWARE LTDA',1,1)";
        #endregion

        #region Sql Emitente
        private const string INSERT_EMITENTE = "INSERT INTO TBEmitente(Nome, RazaoSocial, Cpf, Cnpj, InscricaoEstadual, InscricaoMunicipal, IdEndereco ) VALUES('Fulano CIA', 'Fulano LTDA', '05919707917', '06255692000103', '12345678', '987654321', 1)";
        private const string DELETE_EMITENTE_TABLE = "DELETE FROM TBEmitente DBCC CHECKIDENT('[dbo].[TBEmitente]', RESEED, 0)";
        #endregion

        #region Sql Destinatario
        private const string DELETE_DESTINATARIO_TABLE = "DELETE FROM TBDestinatario DBCC CHECKIDENT('[dbo].[TBDestinatario]', RESEED, 0)";
        private const string INSERT_DESTINTARIO = "INSERT INTO TBDestinatario (Nome, Cpf, Cnpj, InscricaoEstadual, IdEndereco) VALUES('FulanoSS', '05919707917', '06255692000103', '1234345634634', 1)";
        #endregion

        #region Sql Produto
        private const string DELETE_PRODUTO_TABLE = "DELETE FROM TBProduto DBCC CHECKIDENT('[dbo].[TBProduto]', RESEED, 0)";
        private const string INSERT_PRODUTO = "INSERT INTO TBProduto (CodigoProduto, Descricao, Quantidade, ValorTotal, ValorUnitario, ImpostoICMS, ImpostoIpi) VALUES(12345, 'Arroz', 50, 5000, 10, 1, 0.5)";
        #endregion

        #region Sql Nota Fiscal
        private const string DELETE_NOTAFISCAL_TABLE = "DELETE FROM TBNotaFiscal DBCC CHECKIDENT('[dbo].[TBNotaFiscal]', RESEED, 0)";
        private const string INSERT_NOTAFISCAL = "INSERT INTO TBNotaFiscal (NaturezaOperacao, DataEmissao, DataEntrada, ChaveAcesso, Emitido, ValorFrete, TotalProdutos, TotalNota, ImpostoICMS, ImpostoIPI, IdDestinatario, IdEmitente, IdTransportador, XmlNota) VALUES('Venda', '2018-01-10', '2018-01-01', '1234567890', 1, 50.5, 5000.0, 2000.0, 300.0, 250.0, 2, 2, 2, '<?xml version=\"1.0\" encoding=\"utf-8\"?><NFe xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><infNFe Id=\"NFe422018606255692000103550311161440\" Versao=\"3.10\"><ide><natOp>Venda</natOp><dhEmi>2018-06-12T14:30:37.4005699-03:00</dhEmi></ide><emit><CNPJ>06255692000103</CNPJ><xNome>Vendedor ETC</xNome><xFant>Fulano LTDA</xFant><IE>123456789</IE><IM>1234567890</IM><enderEmit><xLgr>Coronel Zeca Athanasio</xLgr><nro>547</nro><xBairro>Sagrado Coração de Jesus</xBairro><xMun>Lages</xMun><UF>SC</UF><xPais>Brasil</xPais></enderEmit></emit><dest><CNPJ>06255692000286</CNPJ><xNome>FuladoX</xNome><indIEDest>1234567890</indIEDest><enderDest><xLgr>Coronel Zeca Athanasio</xLgr><nro>547</nro><xBairro>Sagrado Coração de Jesus</xBairro><xMun>Lages</xMun><UF>SC</UF><xPais>Brasil</xPais></enderDest></dest><det><det nItem=\"1\"><prod><cProd>12345</cProd><xProd>Trib ICMS Integral Aliquota 10.00 - PIS e COFINS cod 04 - Orig 0</xProd><qCom>1</qCom><vUnCom>15.0</vUnCom><vProd>0</vProd></prod><imposto><ICMS><ICMS00><pICMS>0</pICMS><vICMS>0</vICMS></ICMS00></ICMS></imposto></det><det nItem=\"2\"><prod><cProd>12345</cProd><xProd>Trib ICMS Integral Aliquota 10.00 - PIS e COFINS cod 04 - Orig 0</xProd><qCom>1</qCom><vUnCom>15.0</vUnCom><vProd>0</vProd></prod><imposto><ICMS><ICMS00><pICMS>0</pICMS><vICMS>0</vICMS></ICMS00></ICMS></imposto></det></det><total><ICMSTot><vICMS>0</vICMS><vFrete>0</vFrete><vIPI>0</vIPI><vNF>0</vNF><vTotTrib>0</vTotTrib></ICMSTot></total><transp><modFrete>0</modFrete><transporta><CNPJ>05919707917</CNPJ><xNome>Fulano LTDA</xNome><IE>987654321</IE><xEnder>Coronel Zeca Athanasio</xEnder><xMun>Lages</xMun><UF>SC</UF></transporta></transp></infNFe></NFe>')";
        private const string INSERT_DESTINTARIO_VINCULO_NOTA = "INSERT INTO TBDestinatario (Nome, Cpf, InscricaoEstadual, IdEndereco) VALUES('FulanoSS', '1234567890', '1234345634634', 1)";
        private const string INSERT_EMITENTEVINCULO_NOTA = "INSERT INTO TBEmitente(Nome, RazaoSocial, Cpf, Cnpj, InscricaoEstadual, InscricaoMunicipal, IdEndereco ) VALUES('Fulano CIA', 'Fulano LTDA', '05919707917', '06255692000103', '12345678', '987654321', 1)";
        private const string INSERT_TRANSPORTADORVINCULO_NOTA = "Insert into TBTransportador(Cnpj,Cpf,InscricaoEstadual,Nome,RazaoSocial,ResponsabilidadeFrete,IdEndereco)values('06255692000103', '05919707917','12345678','NDD','NDDIGITAL - SOFTWARE LTDA',0,1)";
        #endregion

        public static void SeedDatabase()
        {
            Db.Update(DELETE_NOTAFISCAL_TABLE);
            Db.Update(DELETE_TRANSPORTADOR_TABLE);
            Db.Update(DELETE_EMITENTE_TABLE);
            Db.Update(DELETE_DESTINATARIO_TABLE);
            Db.Update(DELETE_ENDERECO_TABLE);
            Db.Update(DELETE_PRODUTO_TABLE);
            

            Db.Update(INSERT_ENDERECO);
            Db.Update(INSERT_ENDERECOSEMVINCULO);

            Db.Update(INSERT_TRANSPORTADOR);
            Db.Update(INSERT_TRANSPORTADOR_FRETE_DESTINATARIO);

            Db.Update(INSERT_EMITENTE);

            Db.Update(INSERT_DESTINTARIO);

            Db.Update(INSERT_PRODUTO);

            Db.Update(INSERT_DESTINTARIO_VINCULO_NOTA);
            Db.Update(INSERT_EMITENTEVINCULO_NOTA);
            Db.Update(INSERT_TRANSPORTADORVINCULO_NOTA);
            Db.Update(INSERT_NOTAFISCAL);
        }
    }
}
