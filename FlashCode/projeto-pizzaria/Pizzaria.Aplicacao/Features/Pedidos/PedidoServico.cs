using Pizzaria.Dominio.Exceptions;
using Pizzaria.Dominio.Features.Pedidos;
using System.Collections.Generic;

namespace Pizzaria.Aplicacao.Features.Pedidos
{
    public class PedidoServico : IPedidoServico
    {
        IPedidoRepositorio _repositorio;

        public PedidoServico(IPedidoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Pedido Adicionar(Pedido entidade)
        {
            entidade.Validar();

            return _repositorio.Salvar(entidade);
        }

        public Pedido Atualizar(Pedido entidade)
        {
            if (entidade.Id <= 0)
                throw new IdentificadorInvalidoExcecao();

            entidade.Validar();

            return _repositorio.Atualizar(entidade);
        }

        public void Excluir(Pedido entidade)
        {
            if (entidade.Id <= 0)
                throw new IdentificadorInvalidoExcecao();

            _repositorio.Deletar(entidade);
        }

        public Pedido ObterPorId(long id)
        {
            if (id <= 0)
                throw new IdentificadorInvalidoExcecao();

            return _repositorio.ObterPorId(id);

        }

        public IEnumerable<Pedido> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }
    }
}
