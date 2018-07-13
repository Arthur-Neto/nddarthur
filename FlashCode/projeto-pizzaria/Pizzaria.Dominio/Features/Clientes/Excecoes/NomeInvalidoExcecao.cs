using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Clientes.Excecoes
{
    public class NomeInvalidoExcecao : BusinessException
    {
        public NomeInvalidoExcecao() : base("Nome inválido")
        {
        }
    }
}
