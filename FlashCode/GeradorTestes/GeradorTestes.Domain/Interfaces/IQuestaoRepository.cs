using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain.Interfaces
{
    public interface IQuestaoRepository : IRepository<Questao>
    {
        bool GetByID(int id);

        Questao MakeQustoes(IDataReader reader);

        Dictionary<string, object> TakeTBQAlternativas(Questao questao);

        IList<Questao> GetAllRandom(Teste teste, Materia materia, Questao questao);
    }
}
