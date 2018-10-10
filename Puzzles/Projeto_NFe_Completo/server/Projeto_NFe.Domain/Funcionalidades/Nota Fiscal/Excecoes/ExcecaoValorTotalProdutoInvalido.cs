using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoValorTotalProdutoInvalido : ExcecaoDeNegocio
    {
        public ExcecaoValorTotalProdutoInvalido():base(CodigosErros.InvalidObject, "Não é possivel emitir uma nota com valor total do Produto menor ou igual a 0.")
        {             
        }
    }
}
