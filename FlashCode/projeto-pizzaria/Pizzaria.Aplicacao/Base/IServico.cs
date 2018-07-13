using System.Collections.Generic;

namespace Pizzaria.Aplicacao.Base
{
    public interface IServico<T>
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        void Excluir(T entidade);
        T ObterPorId(long id);
        IEnumerable<T> ObterTodos();
    }
}
