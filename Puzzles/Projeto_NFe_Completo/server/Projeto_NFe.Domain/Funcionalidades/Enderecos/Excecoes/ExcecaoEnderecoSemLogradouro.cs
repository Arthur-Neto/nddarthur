using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Enderecos.Excecoes
{
    public class ExcecaoEnderecoSemLogradouro : ExcecaoDeNegocio
    {
        public ExcecaoEnderecoSemLogradouro() : base(CodigosErros.InvalidObject, "Um endereço deve conter um logradouro")
        {
        }
    }
}
