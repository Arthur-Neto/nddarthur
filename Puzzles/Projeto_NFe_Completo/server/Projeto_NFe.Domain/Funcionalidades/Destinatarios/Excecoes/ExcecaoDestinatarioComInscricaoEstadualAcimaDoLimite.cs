using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes
{
    public class ExcecaoDestinatarioComInscricaoEstadualAcimaDoLimite : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioComInscricaoEstadualAcimaDoLimite() : base(CodigosErros.InvalidObject, "A inscricão estadual esta acima do limite")
        {
        }
    }
}
