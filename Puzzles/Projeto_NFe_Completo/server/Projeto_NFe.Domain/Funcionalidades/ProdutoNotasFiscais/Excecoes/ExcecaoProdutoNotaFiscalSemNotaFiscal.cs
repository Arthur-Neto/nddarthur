using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais.Excecoes
{
    public class ExcecaoProdutoNotaFiscalSemNotaFiscal : ExcecaoDeNegocio
    {
        public ExcecaoProdutoNotaFiscalSemNotaFiscal() : base(CodigosErros.InvalidObject, "Para criar uma produto nota fiscal é necessário vincular uma nota fiscal")
        {
        }
    }
}
