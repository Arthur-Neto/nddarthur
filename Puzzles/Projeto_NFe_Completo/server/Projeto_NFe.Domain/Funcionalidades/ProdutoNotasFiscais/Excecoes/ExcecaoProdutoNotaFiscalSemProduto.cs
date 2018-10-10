using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais.Excecoes
{
    public class ExcecaoProdutoNotaFiscalSemProduto : ExcecaoDeNegocio
    {
        public ExcecaoProdutoNotaFiscalSemProduto() : base(CodigosErros.InvalidObject, "Para criar um produto nota fical é necessário vincular um produto")
        {
        }
    }
}
