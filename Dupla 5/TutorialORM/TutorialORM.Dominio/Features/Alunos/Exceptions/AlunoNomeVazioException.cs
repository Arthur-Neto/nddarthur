using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Dominio.Features.Alunos
{
    public class AlunoNomeVazioException : BusinessException
    {
        public AlunoNomeVazioException() : base("Você precisa informar o nome do aluno!")
        {
        }
    }
}