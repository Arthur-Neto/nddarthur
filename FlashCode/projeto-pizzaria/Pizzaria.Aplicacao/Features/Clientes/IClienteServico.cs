using Pizzaria.Aplicacao.Base;
using Pizzaria.Dominio.Features.Clientes;
using System.Collections.Generic;

namespace Pizzaria.Aplicacao.Features.Clientes
{
    public interface IClienteServico : IServico<Cliente>
    {
        IEnumerable<Cliente> BuscarPorTelefone(string telefone);
    }
}
