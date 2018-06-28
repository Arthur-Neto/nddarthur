using Projeto_NFe.Dominio.Excecoes;

namespace Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes
{
    public class ExcecaoDestinatarioNulo : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioNulo() : base("Você precisa informar o destinatário!")
        {
        }
    }
}
