using NFe.Dominio.Features.Enderecos;
using NFe.Infra.Features.Cnpj;
using NFe.Infra.Features.Cpf;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class Contribuinte : Entidade
    {
        public Contribuinte()
        {
            Endereco = new Endereco();
        }

        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public Cpf Cpf { get; set; }
        public Cnpj Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public Endereco Endereco { get; set; }
    }
}
