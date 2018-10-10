using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes
{
    public class ExcecaoDestinatarioSemNome : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioSemNome() : base(CodigosErros.InvalidObject, "Não foi preenchido o nome ou a razao social do destinatario")
        {
        }
    }
}
