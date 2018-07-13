using Pizzaria.Dominio.Base;
using System.Collections.Generic;

namespace Pizzaria.Dominio.Features.Clientes
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        IEnumerable<Cliente> BuscarPorTelefone(string telefone);
    }
}
