using System.Collections.Generic;
using TutorialORM.Dominio.Base;

namespace TutorialORM.Aplicacao.Base
{
    public interface IServico<T> where T : Entidade
    {
        T Salvar(T entidade);
        T Atualizar(T entidade);
        IEnumerable<T> PegarTodos();
        T PegarPorId(long id);
        void Deletar(T entidade);
    }
}
