using System;
using System.Collections.Generic;

namespace Mariana.Dominio.Interfaces
{
    public interface IMateriaRepositorio : IRepositorio<Materia>
    {
        IList<Materia> ConsultarPorNome(String nome);
        IList<Materia> ConsultarPorNomeEId(String nome, int id);
        IList<Materia> PesquisarMateria(string pesquisa);
    }
}
