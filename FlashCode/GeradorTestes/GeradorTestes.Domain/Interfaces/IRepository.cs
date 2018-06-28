using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entidade);

        void Update(T entidade);

        void Delete(T entidade);

        IList<T> GetAll();

        T Make(IDataReader reader);

        Dictionary<string, object> Take(T entidade);
    }
}
