using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Infra.Data.Features.Turmas
{
    public class TurmaReferenciadaException : BusinessException
    {
        public TurmaReferenciadaException() : base("Esta turna está sendo referenciada por um aluno")
        {
        }
    }
}
