using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Common.Tests
{
    [ExcludeFromCodeCoverage]
    public static partial class ObjectMother
    {
        public static Aposta GetValidAposta(Concurso concurso)
        {
            List<int> numeros = new List<int>();
            numeros.Add(01);
            numeros.Add(02);
            numeros.Add(03);
            numeros.Add(04);
            numeros.Add(05);
            numeros.Add(06);

            return new Aposta()
            {
                Numeros = numeros,
                Data = DateTime.Now.AddDays(+1),
                Validade = DateTime.Now.AddDays(+7),
                Valor = 3.5m,
                Concurso = concurso
            };
        }

        public static Aposta GetValidApostaQuadra(Concurso concurso)
        {
            List<int> numeros = new List<int>();
            numeros.Add(01);
            numeros.Add(02);
            numeros.Add(03);
            numeros.Add(04);
            numeros.Add(12);
            numeros.Add(30);

            return new Aposta()
            {
                Numeros = numeros,
                Data = DateTime.Now.AddDays(+1),
                Validade = DateTime.Now.AddDays(+7),
                Valor = 3.5m,
                Concurso = concurso,
                NumerosAcertados = 4
                
            };
        }

        public static Aposta GetValidApostaQuina(Concurso concurso)
        {
            List<int> numeros = new List<int>();
            numeros.Add(01);
            numeros.Add(02);
            numeros.Add(03);
            numeros.Add(04);
            numeros.Add(05);
            numeros.Add(30);

            return new Aposta()
            {
                Numeros = numeros,
                Data = DateTime.Now.AddDays(+1),
                Validade = DateTime.Now.AddDays(+7),
                Valor = 3.5m,
                Concurso = concurso,
                NumerosAcertados = 5
            };
        }

        public static Aposta GetValidApostaSena(Concurso concurso)
        {
            List<int> numeros = new List<int>();
            numeros.Add(01);
            numeros.Add(02);
            numeros.Add(03);
            numeros.Add(04);
            numeros.Add(05);
            numeros.Add(06);

            return new Aposta()
            {
                Numeros = numeros,
                Data = DateTime.Now.AddDays(+1),
                Validade = DateTime.Now.AddDays(+7),
                Valor = 3.5m,
                Concurso = concurso,
                NumerosAcertados = 6
            };
        }

        public static Aposta GetNumerosInvalidosAposta(Concurso concurso)
        {
            List<int> numeros = new List<int>();
            numeros.Add(11);
            numeros.Add(22);
            numeros.Add(33);
            numeros.Add(44);
            numeros.Add(55);

            return new Aposta()
            {
                Numeros = numeros,
                Data = DateTime.Now.AddDays(+1),
                Validade = DateTime.Now.AddDays(+7),
                Valor = 3.5m,
                Concurso = concurso
            };
        }

        public static Aposta GetInValidAposta()
        {
            return GetNumerosInvalidosAposta(new Concurso() { });
        }

        public static Aposta GetDataInvalidaAposta(Concurso concurso)
        {
            List<int> numeros = new List<int>();
            numeros.Add(01);
            numeros.Add(02);
            numeros.Add(03);
            numeros.Add(04);
            numeros.Add(05);
            numeros.Add(06);

            return new Aposta()
            {
                Numeros = numeros,
                Data = DateTime.Now.AddDays(-2),
                Validade = DateTime.Now.AddDays(+7),
                Valor = 3.5m,
                Concurso = concurso
            };
        }

        public static Aposta GetConcursoInvalidoAposta()
        {
            List<int> numeros = new List<int>();
            numeros.Add(01);
            numeros.Add(02);
            numeros.Add(03);
            numeros.Add(04);
            numeros.Add(05);
            numeros.Add(06);

            return new Aposta()
            {
                Numeros = numeros,
                Data = DateTime.Now.AddDays(+1),
                Validade = DateTime.Now.AddDays(+7),
                Valor = 3.5m,
                Concurso = null
            };
        }

        public static Aposta GetValorInvalidoAposta(Concurso concurso)
        {
            List<int> numeros = new List<int>();
            numeros.Add(01);
            numeros.Add(02);
            numeros.Add(03);
            numeros.Add(04);
            numeros.Add(05);
            numeros.Add(06);

            return new Aposta()
            {
                Numeros = numeros,
                Data = DateTime.Now.AddDays(+1),
                Validade = DateTime.Now.AddDays(+7),
                Valor = 2.5m,
                Concurso = concurso
            };
        }
    }
}
