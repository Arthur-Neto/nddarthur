using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Produtos.Excecoes
{
    public class ExcecaoProdutoComValorNegativo : ExcecaoDeNegocio
    {
        public ExcecaoProdutoComValorNegativo() : base(CodigosErros.InvalidObject, "O valor do produto não deve ser negativo")
        {
        }
    }
}
