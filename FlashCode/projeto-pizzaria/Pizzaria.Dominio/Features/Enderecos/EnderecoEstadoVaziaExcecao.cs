using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Enderecos
{
    public class EnderecoEstadoVaziaExcecao : BusinessException
    {
        public EnderecoEstadoVaziaExcecao() : base("Endereço com estado vazio")
        {
        }
    }
}
