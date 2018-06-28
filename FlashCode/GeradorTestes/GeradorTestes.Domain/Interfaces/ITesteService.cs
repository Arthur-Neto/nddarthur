using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain.Interfaces
{
    public interface ITesteService : IService<Teste>
    {
        void GerarTeste(Teste teste, Materia materia, Questao questao);
        IList<Questao> GetAllTesteQuestoes(Teste teste);
        void GerarTeste(Teste teste, string caminho);
    }
}
