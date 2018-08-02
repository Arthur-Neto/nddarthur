using System.Collections.Generic;

namespace Arthur.ORM.Dominio.Base {
    public interface IRepositorio<T> {
        T Salvar(T entidade);
        T Atualizar(T entidade);
        IEnumerable<T> ObterTodos();
        T ObterPorId(long id);
        void Deletar(T entidade);
    }
}
