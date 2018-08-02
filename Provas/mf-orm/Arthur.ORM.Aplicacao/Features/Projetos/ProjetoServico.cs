using Arthur.ORM.Dominio.Features.Projetos;
using System.Collections.Generic;

namespace Arthur.ORM.Aplicacao.Features.Projetos
{
    public class ProjetoServico : IProjetoServico
    {
        private IProjetoRepositorio _projetoRepositorio;

        public ProjetoServico(IProjetoRepositorio projetoRepositorio)
        {
            _projetoRepositorio = projetoRepositorio;
        }

        public Projeto Adicionar(Projeto entidade)
        {
            return _projetoRepositorio.Salvar(entidade);
        }

        public Projeto Atualizar(Projeto entidade)
        {
            return _projetoRepositorio.Atualizar(entidade);
        }

        public void Excluir(Projeto entidade)
        {
            _projetoRepositorio.Deletar(entidade);
        }

        public Projeto ObterPorId(long id)
        {
            return _projetoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Projeto> ObterTodos()
        {
            return _projetoRepositorio.ObterTodos();
        }
    }
}
