using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Enderecos
{
    public class EnderecoCidadeVaziaExcecao : BusinessException
    {
        public EnderecoCidadeVaziaExcecao() : base("Endereço com cidade vazia")
        {
        }
    }
}
