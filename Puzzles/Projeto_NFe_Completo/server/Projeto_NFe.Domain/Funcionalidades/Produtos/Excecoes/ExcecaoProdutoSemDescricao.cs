using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Produtos.Excecoes
{
    public class ExcecaoProdutoSemDescricao : ExcecaoDeNegocio
    {
        public ExcecaoProdutoSemDescricao() : base(CodigosErros.InvalidObject, "O Produto deve conter uma descrição")
        {
        }
    }
}
