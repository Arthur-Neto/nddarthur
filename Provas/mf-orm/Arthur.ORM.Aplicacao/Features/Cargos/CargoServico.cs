using Arthur.ORM.Dominio.Features.Cargos;
using System.Collections.Generic;

namespace Arthur.ORM.Aplicacao.Features.Cargos
{
    public class CargoServico : ICargoServico
    {
        private ICargoRepositorio _cargoRepositorio;

        public CargoServico(ICargoRepositorio cargoRepositorio)
        {
            _cargoRepositorio = cargoRepositorio;
        }

        public Cargo Adicionar(Cargo entidade)
        {
            return _cargoRepositorio.Salvar(entidade);
        }

        public Cargo Atualizar(Cargo entidade)
        {
            return _cargoRepositorio.Atualizar(entidade);
        }

        public Cargo BuscarPorDescricao(string descricao)
        {
            return _cargoRepositorio.BuscarPorDescricao(descricao);
        }

        public void Excluir(Cargo entidade)
        {
            _cargoRepositorio.Deletar(entidade);
        }

        public Cargo ObterPorId(long id)
        {
            return _cargoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Cargo> ObterTodos()
        {
            return _cargoRepositorio.ObterTodos();
        }
    }
}
