using Loterica.Dominio.Base;

namespace Loterica.Dominio.Features.Concursos
{
    public interface IConcursoRepository : IRepository<Concurso>
    {
        string RelatorioFaturamento();
    }
}
