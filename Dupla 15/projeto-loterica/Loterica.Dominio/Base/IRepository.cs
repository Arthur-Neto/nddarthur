using System.Collections.Generic;

namespace Loterica.Dominio.Base
{
    public interface IRepository<T> where T : Entidade
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        T ObterPorId(long id);
        IEnumerable<T> PegarTodos();
        void Deletar(T entidade);
    }
}
