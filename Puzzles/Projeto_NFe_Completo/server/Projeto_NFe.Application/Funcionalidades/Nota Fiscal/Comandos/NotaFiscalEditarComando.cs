using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Comandos
{
    public class NotaFiscalEditarComando
    {
        public virtual long Id { get; set; }
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

        class Validar : AbstractValidator<NotaFiscalEditarComando>
        {
            public Validar()
            {
                RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.Id).NotNull();
                RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.Id).GreaterThan(0);
                RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.TransportadorId).GreaterThan(0);
                RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.DestinatarioId).GreaterThan(0);
                RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.EmitenteId).GreaterThan(0);
                RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.NaturezaOperacao).NotNull();
                RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.DataEntrada).NotNull();

                //Para emissão:

                //RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.Produtos).NotNull();
                //RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.ChaveAcesso).NotNull();
                //RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.ValorTotalFrete).NotNull();
                //RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.ValorTotalICMS).NotNull();
                //RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.ValorTotalImpostos).NotNull();
                //RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.ValorTotalIPI).NotNull();
                //RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.ValorTotalNota).NotNull();
                //RuleFor(notaFiscalEditarComando => notaFiscalEditarComando.ValorTotalProdutos).NotNull();

            }
        }
    }
}
