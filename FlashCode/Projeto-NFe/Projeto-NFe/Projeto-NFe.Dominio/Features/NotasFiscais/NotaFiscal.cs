using System;
using Projeto_NFe.Dominio.Base;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Transportadores;
using System.Collections.Generic;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes;

namespace Projeto_NFe.Dominio.Features.NotasFiscais
{
    public class NotaFiscal : Entidade
    {
        public double ValorFrete { get; set; }
        public double ValorTotalNota { get; set; }
        public double ValorTotalProdutos { get; set; }
        public string NaturezaOperacao { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataEntrada { get; set; }
        public virtual string Chave { get; set; }
        public Destinatario Destinatario { get; set; }
        public Emitente Emitente { get; set; }
        public Transportador Transportador { get; set; }
        public List<ProdutoNfe> Produtos { get; set; }

        public NotaFiscal()
        {

        }
        public virtual void GerarChave(Random random)
        {
            Chave = "";
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Chave += random.Next(0, 9);
                }

                Chave += " ";
            }

            Chave = Chave.Substring(0, Chave.Length - 1);
        }


        public virtual double CalcularValorTotalNota()
        {
            double totalNota = new double();
            foreach (var produto in Produtos)
            {
                ValorTotalNota += produto.ValorTotal +
                    produto.Imposto.ValorIPI + produto.Imposto.ValorICMS + ValorFrete;
            }
            return totalNota;
        }
        public double CalcularValorTotalProdutos()
        {
            foreach (var produto in Produtos)
            {
                ValorTotalProdutos += produto.ValorTotal +
                    produto.Imposto.ValorIPI + produto.Imposto.ValorICMS;
            }
            return ValorTotalProdutos;
        }
        public double ObterValorTotalICMS()
        {
            double totalICMS = new double();
            foreach (var produto in Produtos)
            {
                totalICMS += (produto.ValorUnitario * produto.Quantidade);
            }
            return totalICMS;
        }
        public double ObterICMS()
        {
            double icms = new double();
            foreach (var produto in Produtos)
            {
                icms += produto.Imposto.ValorICMS;
            }
            return icms;
        }
        public double ObterIPI()
        {
            double ipi = new double();
            foreach (var produto in Produtos)
            {
                ipi += produto.Imposto.ValorIPI;
            }
            return ipi;
        }
        public override void Validar()
        {
            if (ValorTotalNota < 1)
                throw new ExcecaoValorTotalInvalido();

            if (String.IsNullOrEmpty(NaturezaOperacao))
                throw new ExcecaoNaturezaOperacaoVazia();

            if (DataEntrada < DateTime.Now)
                throw new ExcecaoDataEntradaInvalida();

            if (DataEmissao < DataEntrada)
                throw new ExcecaoDataEmissaoInvalida();

            if (Chave.Length < 1)
                throw new ExcecaoChaveInvalida();

            if (Destinatario == null)
                throw new ExcecaoDestinatarioNulo();

            if (Emitente == null)
                throw new ExcecaoEmitenteNulo();

            if (Transportador == null)
            {
                Transportador = new Transportador();

                Transportador.Endereco = Destinatario.Endereco;
                Transportador.Cpf = Destinatario.Cpf;
                Transportador.Cnpj = Destinatario.Cnpj;

                Transportador.Nome = Destinatario.Nome;
                Transportador.RazaoSocial = Destinatario.RazaoSocial;
            }

            if (Produtos.Count < 1)
                throw new ExcecaoProdutosVazio();
        }
    }
}
