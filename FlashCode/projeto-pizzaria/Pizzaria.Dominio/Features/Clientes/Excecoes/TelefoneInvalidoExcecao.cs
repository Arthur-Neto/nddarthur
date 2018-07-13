using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Clientes.Excecoes
{
    public class TelefoneInvalidoExcecao : BusinessException
    {
        public TelefoneInvalidoExcecao( ) : base("Telefone Inválido")
        {
        }
    }
}
