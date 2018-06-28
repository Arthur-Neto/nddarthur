using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain.Interfaces
{
    public interface IService<T> where T : Entidade
    {      
        void Deletar(T entidade);
        IList<T> GetAll();
    }
}
