using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Transportadoras.Comandos
{
    public class TransportadorEditarComando
    {
        public long Id { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public bool ResponsabilidadeFrete { get; set; }
        public virtual Endereco Endereco { get; set; }
        public Documento Documento { get; set; }

        public virtual ValidationResult RealizarValidacaoDoComando()
        {
            Validar validar = new Validar();

            return validar.Validate(this);
        }

        class Validar : AbstractValidator<TransportadorEditarComando>
        {
            public Validar()
            {
                RuleFor(transportadorEditarComando => transportadorEditarComando.Id).NotNull();
                RuleFor(transportadorEditarComando => transportadorEditarComando.Id).GreaterThan(0);
                RuleFor(transportadorEditarComando => transportadorEditarComando.NomeRazaoSocial).NotNull();
                RuleFor(transportadorEditarComando => transportadorEditarComando.InscricaoEstadual).NotNull()
                    .When(transportadorEditarComando => transportadorEditarComando.Documento.Tipo == TipoDocumento.CNPJ);
                RuleFor(transportadorEditarComando => transportadorEditarComando.InscricaoEstadual).MaximumLength(15)
                    .When(transportadorEditarComando => transportadorEditarComando.Documento.Tipo == TipoDocumento.CNPJ);
                RuleFor(transportadorEditarComando => transportadorEditarComando.ResponsabilidadeFrete).NotNull();
                RuleFor(transportadorEditarComando => transportadorEditarComando.Endereco).NotNull();
                RuleFor(transportadorEditarComando => transportadorEditarComando.Documento).NotNull();
                RuleFor(transportadorEditarComando => transportadorEditarComando.Endereco.Bairro).NotNull();
                RuleFor(transportadorEditarComando => transportadorEditarComando.Endereco.Estado).NotNull();
                RuleFor(transportadorEditarComando => transportadorEditarComando.Endereco.Logradouro).NotNull();
                RuleFor(transportadorEditarComando => transportadorEditarComando.Endereco.Municipio).NotNull();
                RuleFor(transportadorEditarComando => transportadorEditarComando.Endereco.Numero).NotNull();
                RuleFor(transportadorEditarComando => transportadorEditarComando.Endereco.Numero).GreaterThan(0);
                RuleFor(transportadorEditarComando => transportadorEditarComando.Endereco.Pais).NotNull();
                RuleFor(transportadorEditarComando => transportadorEditarComando.Documento.Numero).MinimumLength(14);
                RuleFor(transportadorEditarComando => transportadorEditarComando.Documento.Numero).MaximumLength(18);
            }
        }
    }
}
