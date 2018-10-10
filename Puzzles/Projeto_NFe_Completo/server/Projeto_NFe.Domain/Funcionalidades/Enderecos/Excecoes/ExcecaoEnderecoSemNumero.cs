using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Enderecos.Excecoes
{
    public class ExcecaoEnderecoSemNumero : ExcecaoDeNegocio
    {
        public ExcecaoEnderecoSemNumero() : base(CodigosErros.InvalidObject, "O endereço deve conter um número")
        {
        }
    }
}
