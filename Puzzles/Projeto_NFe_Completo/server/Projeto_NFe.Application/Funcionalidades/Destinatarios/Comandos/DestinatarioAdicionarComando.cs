using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Destinatarios.Comandos
{
    public class DestinatarioAdicionarComando
    {
        public virtual string NomeRazaoSocial { get; set; }

        public Documento Documento { get; set; }

        public virtual string InscricaoEstadual { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual ValidationResult RealizarValidacaoDoComando()
        {
            Validar validar = new Validar();

            return validar.Validate(this);
        }

        class Validar : AbstractValidator<DestinatarioAdicionarComando>
        {
            public Validar()
            {
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.NomeRazaoSocial).NotNull();
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.Documento).NotNull();
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.InscricaoEstadual).NotNull()
                    .When(destinatarioAdicionarComando => destinatarioAdicionarComando.Documento.Tipo == TipoDocumento.CNPJ);
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.InscricaoEstadual).MaximumLength(15)
                    .When(destinatarioAdicionarComando => destinatarioAdicionarComando.Documento.Tipo == TipoDocumento.CNPJ);
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.Endereco).NotNull();
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.Endereco.Bairro).NotNull();
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.Endereco.Estado).NotNull();
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.Endereco.Logradouro).NotNull();
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.Endereco.Municipio).NotNull();
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.Endereco.Numero).NotNull();
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.Endereco.Numero).GreaterThan(0);
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.Endereco.Pais).NotNull();
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.Documento.Numero).MinimumLength(11);
                RuleFor(destinatarioAdicionarComando => destinatarioAdicionarComando.Documento.Numero).MaximumLength(14);
            }
        }
    }
}
