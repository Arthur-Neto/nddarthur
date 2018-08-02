using System.Collections.Generic;

namespace ArthurProva.Domain.Interfaces
{
    public interface IRepositorio<T> where T : Entidade
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        int Excluir(int id);
        IList<T> BuscarTodos();
        T ConsultarPorId(int id);
    }
}
