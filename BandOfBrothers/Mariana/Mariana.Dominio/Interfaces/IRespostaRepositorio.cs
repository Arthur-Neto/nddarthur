using System;
using System.Collections.Generic;

namespace Mariana.Dominio.Interfaces
{
    public interface IRespostaRepositorio : IRepositorio<Resposta>
    {
        IList<Resposta> BuscarRepostaPorQuestaoId(int id);

        Resposta AdicionarComQuestaoId(Resposta resposta, int idQuestao);

        IList<Resposta> ObterRespostas(int id);

    }
}