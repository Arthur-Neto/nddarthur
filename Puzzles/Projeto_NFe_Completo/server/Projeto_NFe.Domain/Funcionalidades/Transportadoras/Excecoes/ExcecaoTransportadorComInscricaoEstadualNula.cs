using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Transportadoras.Excecoes
{
    public class ExcecaoTransportadorComInscricaoEstadualNula : ExcecaoDeNegocio
    {
        public ExcecaoTransportadorComInscricaoEstadualNula() : base(CodigosErros.InvalidObject, "O Transportador deve possuir uma inscrição estadual.")
        {
        }
    }
}
