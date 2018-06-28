using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain.Interfaces
{
    public interface IMateriaService : IService<Materia>
    {
        void Adicionar(Materia materia);
        void Editar(Materia materia);
        IList<Materia> GetMateriaBySerieAndDisciplina(Serie serie, Disciplina disciplina);
    }
}
