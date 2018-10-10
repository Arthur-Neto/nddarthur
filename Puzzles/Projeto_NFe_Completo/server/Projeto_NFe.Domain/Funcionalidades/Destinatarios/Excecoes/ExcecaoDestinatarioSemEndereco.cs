using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes
{
    public class ExcecaoDestinatarioSemEndereco : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioSemEndereco() : base(CodigosErros.InvalidObject, "O destinatário deve possuir um endereço.")
        {
        }
    }
}
