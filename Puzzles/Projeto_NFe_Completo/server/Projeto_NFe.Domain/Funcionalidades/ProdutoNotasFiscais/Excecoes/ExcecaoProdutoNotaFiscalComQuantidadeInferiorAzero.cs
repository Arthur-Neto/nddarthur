using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais.Excecoes
{
    public class ExcecaoProdutoNotaFiscalComQuantidadeInferiorAum : ExcecaoDeNegocio
    {
        public ExcecaoProdutoNotaFiscalComQuantidadeInferiorAum() : base(CodigosErros.InvalidObject, "A quantidade de produtos no produto nota fiscal deve ser maior que 0")
        {
        }
    }
}
