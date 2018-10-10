using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static NotaFiscal PegarNotaFiscalValida(Emitente emitente, Destinatario destinatario, Transportador transportador)
        {
            return new NotaFiscal
            {
                ValorTotalICMS = 90,
                ValorTotalIPI = 10,
                ValorTotalFrete = 50,
                ValorTotalNota = 1000,
                ValorTotalProdutos = 800,
                ValorTotalImpostos = 100,
                NaturezaOperacao = "Natureza",
                DataEntrada = DateTime.Now,
                Destinatario = destinatario,
                Emitente = emitente,
                Transportador = transportador
            };
        }

        public static NotaFiscal PegarNotaFiscalValidaComIdDasDependencias(long idEmitente, long idDestinatario, long idTransportador)
        {
            return new NotaFiscal
            {
                ValorTotalICMS = 90,
                ValorTotalIPI = 10,
                ValorTotalFrete = 50,
                ValorTotalNota = 1000,
                ValorTotalProdutos = 800,
                ValorTotalImpostos = 100,
                NaturezaOperacao = "Natureza",
                DataEntrada = DateTime.Now,
                Destinatario = new Destinatario { Id = idDestinatario },
                Emitente = new Emitente { Id = idEmitente },
                Transportador = new Transportador { Id = idTransportador }
            };
        }

        public static NotaFiscal PegarNotaFiscalSemTransportador(Emitente emitente, Destinatario destinatario)
        {
            return new NotaFiscal
            {
                ValorTotalICMS = 90,
                ValorTotalIPI = 10,
                ValorTotalFrete = 50,
                ValorTotalNota = 1000,
                ValorTotalProdutos = 800,
                ValorTotalImpostos = 100,
                NaturezaOperacao = "Natureza",
                DataEntrada = DateTime.Now,
                Destinatario = destinatario,
                Emitente = emitente
            };
        }

        public static NotaFiscal PegarNotaFiscalSemDestinatario(Emitente emitente, Transportador transportador)
        {
            return new NotaFiscal
            {
                ValorTotalICMS = 90,
                ValorTotalIPI = 10,
                ValorTotalFrete = 50,
                ValorTotalNota = 1000,
                ValorTotalProdutos = 800,
                ValorTotalImpostos = 100,
                NaturezaOperacao = "Natureza",
                DataEntrada = DateTime.Now,
                Emitente = emitente,
                Transportador = transportador
            };
        }

        public static NotaFiscal PegarNotaFiscalSemEmitente(Destinatario destinatario, Transportador transportador)
        {
            return new NotaFiscal
            {
                ValorTotalICMS = 90,
                ValorTotalIPI = 10,
                ValorTotalFrete = 50,
                ValorTotalNota = 1000,
                ValorTotalProdutos = 800,
                ValorTotalImpostos = 100,
                NaturezaOperacao = "Natureza",
                DataEntrada = DateTime.Now,
                Destinatario = destinatario,
                Transportador = transportador
            };
        }

        public static NotaFiscal PegarNotaFiscalSemNaturezaOperacao(Emitente emitente, Destinatario destinatario, Transportador transportador)
        {
            return new NotaFiscal
            {
                ValorTotalICMS = 90,
                ValorTotalIPI = 10,
                ValorTotalFrete = 50,
                ValorTotalNota = 1000,
                ValorTotalProdutos = 800,
                ValorTotalImpostos = 100,
                NaturezaOperacao = "",
                DataEntrada = DateTime.Now,
                Destinatario = destinatario,
                Emitente = emitente,
                Transportador = transportador
            };
        }

        public static NotaFiscal PegarNotaFiscalValidaComListaDeProdutos(Emitente emitente, Destinatario destinatario, Transportador transportador, List<ProdutoNotaFiscal> produtos)
        {
            return new NotaFiscal
            {
                ChaveAcesso = "1111111111111111111111111111111111111111111",
                ValorTotalICMS = 90,
                ValorTotalIPI = 10,
                ValorTotalFrete = 50,
                ValorTotalNota = 1000,
                ValorTotalProdutos = 800,
                ValorTotalImpostos = 100,
                NaturezaOperacao = "Natureza",
                DataEntrada = DateTime.Now,
                Destinatario = destinatario,
                Emitente = emitente,
                Transportador = transportador,
                Produtos = produtos
            };
        }
    }
}
