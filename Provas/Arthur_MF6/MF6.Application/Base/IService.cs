using MF6.Domain.Base;
using System.Linq;

namespace MF6.Application.Base {

    public interface IService<T> where T : Entity {

        long Add(T entity);

        bool Update(T entity);

        T GetById(long id);

        IQueryable<T> GetAll(int? quantity = null);

        bool Remove(T entity);
    }
}