using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoEmitenteInvalido : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteInvalido() : base(CodigosErros.InvalidObject, "Não é possivel adicionar uma nota fiscal sem emitente.")
        {
        }
    }
}
