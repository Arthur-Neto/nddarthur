using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Enderecos
{
    public class EnderecoRuaVaziaExcecao : BusinessException
    {
        public EnderecoRuaVaziaExcecao() : base("Endereço com rua vazia")
        {
        }
    }
}
