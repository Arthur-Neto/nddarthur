using System.Linq;

namespace MF6.Domain.Base {

    public interface IRepository<T> where T : Entity {

        T Add(T entity);

        bool Update(T entity);

        IQueryable<T> GetAll(int? quantity = null);

        T GetById(long id);

        bool Remove(T entity);
    }
}