using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoValorTotalNotaInvalido : ExcecaoDeNegocio
    {
        public ExcecaoValorTotalNotaInvalido() : base(CodigosErros.InvalidObject, "Não é possivel emitir uma nota fiscal com valor total da nota menor ou igual a 0.")
        {
        }
    }
}
