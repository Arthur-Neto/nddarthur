using NFe.Dominio.Features.Notas_Fiscais;
using NFe.Dominio.Features.Valores;
using System;

namespace NFe.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static NotaFiscal ObterNotaValida()
        {
            return new NotaFiscal()
            {
                Destinatario = ObtemDestinatarioValido(),
                Emitente = ObterEmitenteValido(),
                NaturezaOperacao = "Venda",
                Produtos = { ObtemProdutoValido(), ObtemProdutoValido() },
                Transportador = ObterTransportadorValidoComCpfENome(),
                DataEntrada = DateTime.Now,
                NotaFiscalXml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><NFe xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><infNFe Versao=\"3.10\" Id=\"NFe422018606255692000103550507548615\"><ide><natOp>Venda</natOp><dhEmi>2018-06-07T13:21:55.3272362-03:00</dhEmi></ide><emit><CNPJ>06255692000103</CNPJ><xNome>Vendedor ETC</xNome><xFant>Fulano LTDA</xFant><indIEDest>123456789</indIEDest><enderEmit><xLgr>Coronel Zeca Athanasio</xLgr><nro>547</nro><xBairro>Sagrado Coração de Jesus</xBairro><xMun>Lages</xMun><UF>Santa Catarina</UF><xPais>Brasil</xPais></enderEmit></emit><dest><CNPJ>06255692000104</CNPJ><xNome>FuladoX</xNome><indIEDest>1234567890</indIEDest><enderDest><xLgr>Coronel Zeca Athanasio</xLgr><nro>547</nro><xBairro>Sagrado Coração de Jesus</xBairro><xMun>Lages</xMun><UF>Santa Catarina</UF><xPais>Brasil</xPais></enderDest></dest><det><det nItem=\"1\"><prod><cProd>12345</cProd><xProd>Trib ICMS Integral Aliquota 10.00 - PIS e COFINS cod 04 - Orig 0</xProd><qCom>1</qCom><vUnCom>15.0</vUnCom><vProd>15.0</vProd></prod><imposto><ICMS><ICMS00><pICMS>0.6</pICMS><vICMS>1.5</vICMS></ICMS00></ICMS></imposto></det><det nItem=\"2\"><prod><cProd>12345</cProd><xProd>Trib ICMS Integral Aliquota 10.00 - PIS e COFINS cod 04 - Orig 0</xProd><qCom>1</qCom><vUnCom>15.0</vUnCom><vProd>15.0</vProd></prod><imposto><ICMS><ICMS00><pICMS>0.6</pICMS><vICMS>1.5</vICMS></ICMS00></ICMS></imposto></det></det><total><ICMSTot><vICMS>0</vICMS><vFrete>0</vFrete><vIPI>0</vIPI><vNF>0</vNF><vTotTrib>0</vTotTrib></ICMSTot></total></infNFe></NFe>"
            };
        }

        public static NotaFiscal ObterNotaValidaComCpfeNome()
        {
            return new NotaFiscal()
            {
                Destinatario = ObtemDestinatarioCnpjVazio(),
                Emitente = ObterEmitenteValido(),
                NaturezaOperacao = "Venda",
                Produtos = { ObtemProdutoValido(), ObtemProdutoValido() },
                Transportador = ObterTransportadorValidoComCpfENome(),
                DataEntrada = DateTime.Now
            };
        }


        public static NotaFiscal ObterNotaValidaSemTransportador()
        {
            return new NotaFiscal()
            {
                Destinatario = ObtemDestinatarioCnpjVazio(),
                Emitente = ObterEmitenteValido(),
                NaturezaOperacao = "Venda",
                Produtos = { ObtemProdutoValido(), ObtemProdutoValido() },
                DataEntrada = DateTime.Now
            };
        }

        public static NotaFiscal ObterNotaValidaComCnpjeRazaoSocial()
        {
            return new NotaFiscal()
            {
                Destinatario = ObtemDestinatarioCpfVazio(),
                Emitente = ObterEmitenteValido(),
                NaturezaOperacao = "Venda",
                Produtos = { ObtemProdutoValido(), ObtemProdutoValido() },
                Transportador = ObterTransportadorValidoComCnpjERazaoSocial(),
                DataEntrada = DateTime.Now
            };
        }

        public static NotaFiscal ObterNotaEmitidaValidaComCnpjRazaoSocial()
        {
            return new NotaFiscal()
            {
                Destinatario = ObtemDestinatarioValidoComCnpjRazaoSocial(),
                Emitente = ObterEmitenteValido(),
                NaturezaOperacao = "Venda",
                Produtos = { ObtemProdutoValido(), ObtemProdutoValido() },
                Transportador = ObterTransportadorValidoComCnpjERazaoSocial(),
                DataEntrada = DateTime.Now.Date,
                DataEmissao = DateTime.Now.Date,
                Valor = new ValorNota()
                {
                    TotalNota = 500,
                    Frete = 10,
                    ICMS = 30,
                    Ipi = 20,
                    TotalProdutos = 400
                },
                Emitido = true
            };
        }

        public static NotaFiscal ObterNotaEmitidaValida()
        {
            return new NotaFiscal()
            {
                Destinatario = ObtemDestinatarioValido(),
                Emitente = ObterEmitenteValido(),
                NaturezaOperacao = "Venda",
                Produtos = { ObtemProdutoValido(), ObtemProdutoValido() },
                Transportador = ObterTransportadorValidoComCnpjERazaoSocial(),
                DataEntrada = DateTime.Now.Date,
                DataEmissao = DateTime.Now.Date,
                Valor = new ValorNota()
                {
                    TotalNota = 500,
                    Frete = 10,
                    ICMS = 30,
                    Ipi = 20,
                    TotalProdutos = 400
                },
                Emitido = true
            };
        }

        public static NotaFiscal ObterNotaEmitidaValidaComCnpj()
        {
            return new NotaFiscal()
            {
                Destinatario = ObtemDestinatarioValidoComCpfERazaoSocial(),
                Emitente = ObterEmitenteValido(),
                NaturezaOperacao = "Venda",
                Produtos = { ObtemProdutoValido(), ObtemProdutoValido() },
                Transportador = ObterTransportadorValidoComCpfENome(),
                DataEntrada = DateTime.Now.Date,
                DataEmissao = DateTime.Now.Date,
                Valor = new ValorNota()
                {
                    TotalNota = 500,
                    Frete = 10,
                    ICMS = 30,
                    Ipi = 20,
                    TotalProdutos = 400
                },
                Emitido = true
            };
        }

        public static NotaFiscal ObterNotaEmitidaValidaComCpf()
        {
            return new NotaFiscal()
            {
                Destinatario = ObtemDestinatarioValidoComCpfERazaoSocial(),
                Emitente = ObterEmitenteValido(),
                NaturezaOperacao = "Venda",
                Produtos = { ObtemProdutoValido(), ObtemProdutoValido() },
                Transportador = ObterTransportadorValidoComCpfENome(),
                DataEntrada = DateTime.Now.Date,
                DataEmissao = DateTime.Now.Date,
                Valor = new ValorNota()
                {
                    TotalNota = 500,
                    Frete = 10,
                    ICMS = 30,
                    Ipi = 20,
                    TotalProdutos = 400
                },
                Emitido = true
            };
        }
        

        public static NotaFiscal ObterNotaComEmitenteIgualDestinatario()
        {
            return new NotaFiscal()
            {
                Destinatario = ObtemDestinatarioNomeVazio(),
                Emitente = ObterEmitenteValido(),
                NaturezaOperacao = "Venda",
                Produtos = { ObtemProdutoValido(), ObtemProdutoValido() },
                Transportador = ObterTransportadorValidoComCpfENome(),
            };
        }

        public static NotaFiscal ObterNotaEmitidaComDataEntradaEMaiorQueDataEmitida()
        {
            return new NotaFiscal()
            {
                Destinatario = ObtemDestinatarioValido(),
                Emitente = ObterEmitenteValido(),
                NaturezaOperacao = "Venda",
                Produtos = { ObtemProdutoValido(), ObtemProdutoValido() },
                Transportador = ObterTransportadorValidoComCpfENome(),
                Emitido = true
            };
        }
    }
}
