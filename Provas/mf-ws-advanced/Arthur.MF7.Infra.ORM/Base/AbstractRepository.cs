using Arthur.MF7.Domain.Base;
using Arthur.MF7.Domain.Exceptions;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Arthur.MF7.Infra.ORM.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class AbstractRepository<T> : IRepository<T> where T : Entity
    {
        protected MF7Context _context;

        public AbstractRepository(MF7Context context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            T newEntity = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return newEntity;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(long id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public bool Remove(T entity)
        {
            T getEntity = _context.Set<T>().Where(e => e.Id == entity.Id).FirstOrDefault();
            if (getEntity == null)
                throw new NotFoundException();
            _context.Set<T>().Remove(getEntity);
            return _context.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
