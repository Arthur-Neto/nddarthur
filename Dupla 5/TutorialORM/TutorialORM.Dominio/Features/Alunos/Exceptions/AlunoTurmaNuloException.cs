using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Dominio.Features.Alunos
{
    public class AlunoTurmaNuloException : BusinessException
    {

        public AlunoTurmaNuloException() : base("Você precisa informar uma turma!")
        {
        }
    }
}