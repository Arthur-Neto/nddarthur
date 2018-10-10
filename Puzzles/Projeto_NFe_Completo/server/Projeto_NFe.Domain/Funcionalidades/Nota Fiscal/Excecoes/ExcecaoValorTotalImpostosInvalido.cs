using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoValorTotalImpostosInvalido : ExcecaoDeNegocio
    {
        public ExcecaoValorTotalImpostosInvalido() : base(CodigosErros.InvalidObject, "Não é possivel emitir uma nota com valor total dos impostos menor ou igual a 0.")
        {
        }
    }
}
