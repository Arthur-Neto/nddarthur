using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoDestinatarioInvalido : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioInvalido() : base(CodigosErros.InvalidObject, "Não é possivel adicionar uma nota fiscal sem destinatário.")
        {
        }
    }
}
