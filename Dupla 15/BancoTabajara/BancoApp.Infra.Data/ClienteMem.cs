using BancoApp.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Infra.Data
{
    public class ClienteMem
    {
        private List<Cliente> _clientes = new List<Cliente>();

        public void AdicionarCliente(Cliente NovoCliente)
        {
            if (NovoCliente != null)
                _clientes.Add(NovoCliente);

        }

        public List<Cliente> ListarCliente()
        {
            return _clientes;
        }

        public void Excluir(Cliente clienteSelecionado)
        {
            if (clienteSelecionado != null)
                _clientes.Remove(clienteSelecionado);
        }
    }
}
