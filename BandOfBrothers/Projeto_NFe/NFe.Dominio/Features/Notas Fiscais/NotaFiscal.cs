using NFe.Dominio.Base;
using NFe.Dominio.Features.Destinatarios;
using NFe.Dominio.Features.Emitentes;
using NFe.Dominio.Features.Produtos;
using NFe.Dominio.Features.Transportadores;
using NFe.Dominio.Features.Valores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Dominio.Features.Notas_Fiscais
{
    public class NotaFiscal : Entidade
    {
        public NotaFiscal()
        {
            Produtos = new List<Produto>();
            Valor = new ValorNota();
            DataEntrada = DateTime.Now;
        }

        public virtual string NotaFiscalXml { get; set; }
        public string NaturezaOperacao { get; set; }
        public DateTime? DataEmissao { get; set; }
        public DateTime DataEntrada { get; set; }
        public string ChaveAcesso { get; set; }
        public bool Emitido { get; set; }
        public IList<Produto> Produtos { get; set; }
        public ValorNota Valor { get; set; }
        public Destinatario Destinatario { get; set; }
        public Emitente Emitente { get; set; }
        public Transportador Transportador { get; set; }

        public int CodigoUfSC = 42;
        public int ModeloNFe = 55;

        Random rnd = new Random();

        public void Emitir()
        {
            Emitido = true;
            DataEmissao = DateTime.Now;
            UnirProdutosIguais();
            CalcularValoresProdutos();
            Valor.CalcularICMS();
            Valor.CalcularIpi();
            Valor.CalcularValorNota();
        }

        private void UnirProdutosIguais()
        {
            var produtosAgrupados = Produtos
                .GroupBy(itemId => itemId.Id)
                .Select(prod => new Produto
                {
                    Id = prod.Key,
                    Quantidade = prod.Sum(prodQtd => prodQtd.Quantidade),
                    CodigoProduto = prod.First().CodigoProduto,
                    Descricao = prod.First().Descricao,
                    ValorProduto = new ValorProduto()
                    {
                        ICMS = prod.First().ValorProduto.ICMS,
                        Ipi = prod.First().ValorProduto.Ipi,
                        Total = prod.First().ValorProduto.Total,
                        Unitario = prod.First().ValorProduto.Unitario
                    }
                });
            Produtos = produtosAgrupados.ToList();
        }

        private void CalcularValoresProdutos()
        {
            foreach (var produto in Produtos)
            {
                produto.CalcularValorTotal();
                produto.ValorProduto.CalcularICMS();
                produto.ValorProduto.CalcularIpi();
                Valor.TotalProdutos += produto.ValorProduto.Total;
            }
        }

        public void GerarChaveAcesso()
        {
            string NumeroAleatorio = ((long)rnd.Next(0, 100000) * (long)rnd.Next(0, 100000)).ToString().PadLeft(10, '0');
            ChaveAcesso = string.Concat(CodigoUfSC, DataEntrada.Year, DataEntrada.Month, Emitente.Cnpj.valorFormatado, ModeloNFe, NumeroAleatorio);
        }
        
        private void GerarTransportador()
        {
            Transportador = new Transportador();

            Transportador.Nome = Destinatario.Nome;
            Transportador.RazaoSocial = Destinatario.RazaoSocial;
            Transportador.Cnpj = Destinatario.Cnpj;
            Transportador.Cpf = Destinatario.Cpf;
            Transportador.Endereco = Destinatario.Endereco;
            Transportador.InscricaoEstadual = Destinatario.InscricaoEstadual;
            Transportador.ResponsabilidadeFrete = Frete.DESTINATARIO;
        }

        public override void Validar()
        {
            if (Emitente == null)
                throw new NotaFiscalEmitenteVazioException();
            if (Destinatario == null)
                throw new NotaFiscalDestinatarioVazioException();
            if (Transportador == null)
                GerarTransportador();

            Emitente.Validar();
            Destinatario.Validar();
            Transportador.Validar();
            foreach (var produto in Produtos)
                produto.Validar();
            if ((Emitente.Cnpj.EhValido && Destinatario.Cnpj.EhValido && Emitente.Cnpj.Equals(Destinatario.Cnpj)) ||
                (Emitente.Cpf.EhValido && Destinatario.Cpf.EhValido && Emitente.Cpf.Equals(Destinatario.Cpf)))
                throw new NotaFiscalEmitenteEqualsDestinatarioException();
            if (Emitido)
                if (DataEntrada > DataEmissao)
                    throw new NotaFiscalDataEntradaOverflowException();
        }
    }
}
