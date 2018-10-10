using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoValorTotalIPIInvalido: ExcecaoDeNegocio
    {
        public ExcecaoValorTotalIPIInvalido(): base(CodigosErros.InvalidObject, "Não é possivel emitir uma nota com valor total IPI menor ou igual a 0.")
        {

        }
    }
}
