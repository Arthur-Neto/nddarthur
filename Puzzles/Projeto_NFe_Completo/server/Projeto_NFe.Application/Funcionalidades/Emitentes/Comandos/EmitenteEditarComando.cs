using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Emitentes.Comandos
{
    public class EmitenteEditarComando
    {
        public long Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public virtual Documento CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual ValidationResult RealizarValidacaoDoComando()
        {
            Validar validar = new Validar();

            return validar.Validate(this);
        }

        class Validar : AbstractValidator<EmitenteEditarComando>
        {
            public Validar()
            {
                RuleFor(emitenteEditarComando => emitenteEditarComando.Id).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.Id).GreaterThan(0);
                RuleFor(emitenteEditarComando => emitenteEditarComando.NomeFantasia).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.NomeFantasia).MinimumLength(5);
                RuleFor(emitenteEditarComando => emitenteEditarComando.RazaoSocial).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.RazaoSocial).MinimumLength(5);
                RuleFor(emitenteEditarComando => emitenteEditarComando.CNPJ).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.InscricaoEstadual).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.InscricaoEstadual).MaximumLength(15);
                RuleFor(emitenteEditarComando => emitenteEditarComando.InscricaoMunicipal).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.Endereco).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.Endereco.Bairro).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.Endereco.Estado).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.Endereco.Logradouro).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.Endereco.Municipio).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.Endereco.Numero).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.Endereco.Numero).GreaterThan(0);
                RuleFor(emitenteEditarComando => emitenteEditarComando.Endereco.Pais).NotNull();
                RuleFor(emitenteEditarComando => emitenteEditarComando.CNPJ.Numero).Length(18);
            }
        }
    }
}
