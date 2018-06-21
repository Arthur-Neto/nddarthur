using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Dominio.Features.Alunos
{
    public class AlunoEnderecoNuloException : BusinessException
    {
        public AlunoEnderecoNuloException() : base("Você precisa informar um endereço!")
        {
        }
    }
}