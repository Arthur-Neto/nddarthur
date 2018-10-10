using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoSemNaturezaOperacao : ExcecaoDeNegocio
    {
        public ExcecaoSemNaturezaOperacao() : base(CodigosErros.InvalidObject, "Favor preencher a natureza da operação.")
        {
        }
    }
}
