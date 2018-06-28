using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Base
{
    public interface IRepositorio<T> where T : Entidade
    {
        T Inserir(T obj);

        T Atualizar(T obj);

        List<T> ObterTodos();

        T ObterPorId(long id);

        bool Deletar(long id);
    }
}
