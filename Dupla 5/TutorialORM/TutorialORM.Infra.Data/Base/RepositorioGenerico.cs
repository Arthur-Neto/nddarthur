using System.Collections.Generic;
using System.Data.Entity;
using TutorialORM.Dominio.Base;

namespace TutorialORM.Infra.Data.Base
{
    public abstract class RepositorioGenerico<T> : IRepositorio<T> where T : Entidade
    {
        protected EscolaContext _contexto;

        protected RepositorioGenerico(EscolaContext context)
        {
            _contexto = context;
        }

        public T Atualizar(T entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
            return entidade;
        }

        public void Deletar(T entidade)
        {
            _contexto.Set<T>().Remove(entidade);
            _contexto.SaveChanges();
        }

        public T PegarPorId(long id)
        {
            return _contexto.Set<T>().Find(id);
        }

        public IEnumerable<T> PegarTodos()
        {
            return _contexto.Set<T>(); 
        }

        public T Salvar(T entidade)
        {
            entidade = _contexto.Set<T>().Add(entidade);
            _contexto.SaveChanges();
            return entidade;
        }
    }
}
