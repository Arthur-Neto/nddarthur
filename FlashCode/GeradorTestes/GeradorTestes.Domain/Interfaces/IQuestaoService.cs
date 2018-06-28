using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain.Interfaces
{
    public interface IQuestaoService : IService<Questao>
    {
        void Adicionar(Questao questao);
        void Editar(Questao questao);
        IList<Questao> GetAllRandom(Teste teste, Materia materia, Questao questao);
    }
}
