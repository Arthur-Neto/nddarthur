using Exemplo.Dominio.Base;
using System.Collections.Generic;
using System.Data.Entity;

namespace Exemplo.Infra.Data.Base {
    public abstract class RepositorioGenerico<T> : IRepositorio<T> where T : Entidade{
        public ContextoExemplo _contexto;

        public RepositorioGenerico(ContextoExemplo context) {
            _contexto = context;
        }

        public T Atualizar(T entidade) {
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
            return entidade;
        }

        public void Deletar(T entidade) {
            _contexto.Set<T>().Remove(entidade);
            _contexto.SaveChanges();
        }

        public virtual T ObterPorId(long id) {
            return _contexto.Set<T>().Find(id);
        }

        public IEnumerable<T> ObterTodos() {
            return _contexto.Set<T>();
        }

        public T Salvar(T entidade) {
            entidade = _contexto.Set<T>().Add(entidade);
            _contexto.SaveChanges();
            return entidade;
        }
    }
}
