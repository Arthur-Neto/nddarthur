using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes
{
    public class ExcecaoDestinatarioComInscricaoEstadualNula : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioComInscricaoEstadualNula() : base(CodigosErros.InvalidObject, "A inscrição estadual é nula")
        {
        }
    }
}
