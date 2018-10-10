using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Enderecos.Excecoes
{
    public class ExcecaoEnderecoSemBairro : ExcecaoDeNegocio
    {
        public ExcecaoEnderecoSemBairro() : base(CodigosErros.InvalidObject, "Um endereço deve ter um bairro definido")
        {
        }
    }
}
