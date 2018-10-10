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
    public class DestinatarioEditarComando
    {
        public virtual long Id { get; set; }

        public String NomeRazaoSocial { get; set; }

        public Documento Documento { get; set; }

        public string InscricaoEstadual { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual ValidationResult RealizarValidacaoDoComando()
        {
            Validar validar = new Validar();

            return validar.Validate(this);
        }

        class Validar : AbstractValidator<DestinatarioEditarComando>
        {
            public Validar()
            {
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Id).NotNull();
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Id).GreaterThan(0);
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.NomeRazaoSocial).NotNull();
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Documento).NotNull();
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.InscricaoEstadual).NotNull()
                    .When(destinatarioEditarComando => destinatarioEditarComando.Documento.Tipo == TipoDocumento.CNPJ);
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.InscricaoEstadual).MaximumLength(15)
                    .When(destinatarioEditarComando => destinatarioEditarComando.Documento.Tipo == TipoDocumento.CNPJ);
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Endereco).NotNull();
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Endereco.Bairro).NotNull();
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Endereco.Estado).NotNull();
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Endereco.Logradouro).NotNull();
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Endereco.Municipio).NotNull();
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Endereco.Numero).NotNull();
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Endereco.Numero).GreaterThan(0);
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Endereco.Pais).NotNull();
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Documento.Numero).MinimumLength(11);
                RuleFor(destinatarioEditarComando => destinatarioEditarComando.Documento.Numero).MaximumLength(14);
            }
        }
    }
}
