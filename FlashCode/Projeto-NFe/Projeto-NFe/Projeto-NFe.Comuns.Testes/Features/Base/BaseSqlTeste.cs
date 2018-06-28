using Projeto_NFe.Infra.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Comuns.Testes.Features.Base
{
    public static class BaseSqlTeste
    {
        //Deletar
        private const string DELETAR_ENDERECO = @"DELETE FROM Endereco";
        private const string DELETAR_DESTINARARIO = @"DELETE FROM Destinatario";
        private const string DELETAR_EMITENTE = @"DELETE FROM Emitente";
        private const string DELETAR_TRANSPORTADOR = @"DELETE FROM Transportador";
        private const string DELETAR_PRODUTO = @"DELETE FROM Produto";
        private const string DELETAR_NOTAFISCAL = @"DELETE FROM NotaFiscal";
        private const string DELETAR_PRODUTONFE = @"DELETE FROM ProdutosNFe";
        private const string DELETAR_NOTAFISCALEMITIDA = @"DELETE FROM NotaFiscalEmitida";


        //Zerar ID
        private const string ZERAR_ID_ENDERECO = "DBCC CHECKIDENT('Endereco', RESEED, 0)";
        private const string ZERAR_ID_DESTINATARIO = "DBCC CHECKIDENT('Destinatario', RESEED, 0)";
        private const string ZERAR_ID_EMITENTE = "DBCC CHECKIDENT('Emitente', RESEED, 0)";
        private const string ZERAR_ID_TRANSPORTADOR = "DBCC CHECKIDENT('Transportador', RESEED, 0)";
        private const string ZERAR_ID_PRODUTO = "DBCC CHECKIDENT('Produto', RESEED, 0)";
        private const string ZERAR_ID_NOTAFISCAL = "DBCC CHECKIDENT('NotaFiscal', RESEED, 0)";
        private const string ZERAR_ID_PRODUTONFE = "DBCC CHECKIDENT('ProdutosNFe', RESEED, 0)";
        private const string ZERAR_ID_NOTAFISCALEMITIDA = "DBCC CHECKIDENT('NotaFiscalEmitida', RESEED, 0)";

        //Inserir Novo
        private const string INSERIR_ENDERECO = @"INSERT INTO [dbo].[Endereco]([Cep],[Rua],[Bairro],[Cidade],[UF],[Pais],[Numero])VALUES ('88523-060','Rua Dr. Walmor Ribeiro','Coral','Lages','SC','Brasil',431)";
        private const string INSERIR_DESTINATARIO = @"INSERT INTO [dbo].[Destinatario]([Nome],[RazaoSocial],[CPF],[CNPJ],[EnderecoID]) VALUES('José das Coves','José das coves e CIA LTDA','96802413191','47053881000172',1)";
        private const string INSERIR_EMITENTE = @"INSERT INTO [dbo].[Emitente]([NomeFantasia],[RazaoSocial],[CNPJ],[InscricaoEstadual],[InscricaoMunicipal],[EnderecoID]) VALUES('Jose das coves - Vendas de gasolina','Jose das coves e CIA LTDA','47053881000172','123456','234567',1)";
        private const string INSERIR_TRANSPORTADOR = @"INSERT INTO [dbo].[Transportador]([Nome],[RazaoSocial],[CPF],[CNPJ],[EnderecoID],[Responsabilidade_Frete]) VALUES('José das Coves','José das coves e CIA LTDA','96802413191','47053881000172',1,1)";
        private const string INSERIR_PRODUTO = @"INSERT INTO [dbo].[Produto] ([Codigo],[Descricao],[ValorUnitario]) VALUES ('213456','Arroz',123.54)";
        private const string INSERIR_NOTAFISCAL = @"INSERT INTO [dbo].[NotaFiscal]([ValorFrete],[ValorTotalNota],[NaturezaOperacao],[DataEmissao],[DataEntrada],[Chave],[DestinatarioID],[EmitenteID],[TransportadorID]) VALUES (1234.34,123456.23,'Natureza da operação',GETDATE(),GETDATE(),'234563456xcs',1,1,1)";
        private const string INSERIR_PRODUTONFE = @"INSERT INTO[dbo].[ProdutosNFe] ([Quantidade],[ProdutoID],[NotaFiscalID],[ValorICMS],[ValorIPI]) VALUES(123,1,1,123.23,123.33)";
        private const string INSERIR_NOTAFISCALEMITIDA = "insert into NotaFiscalEmitida (Chave, NotaFiscalXML) values ('2241 6012 5845 2734 4330 8800 6670 2528 4401 3375 0538', '<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<NFe xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"Projeto-NFe Academia NDD\">\r\n  <InfNFe Id=\"2241 6012 5845 2734 4330 8800 6670 2528 4401 3375 0538\">\r\n    <ide>\r\n      <natOp>Gestão, Consulta e Downloads de NFs</natOp>\r\n      <dhEmi>17/06/2018 14:13:34</dhEmi>\r\n    </ide>\r\n    <emit>\r\n      <IE>123456789</IE>\r\n      <IM>123456789</IM>\r\n      <EnderEmit>\r\n        <xLgr>Rua Dr. Walmor Ribeiro</xLgr>\r\n        <nro>431</nro>\r\n        <xBairro>Coral</xBairro>\r\n        <xMun>Lages</xMun>\r\n        <UF>SC</UF>\r\n        <xPais>Brasil</xPais>\r\n      </EnderEmit>\r\n    </emit>\r\n    <dest>\r\n      <Cnpj>10.151.618/0001-06</Cnpj>\r\n      <xNome>LLLLLLKL</xNome>\r\n      <indIEDest>1124432</indIEDest>\r\n      <enderDest>\r\n        <xLgr>Rua Dr. Walmor Ribeiro</xLgr>\r\n        <nro>431</nro>\r\n        <xBairro>Coral</xBairro>\r\n        <xMun>Lages</xMun>\r\n        <UF>SC</UF>\r\n        <xPais>Brasil</xPais>\r\n      </enderDest>\r\n    </dest>\r\n    <trans>\r\n      <xNome>razao</xNome>\r\n      <Cnpj>10.151.618/0001-06</Cnpj>\r\n      <enderTrans>\r\n        <xLgr>Rua Dr. Walmor Ribeiro</xLgr>\r\n        <nro>431</nro>\r\n        <xBairro>Coral</xBairro>\r\n        <xMun>Lages</xMun>\r\n        <UF>SC</UF>\r\n        <xPais>Brasil</xPais>\r\n      </enderTrans>\r\n      <indIETrans>1124432</indIETrans>\r\n      <respFrete>false</respFrete>\r\n    </trans>\r\n    <det Id=\"1\">\r\n      <prod>\r\n        <cProd>111111</cProd>\r\n        <xProd>Descrição produto 1</xProd>\r\n        <qCom>11</qCom>\r\n        <vUnCom>111</vUnCom>\r\n        <vProd>1221</vProd>\r\n      </prod>\r\n      <imposto>\r\n        <pICMS>0,04</pICMS>\r\n        <vICMS>11111111</vICMS>\r\n      </imposto>\r\n    </det>\r\n  </InfNFe>\r\n</NFe>')";
        public static void SemearBancoParaNotaFiscal()
        {
            //Deletar
            Db.Delete(DELETAR_PRODUTONFE);
            Db.Delete(DELETAR_NOTAFISCAL);
            Db.Update(DELETAR_DESTINARARIO);
            Db.Update(DELETAR_EMITENTE);
            Db.Update(DELETAR_PRODUTO);
            Db.Update(DELETAR_TRANSPORTADOR);
            Db.Update(DELETAR_ENDERECO);
            Db.Delete(DELETAR_NOTAFISCALEMITIDA);

            //Zerar ID
            Db.Update(ZERAR_ID_PRODUTONFE);
            Db.Update(ZERAR_ID_DESTINATARIO);
            Db.Update(ZERAR_ID_EMITENTE);
            Db.Update(ZERAR_ID_TRANSPORTADOR);
            Db.Update(ZERAR_ID_ENDERECO);
            Db.Update(ZERAR_ID_PRODUTO);
            Db.Update(ZERAR_ID_NOTAFISCAL);
            Db.Update(ZERAR_ID_NOTAFISCALEMITIDA);

            //Inserir Novo
            Db.Update(INSERIR_ENDERECO);
            Db.Update(INSERIR_DESTINATARIO);
            Db.Update(INSERIR_EMITENTE);
            Db.Update(INSERIR_TRANSPORTADOR);
            Db.Update(INSERIR_PRODUTO);
            Db.Update(INSERIR_NOTAFISCAL);
            Db.Update(INSERIR_NOTAFISCAL);
            Db.Update(INSERIR_PRODUTONFE);
            Db.Update(INSERIR_NOTAFISCALEMITIDA);

        }
        public static void SemearBancoParaProduto()
        {
            //Deletar
            Db.Delete(DELETAR_PRODUTONFE);
            Db.Delete(DELETAR_NOTAFISCAL);
            Db.Update(DELETAR_DESTINARARIO);
            Db.Update(DELETAR_EMITENTE);
            Db.Update(DELETAR_PRODUTO);
            Db.Update(DELETAR_TRANSPORTADOR);
            Db.Update(DELETAR_ENDERECO);

            //Zerar ID
            Db.Update(ZERAR_ID_PRODUTONFE);
            Db.Update(ZERAR_ID_DESTINATARIO);
            Db.Update(ZERAR_ID_EMITENTE);
            Db.Update(ZERAR_ID_TRANSPORTADOR);
            Db.Update(ZERAR_ID_ENDERECO);
            Db.Update(ZERAR_ID_PRODUTO);
            Db.Update(ZERAR_ID_NOTAFISCAL);

            //Inserir Novo
            Db.Update(INSERIR_ENDERECO);
            Db.Update(INSERIR_DESTINATARIO);
            Db.Update(INSERIR_EMITENTE);
            Db.Update(INSERIR_TRANSPORTADOR);
            Db.Update(INSERIR_PRODUTO);
            Db.Update(INSERIR_PRODUTO);
            Db.Update(INSERIR_NOTAFISCAL);
            Db.Update(INSERIR_PRODUTONFE);
        }
        public static void SemearBancoParaProdutoNfe()
        {
            //Deletar
            Db.Delete(DELETAR_PRODUTONFE);
            Db.Delete(DELETAR_NOTAFISCAL);
            Db.Update(DELETAR_DESTINARARIO);
            Db.Update(DELETAR_EMITENTE);
            Db.Update(DELETAR_PRODUTO);
            Db.Update(DELETAR_TRANSPORTADOR);
            Db.Update(DELETAR_ENDERECO);

            //Zerar ID
            Db.Update(ZERAR_ID_PRODUTONFE);
            Db.Update(ZERAR_ID_DESTINATARIO);
            Db.Update(ZERAR_ID_EMITENTE);
            Db.Update(ZERAR_ID_TRANSPORTADOR);
            Db.Update(ZERAR_ID_ENDERECO);
            Db.Update(ZERAR_ID_PRODUTO);
            Db.Update(ZERAR_ID_NOTAFISCAL);

            //Inserir Novo
            Db.Update(INSERIR_ENDERECO);
            Db.Update(INSERIR_DESTINATARIO);
            Db.Update(INSERIR_EMITENTE);
            Db.Update(INSERIR_TRANSPORTADOR);
            Db.Update(INSERIR_PRODUTO);
            Db.Update(INSERIR_NOTAFISCAL);
            Db.Update(INSERIR_PRODUTONFE);
        }
        public static void SemearBancoParaDestinatario()
        {
            //Deletar
            Db.Delete(DELETAR_PRODUTONFE);
            Db.Delete(DELETAR_NOTAFISCAL);
            Db.Update(DELETAR_DESTINARARIO);
            Db.Update(DELETAR_EMITENTE);
            Db.Update(DELETAR_PRODUTO);
            Db.Update(DELETAR_TRANSPORTADOR);
            Db.Update(DELETAR_ENDERECO);

            //Zerar ID
            Db.Update(ZERAR_ID_PRODUTONFE);
            Db.Update(ZERAR_ID_DESTINATARIO);
            Db.Update(ZERAR_ID_EMITENTE);
            Db.Update(ZERAR_ID_TRANSPORTADOR);
            Db.Update(ZERAR_ID_ENDERECO);
            Db.Update(ZERAR_ID_PRODUTO);
            Db.Update(ZERAR_ID_NOTAFISCAL);

            //Inserir Novo
            Db.Update(INSERIR_ENDERECO);
            Db.Update(INSERIR_DESTINATARIO);
            Db.Update(INSERIR_DESTINATARIO);
            Db.Update(INSERIR_EMITENTE);
            Db.Update(INSERIR_TRANSPORTADOR);
            Db.Update(INSERIR_PRODUTO);
            Db.Update(INSERIR_NOTAFISCAL);
            Db.Update(INSERIR_PRODUTONFE);
        }
        public static void SemearBancoParaEmitente()
        {
            //Deletar
            Db.Delete(DELETAR_PRODUTONFE);
            Db.Delete(DELETAR_NOTAFISCAL);
            Db.Update(DELETAR_DESTINARARIO);
            Db.Update(DELETAR_EMITENTE);
            Db.Update(DELETAR_PRODUTO);
            Db.Update(DELETAR_TRANSPORTADOR);
            Db.Update(DELETAR_ENDERECO);

            //Zerar ID
            Db.Update(ZERAR_ID_PRODUTONFE);
            Db.Update(ZERAR_ID_DESTINATARIO);
            Db.Update(ZERAR_ID_EMITENTE);
            Db.Update(ZERAR_ID_TRANSPORTADOR);
            Db.Update(ZERAR_ID_ENDERECO);
            Db.Update(ZERAR_ID_PRODUTO);
            Db.Update(ZERAR_ID_NOTAFISCAL);

            //Inserir Novo
            Db.Update(INSERIR_ENDERECO);
            Db.Update(INSERIR_DESTINATARIO);
            Db.Update(INSERIR_EMITENTE);
            Db.Update(INSERIR_EMITENTE);
            Db.Update(INSERIR_TRANSPORTADOR);
            Db.Update(INSERIR_PRODUTO);
            Db.Update(INSERIR_NOTAFISCAL);
            Db.Update(INSERIR_PRODUTONFE);
        }
        public static void SemearBancoParaEndereco()
        {
            //Deletar
            Db.Delete(DELETAR_PRODUTONFE);
            Db.Delete(DELETAR_NOTAFISCAL);
            Db.Update(DELETAR_DESTINARARIO);
            Db.Update(DELETAR_EMITENTE);
            Db.Update(DELETAR_PRODUTO);
            Db.Update(DELETAR_TRANSPORTADOR);
            Db.Update(DELETAR_ENDERECO);

            //Zerar ID
            Db.Update(ZERAR_ID_PRODUTONFE);
            Db.Update(ZERAR_ID_DESTINATARIO);
            Db.Update(ZERAR_ID_EMITENTE);
            Db.Update(ZERAR_ID_TRANSPORTADOR);
            Db.Update(ZERAR_ID_ENDERECO);
            Db.Update(ZERAR_ID_PRODUTO);
            Db.Update(ZERAR_ID_NOTAFISCAL);

            //Inserir Novo
            Db.Update(INSERIR_ENDERECO);
            Db.Update(INSERIR_DESTINATARIO);
            Db.Update(INSERIR_EMITENTE);
            Db.Update(INSERIR_ENDERECO);
            Db.Update(INSERIR_ENDERECO);
            Db.Update(INSERIR_TRANSPORTADOR);
            Db.Update(INSERIR_PRODUTO);
            Db.Update(INSERIR_NOTAFISCAL);
            Db.Update(INSERIR_PRODUTONFE);
        }
        public static void SemearBancoParaTransportador()
        {
            //Deletar
            Db.Delete(DELETAR_PRODUTONFE);
            Db.Delete(DELETAR_NOTAFISCAL);
            Db.Update(DELETAR_DESTINARARIO);
            Db.Update(DELETAR_EMITENTE);
            Db.Update(DELETAR_PRODUTO);
            Db.Update(DELETAR_TRANSPORTADOR);
            Db.Update(DELETAR_ENDERECO);

            //Zerar ID
            Db.Update(ZERAR_ID_PRODUTONFE);
            Db.Update(ZERAR_ID_DESTINATARIO);
            Db.Update(ZERAR_ID_EMITENTE);
            Db.Update(ZERAR_ID_TRANSPORTADOR);
            Db.Update(ZERAR_ID_ENDERECO);
            Db.Update(ZERAR_ID_PRODUTO);
            Db.Update(ZERAR_ID_NOTAFISCAL);

            //Inserir Novo
            Db.Update(INSERIR_ENDERECO);
            Db.Update(INSERIR_DESTINATARIO);
            Db.Update(INSERIR_EMITENTE);
            Db.Update(INSERIR_TRANSPORTADOR);
            Db.Update(INSERIR_TRANSPORTADOR);
            Db.Update(INSERIR_PRODUTO);
            Db.Update(INSERIR_NOTAFISCAL);
            Db.Update(INSERIR_PRODUTONFE);
        }
    }
}
