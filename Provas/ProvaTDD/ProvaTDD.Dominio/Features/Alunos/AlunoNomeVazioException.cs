using ProvaTDD.Dominio.Exceptions;

namespace ProvaTDD.Dominio.Features.Alunos
{
    public class AlunoNomeVazioException : BusinessException
    {
        public AlunoNomeVazioException() : base("Aluno deve conter um nome válido")
        {
        }
    }
}