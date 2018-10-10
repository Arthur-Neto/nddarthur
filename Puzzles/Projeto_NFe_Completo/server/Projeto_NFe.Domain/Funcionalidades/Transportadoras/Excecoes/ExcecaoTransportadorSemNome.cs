using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Transportadoras.Excecoes
{
    public class ExcecaoTransportadorSemNome : ExcecaoDeNegocio
    {
        public ExcecaoTransportadorSemNome() : base(CodigosErros.InvalidObject, "O Transportador deve possuir um nome.")
        {               
        }
    }
}
