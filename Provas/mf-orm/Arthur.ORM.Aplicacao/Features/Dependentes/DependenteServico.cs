using Arthur.ORM.Dominio.Features.Dependentes;
using System.Collections.Generic;

namespace Arthur.ORM.Aplicacao.Features.Dependentes
{
    public class DependenteServico : IDependenteServico
    {
        private IDependenteRepositorio _dependenteRepositorio;

        public DependenteServico(IDependenteRepositorio dependenteRepositorio)
        {
            _dependenteRepositorio = dependenteRepositorio;
        }

        public Dependente Adicionar(Dependente entidade)
        {
            return _dependenteRepositorio.Salvar(entidade);
        }

        public Dependente Atualizar(Dependente entidade)
        {
            return _dependenteRepositorio.Atualizar(entidade);
        }

        public void Excluir(Dependente entidade)
        {
            _dependenteRepositorio.Deletar(entidade);
        }

        public Dependente ObterPorId(long id)
        {
            return _dependenteRepositorio.ObterPorId(id);
        }

        public IEnumerable<Dependente> ObterTodos()
        {
            return _dependenteRepositorio.ObterTodos();
        }
    }
}
