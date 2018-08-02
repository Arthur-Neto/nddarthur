using ProvaTDD.Dominio.Exceptions;

namespace ProvaTDD.Dominio.Features.Resultados
{
    public class ResultadoAlunoNuloException : BusinessException
    {
        public ResultadoAlunoNuloException() : base("O resultado deve conter um aluno")
        {
        }
    }
}