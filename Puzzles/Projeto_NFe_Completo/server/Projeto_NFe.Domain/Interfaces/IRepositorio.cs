using Projeto_NFe.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Interfaces
{
    public interface IRepositorio<T> where T : Entidade
    {
        long Adicionar(T entidade);
        bool Atualizar(T entidade);
        bool Excluir(T entidade);
        IQueryable<T> BuscarTodos();
        T BuscarPorId(long Id);

    }
}
