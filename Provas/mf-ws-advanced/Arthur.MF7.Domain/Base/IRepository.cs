using System.Linq;

namespace Arthur.MF7.Domain.Base
{
    public interface IRepository<T> where T : Entity
    {
        T Add(T entity);
        bool Update(T entity);
        IQueryable<T> GetAll();
        T GetById(long id);
        bool Remove(T entity);
    }
}
