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
    public class EmitenteAdicionarComando
    {
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

        class Validar : AbstractValidator<EmitenteAdicionarComando>
        {
            public Validar()
            {
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.NomeFantasia).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.NomeFantasia).MinimumLength(5);
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.RazaoSocial).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.RazaoSocial).MinimumLength(5);
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.CNPJ).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.InscricaoEstadual).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.InscricaoEstadual).MaximumLength(15);
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.InscricaoMunicipal).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.Endereco).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.Endereco.Bairro).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.Endereco.Estado).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.Endereco.Logradouro).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.Endereco.Municipio).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.Endereco.Numero).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.Endereco.Numero).GreaterThan(0);
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.Endereco.Pais).NotNull();
                RuleFor(emitenteAdicionarComando => emitenteAdicionarComando.CNPJ.Numero).Length(18);
            }
        }
    }
}
