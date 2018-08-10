using Bank.Domain.Base;
using System.Linq;

namespace Bank.Application.Base
{
    public interface IService<T> where T : Entity
    {
        long Add(T entity);

        bool Update(T entity);

        T GetById(long id);

        IQueryable<T> GetAll(int? quantity = null);

        bool Remove(T entity);
    }
}
