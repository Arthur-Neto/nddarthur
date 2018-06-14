using NFe.Dominio.Base;
using System.Collections.Generic;

namespace NFe.Aplicacao.Base
{
    public interface IServico<T> where T : Entidade
    {
        T Salvar(T entidade);
        T Atualizar(T entidade);
        void Deletar(T entidade);
        IEnumerable<T> PegarTodos();
        T PegarPorId(long id);
    }
}