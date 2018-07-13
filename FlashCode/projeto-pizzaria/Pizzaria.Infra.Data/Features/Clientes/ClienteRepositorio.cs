using Pizzaria.Dominio.Features.Clientes;
using Pizzaria.Infra.Data.Base;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.Infra.Data.Features.Clientes
{
    public class ClienteRepositorio : RepositorioGenerico<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(PizzariaContext pizzariaContext) : base(pizzariaContext)
        {

        }

        public IEnumerable<Cliente> BuscarPorTelefone(string telefone)
        {
            //return _contexto.Clientes.Where(c => c.Telefone == telefone).ToList();

            //Buscar o cliente pelo telefone pelo contais para que a query executada seja como um like %Telefone%
            var clientes = (from cliente in _contexto.Clientes
                           where cliente.Telefone.Contains(telefone)
                           select cliente).ToList();

            return clientes;
        }
    }
}
