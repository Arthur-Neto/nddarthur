using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.ItensPedidos.Excecoes
{
    public class ValorParcialInvalidoExcecao : BusinessException
    {
        public ValorParcialInvalidoExcecao() : base("Valor parcial nao pode ser negativo!")
        {
        }
    }
}
