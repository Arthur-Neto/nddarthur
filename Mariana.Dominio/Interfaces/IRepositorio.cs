using System.Collections.Generic;

namespace Mariana.Dominio.Interfaces
{

    public interface IRepositorio<T> where T : Entidade
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        int Excluir(int id);
        IList<T> BuscarTodos();
        IList<T> Pesquisar(string pesquisar);
        T ConsultarPorId(int id);
    }
}
