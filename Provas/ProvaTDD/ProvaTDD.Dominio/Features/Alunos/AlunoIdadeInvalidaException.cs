using ProvaTDD.Dominio.Exceptions;

namespace ProvaTDD.Dominio.Features.Alunos
{
    public class AlunoIdadeInvalidaException : BusinessException
    {
        public AlunoIdadeInvalidaException() : base("Aluno deve conter uma idade válida")
        {
        }
    }
}