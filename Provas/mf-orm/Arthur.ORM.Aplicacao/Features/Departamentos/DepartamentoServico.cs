using Arthur.ORM.Dominio.Features.Departamentos;
using System.Collections.Generic;

namespace Arthur.ORM.Aplicacao.Features.Departamentos
{
    public class DepartamentoServico : IDepartamentoServico
    {
        private IDepartamentoRepositorio _departamentoRepositorio;

        public DepartamentoServico(IDepartamentoRepositorio departamentoRepositorio)
        {
            _departamentoRepositorio = departamentoRepositorio;
        }

        public Departamento Adicionar(Departamento entidade)
        {
            return _departamentoRepositorio.Salvar(entidade);
        }

        public Departamento Atualizar(Departamento entidade)
        {
            return _departamentoRepositorio.Atualizar(entidade);
        }

        public void Excluir(Departamento entidade)
        {
            _departamentoRepositorio.Deletar(entidade);
        }

        public Departamento ObterPorId(long id)
        {
            return _departamentoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Departamento> ObterTodos()
        {
            return _departamentoRepositorio.ObterTodos();
        }
    }
}
