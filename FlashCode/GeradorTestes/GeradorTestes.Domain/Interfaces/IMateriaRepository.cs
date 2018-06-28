using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain.Interfaces
{
    public interface IMateriaRepository : IRepository<Materia>
    {
        bool GetByName(Materia materia);

        bool GetByIDSerie(int id);

        IList<Materia> GetByIDSerieAndDisciplina(Serie serie = null, Disciplina disciplina = null);

        Materia MakeSerie(IDataReader reader);

        Materia MakeDisciplina(IDataReader reader);

        Materia MakeGetByName(IDataReader reader);

        bool GetByIDDiciplina(int id);
    }
}
