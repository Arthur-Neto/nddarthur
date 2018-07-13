using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Enderecos
{
    public class EnderecoBairroVaziaExcecao : BusinessException
    {
        public EnderecoBairroVaziaExcecao() : base("Endereço com bairro vazio")
        {
        }
    }
}
