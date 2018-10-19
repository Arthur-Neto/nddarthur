using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using System;
using System.Collections.Generic;

namespace Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Comandos
{
    public class NotaFiscalAdicionarComando
    {
        public long TransportadorId { get; set; }
        public long DestinatarioId { get; set; }
        public long EmitenteId { get; set; }
        public string NaturezaOperacao { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataEmissao { get; set; }
        public virtual List<ProdutoNotaFiscal> Produtos { get; set; }
        public virtual string ChaveAcesso { get; set; }
        public double ValorTotalICMS { get; set; }
        public double ValorTotalIPI { get; set; }
        public double ValorTotalProdutos { get; set; }
        public double ValorTotalFrete { get; set; }
        public double ValorTotalImpostos { get; set; }
        public double ValorTotalNota { get; set; }

        public virtual ValidationResult RealizarValidacaoDoComando()
        {
            Validar validar = new Validar();

            return validar.Validate(this);
        }

        private class Validar : AbstractValidator<NotaFiscalAdicionarComando>
        {
            public Validar()
            {
                RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.TransportadorId).GreaterThan(0);
                RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.DestinatarioId).GreaterThan(0);
                RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.EmitenteId).GreaterThan(0);
                RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.NaturezaOperacao).NotNull();
                RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.DataEntrada).NotNull();

                //Para emissão:

                //RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.Produtos).NotNull();
                //RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.ChaveAcesso).NotNull();
                //RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.ValorTotalFrete).NotNull();
                //RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.ValorTotalICMS).NotNull();
                //RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.ValorTotalImpostos).NotNull();
                //RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.ValorTotalIPI).NotNull();
                //RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.ValorTotalNota).NotNull();
                //RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.ValorTotalProdutos).NotNull();
            }
        }
    }
}
