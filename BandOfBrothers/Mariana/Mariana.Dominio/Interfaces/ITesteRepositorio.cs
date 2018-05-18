using System;
using System.Collections.Generic;

namespace Mariana.Dominio.Interfaces
{
    public interface ITesteRepositorio : IRepositorio<Teste>
    {
        IList<Teste> ConsultarPorNome(String nome);

        IList<Teste> ConsultarPorNomeEId(String nome, int id);

        void AdicionarQuestoes(Questao questao, Teste teste);

        int ExcluirQuestoes(int testeId);

        IList<Teste> PesquisarTeste(string NomePesquisa);
    }
}
