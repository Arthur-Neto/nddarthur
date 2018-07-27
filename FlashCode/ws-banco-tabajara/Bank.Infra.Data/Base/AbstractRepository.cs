using Bank.Domain.Base;
using Bank.Domain.Exceptions;
using System.Data.Entity;
using System.Linq;

namespace Bank.Infra.Data.Base
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : Entity
    {
        protected BankContext _context;

        public AbstractRepository(BankContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            var newEntity = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return newEntity;
        }

        public IQueryable<T> GetAll(int? quantity = null)
        {
            if (quantity != null)
                return _context.Set<T>().Take((int)quantity);
            else
                return _context.Set<T>();
        }

        public T GetById(long id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public bool Remove(T entity)
        {
            var getEntity = _context.Set<T>().Where(e => e.Id == entity.Id).FirstOrDefault();
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
