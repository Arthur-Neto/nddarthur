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
    public class NotaFiscalAdicionarComando
    {
        public Transportador Transportador { get; set; }
        public Destinatario Destinatario { get; set; }
        public Emitente Emitente { get; set; }
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

        class Validar : AbstractValidator<NotaFiscalAdicionarComando>
        {
            public Validar()
            {
                RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.Transportador).NotNull();
                RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.Destinatario).NotNull();
                RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.Emitente).NotNull();
                RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.NaturezaOperacao).NotNull();
                RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.DataEntrada).NotNull();
                RuleFor(notaFiscalAdicionarComando => notaFiscalAdicionarComando.Destinatario.Documento.Numero)
                    .NotEqual(notaFiscalAdicionarComando => notaFiscalAdicionarComando.Emitente.CNPJ.Numero);

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
