using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain.Interfaces
{
    public interface IDisciplinaService : IService<Disciplina>
    {
        void Adicionar(Disciplina disciplina);
        void Editar(Disciplina disciplina);
    }
}
