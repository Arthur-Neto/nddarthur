using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;

namespace Loterica.Dominio.Features.Resultados
{
    public class Resultado : Entidade
    {
        public virtual List<int> NumerosSorteados { get; set; }
        public decimal MediaQuadra { get; set; }
        public decimal MediaQuina { get; set; }
        public decimal MediaSena { get; set; }

        public Resultado()
        {
            NumerosSorteados = new List<int>() { 0, 0, 0, 0, 0, 0 };
        }

        public void GerarNovosNumeros()
        {
            Random random = new Random();
            NumerosSorteados.Clear();
            var num = 1;
            for (int j = 0; j < 6; j++)
            {
                while (NumerosSorteados.Contains(num))
                    num = random.Next(1, 60);

                NumerosSorteados.Add(num);
            }
            NumerosSorteados.Sort();
        }

        public void CalcularMediaPremio(Concurso concurso)
        {
            var ganhadores = concurso.Ganhadores.Quadra;

            if (ganhadores != 0)
                MediaQuadra = concurso.Premio.Quadra / ganhadores;

            ganhadores = concurso.Ganhadores.Quina;

            if (ganhadores != 0)
                MediaQuina = concurso.Premio.Quina / ganhadores;

            ganhadores = concurso.Ganhadores.Sena;
            if (ganhadores != 0)
                MediaSena = concurso.Premio.Sena / ganhadores;
        }

        public override void Validar()
        {
            if (NumerosSorteados.Count < 6)
                throw new ResultadoNumerosSorteadosInsufficientException();
        }
    }
}
