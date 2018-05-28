using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Resultados;
using System.Collections.Generic;

namespace Loterica.Common.Tests
{
    public static partial class ObjectMother
    {
        public static Resultado GetValidResultado()
        {
            List<int> numeroSorteados = new List<int>();
            numeroSorteados.Add(01);
            numeroSorteados.Add(02);
            numeroSorteados.Add(03);
            numeroSorteados.Add(04);
            numeroSorteados.Add(05);
            numeroSorteados.Add(06);


            return new Resultado()
            {
                NumerosSorteados = numeroSorteados
            };
        }

        public static Resultado GetResultadoNumeroSorteadosInsufficient(Concurso concurso)
        {
            List<int> numeroSorteados = new List<int>();
            numeroSorteados.Add(01);
            numeroSorteados.Add(02);
            numeroSorteados.Add(03);
            numeroSorteados.Add(04);
            numeroSorteados.Add(05);

            return new Resultado()
            {
                NumerosSorteados = numeroSorteados
            };
        }

    }
}
