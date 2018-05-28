using System;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Dominio.Features.Resultados
{
    [ExcludeFromCodeCoverage]
    public class ResultadoSemGanhadoresException : Exception
    {
        public ResultadoSemGanhadoresException() : base("Não existe ganhadores")
        {
        }
    }
}
