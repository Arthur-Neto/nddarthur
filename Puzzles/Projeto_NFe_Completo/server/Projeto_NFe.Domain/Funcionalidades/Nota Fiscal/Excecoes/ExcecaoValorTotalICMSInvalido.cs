using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoValorTotalICMSInvalido : ExcecaoDeNegocio
    {
        public ExcecaoValorTotalICMSInvalido(): base(CodigosErros.InvalidObject, "Não é possivel emitir uma nota com valor total ICMS menor ou igual a 0.")
        {
        }
    }
}
