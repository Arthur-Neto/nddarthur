using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoProdutoSemValor : ExcecaoDeNegocio
    {
        public ExcecaoProdutoSemValor() : base(CodigosErros.InvalidObject, "Não é possivel emitir nota com produto de valor menor ou igual a 0")
        {
        }
    }
}
