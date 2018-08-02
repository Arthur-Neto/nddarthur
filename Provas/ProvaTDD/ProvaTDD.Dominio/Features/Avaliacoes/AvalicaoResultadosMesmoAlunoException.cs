using ProvaTDD.Dominio.Exceptions;

namespace ProvaTDD.Dominio.Features.Avaliacoes
{
    public class AvalicaoResultadosMesmoAlunoException : BusinessException
    {
        public AvalicaoResultadosMesmoAlunoException() : base("Não deve conter mais que um resultado para um aluno")
        {
        }
    }
}