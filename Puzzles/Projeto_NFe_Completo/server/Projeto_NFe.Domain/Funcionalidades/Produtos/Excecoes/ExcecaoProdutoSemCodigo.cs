using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Produtos.Excecoes
{
    public class ExcecaoProdutoSemCodigo : ExcecaoDeNegocio
    {
        public ExcecaoProdutoSemCodigo() : base(CodigosErros.InvalidObject, "O produto deve conter um código")
        {
        }
    }
}
