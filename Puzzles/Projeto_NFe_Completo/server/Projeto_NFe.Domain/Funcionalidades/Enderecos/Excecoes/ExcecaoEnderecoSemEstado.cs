using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Enderecos.Excecoes
{
    public class ExcecaoEnderecoSemEstado : ExcecaoDeNegocio
    {
        public ExcecaoEnderecoSemEstado() : base(CodigosErros.InvalidObject, "Um endereço deve ter um estado definido")
        {
        }
    }
}
