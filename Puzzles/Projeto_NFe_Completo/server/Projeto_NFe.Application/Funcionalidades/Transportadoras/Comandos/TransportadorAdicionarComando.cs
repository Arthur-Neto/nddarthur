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
    public class TransportadorAdicionarComando
    {
        public string NomeRazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public bool ResponsabilidadeFrete { get; set; }
        public Endereco Endereco { get; set; }
        public Documento Documento { get; set; }

        public virtual ValidationResult RealizarValidacaoDoComando()
        {
            Validar validar = new Validar();

            return validar.Validate(this);
        }

        class Validar : AbstractValidator<TransportadorAdicionarComando>
        {
            public Validar()
            {
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.NomeRazaoSocial).NotNull();
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.Documento).NotNull();
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.InscricaoEstadual).NotNull()
                    .When(transportadorAdicionarComando => transportadorAdicionarComando.Documento.Tipo == TipoDocumento.CNPJ);
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.InscricaoEstadual).MaximumLength(15)
                    .When(transportadorAdicionarComando => transportadorAdicionarComando.Documento.Tipo == TipoDocumento.CNPJ);
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.ResponsabilidadeFrete).NotNull();
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.Endereco).NotNull();
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.Endereco.Bairro).NotNull();
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.Endereco.Estado).NotNull();
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.Endereco.Logradouro).NotNull();
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.Endereco.Municipio).NotNull();
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.Endereco.Numero).NotNull();
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.Endereco.Numero).GreaterThan(0);
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.Endereco.Pais).NotNull();
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.Documento.Numero).MinimumLength(14);
                RuleFor(transportadorAdicionarComando => transportadorAdicionarComando.Documento.Numero).MaximumLength(18);
            }
        }
    }
}
