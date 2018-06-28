using System.Linq;
using TutorialORM.Dominio.Features.Turmas;
using TutorialORM.Infra.Data.Base;

namespace TutorialORM.Infra.Data.Features.Turmas
{
    public class TurmaRepositorio : RepositorioGenerico<Turma>, ITurmaRepositorio
    {
        public TurmaRepositorio(EscolaContext context) : base(context)
        {
        }

        public void VerificaDependencia(Turma turma)
        {
            if (_contexto.Alunos.Where(x => x.Turma.Id == turma.Id).FirstOrDefault() != null)
                throw new TurmaReferenciadaException();
        }
    }
}
