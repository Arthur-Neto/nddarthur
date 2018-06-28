using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Dominio.Features.Turmas
{
    public class TurmaDescricaoVaziaException : BusinessException
    {
        public TurmaDescricaoVaziaException() : base("Turma não pode ter uma descrição em branco")
        {
        }
    }
}
