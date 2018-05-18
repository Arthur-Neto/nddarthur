using System;
using System.Collections.Generic;

namespace Mariana.Dominio.Interfaces
{
    public interface IDisciplinaRepositorio : IRepositorio<Disciplina>
    {
        IList<Disciplina> ConsultarPorNome(String nome);

        IList<Disciplina> ConsultarPorNomeEId(String nome, int id);

        IList<Disciplina> PesquisarDisciplina(string pesquisa);
    }
}
