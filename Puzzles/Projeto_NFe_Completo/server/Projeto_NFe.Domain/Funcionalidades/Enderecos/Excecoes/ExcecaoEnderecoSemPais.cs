using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Enderecos.Excecoes
{
    public class ExcecaoEnderecoSemPais : ExcecaoDeNegocio
    {
        public ExcecaoEnderecoSemPais() : base(CodigosErros.InvalidObject, "Um endereço deve ter um país definido")
        {
        }
    }
}
