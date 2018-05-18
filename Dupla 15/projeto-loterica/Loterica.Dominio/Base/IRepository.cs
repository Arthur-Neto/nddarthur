using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Dominio.Base
{
    public interface IRepository<T> where T : Entidade
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        T ObterPorId(int id);
        IEnumerable<T> PegarTodos();
        void Deletar(T entidade);
    }
}
