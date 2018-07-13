using Pizzaria.Dominio.Exceptions;
using Pizzaria.Dominio.Features.Clientes;
using System.Collections.Generic;

namespace Pizzaria.Aplicacao.Features.Clientes
{
    public class ClienteServico : IClienteServico
    {
        private IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public Cliente Adicionar(Cliente entidade)
        {
            entidade.Validar();

            return _clienteRepositorio.Salvar(entidade);
        }

        public Cliente Atualizar(Cliente entidade)
        {
            if (entidade.Id <= 0)
                throw new IdentificadorInvalidoExcecao();

            entidade.Validar();
            return _clienteRepositorio.Atualizar(entidade);
        }

        public IEnumerable<Cliente> BuscarPorTelefone(string telefone)
        {
            return _clienteRepositorio.BuscarPorTelefone(telefone);
        }

        public void Excluir(Cliente entidade)
        {
            if (entidade.Id <= 0)
                throw new IdentificadorInvalidoExcecao();
            _clienteRepositorio.Deletar(entidade);
        }

        public Cliente ObterPorId(long id)
        {
            if (id <= 0)
                throw new IdentificadorInvalidoExcecao();
            return _clienteRepositorio.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepositorio.ObterTodos();
        }
    }
}
