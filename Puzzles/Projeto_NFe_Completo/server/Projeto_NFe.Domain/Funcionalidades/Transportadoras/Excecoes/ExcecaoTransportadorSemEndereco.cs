using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Transportadoras.Excecoes
{
    public class ExcecaoTransportadorSemEndereco : ExcecaoDeNegocio
    {
        public ExcecaoTransportadorSemEndereco() : base(CodigosErros.InvalidObject, "O Transportador deve possuir um endereço.")
        {
        }
    }
}
