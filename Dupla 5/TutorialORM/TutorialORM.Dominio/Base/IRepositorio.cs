using System.Collections.Generic;

namespace TutorialORM.Dominio.Base
{
    public interface IRepositorio<T> where T : Entidade
    {
        T Salvar(T entidade);
        T Atualizar(T entidade);
        IEnumerable<T> PegarTodos();
        T PegarPorId(long id);
        void Deletar(T entidade);
    }
}
