using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Enderecos
{
    public class EnderecoCepVaziaExcecao : BusinessException
    {
        public EnderecoCepVaziaExcecao() : base("Endereço com cep vazio")
        {
        }
    }
}
