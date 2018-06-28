using TutorialORM.Dominio.Base;

namespace TutorialORM.Dominio.Features.Turmas
{
    public interface ITurmaRepositorio : IRepositorio<Turma>
    {
        void VerificaDependencia(Turma turma);
    }
}
