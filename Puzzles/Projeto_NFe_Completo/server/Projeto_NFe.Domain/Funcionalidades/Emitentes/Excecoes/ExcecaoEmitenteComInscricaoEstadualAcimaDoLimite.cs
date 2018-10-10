using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoEmitenteComInscricaoEstadualAcimaDoLimite : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteComInscricaoEstadualAcimaDoLimite(): base(CodigosErros.InvalidObject, "A inscrição estadual não pode ter mais de quinze caracteres")
        {
        }
    }
}
