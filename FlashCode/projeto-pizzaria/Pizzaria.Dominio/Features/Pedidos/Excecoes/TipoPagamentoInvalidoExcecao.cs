using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Pedidos.Excecoes
{
    public class TipoPagamentoInvalidoExcecao : BusinessException
    {
        public TipoPagamentoInvalidoExcecao() : base("Tipo de pagamento não informado")
        {
        }
    }
}
