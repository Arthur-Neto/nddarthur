using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Dominio.Features.Alunos
{
    public class AlunoDataNascimentoInvalidaException : BusinessException
    {
        public AlunoDataNascimentoInvalidaException() : base("Data de nascimento não pode ser maior que a data atual!")
        {
        }
    }
}