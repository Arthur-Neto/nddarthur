using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Enderecos.Excecoes
{
    public class ExcecaoEnderecoSemMunicipio : ExcecaoDeNegocio
    {
        public ExcecaoEnderecoSemMunicipio() : base(CodigosErros.InvalidObject, "Um endereço deve ter um município definido")
        {
        }

    }
}
