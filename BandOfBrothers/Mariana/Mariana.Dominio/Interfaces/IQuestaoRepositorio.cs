using System;
using System.Collections.Generic;

namespace Mariana.Dominio.Interfaces
{
    public interface IQuestaoRepositorio : IRepositorio<Questao>
    {
        IList<Questao> ConsultarPorNome(String nome);

        IList<Questao> ConsultarPorNomeEId(String nome, int id);

        IList<Questao> ObterQuestoesTeste(Teste teste);

        IList<Questao> PesquisarQuestao(string pesquisar);

    }
}
