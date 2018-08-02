using System.Collections.Generic;

namespace ProvaTDD.Dominio.Base
{
    public interface IRepositorio<T> where T : Entidade
    {
        T Salvar(T entidade);
        T Atualizar(T entidade);
        void Deletar(T entidade);
        IList<T> PegarTodos();
        T PegarPorId(long id);
    }
}
