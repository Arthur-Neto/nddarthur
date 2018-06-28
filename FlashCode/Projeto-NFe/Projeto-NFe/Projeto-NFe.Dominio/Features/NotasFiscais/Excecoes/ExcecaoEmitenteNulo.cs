using Projeto_NFe.Dominio.Excecoes;

namespace Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes
{
    public class ExcecaoEmitenteNulo : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteNulo() : base("Você precisa informar o emitente!")
        {
        }
    }
}
