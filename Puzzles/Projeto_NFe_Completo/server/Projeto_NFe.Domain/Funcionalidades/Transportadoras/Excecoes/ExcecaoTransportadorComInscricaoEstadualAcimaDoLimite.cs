using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Transportadoras.Excecoes
{
    public class ExcecaoTransportadorComInscricaoEstadualAcimaDoLimite : ExcecaoDeNegocio
    {
        public ExcecaoTransportadorComInscricaoEstadualAcimaDoLimite(): base(CodigosErros.InvalidObject, "A inscrição estadual não pode ter mais de quinze caracteres.")
        {
        }
    }
}
