using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Common.Tests.Base
{
    [ExcludeFromCodeCoverage]
    public static class ObjectMother
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

        public static Aposta GetNumerosInvalidosAposta(Concurso concurso)
        {
            List<int> numeros = new List<int>();
            numeros.Add(01);
            numeros.Add(02);
            numeros.Add(03);
            numeros.Add(04);
            numeros.Add(05);

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

        public static Concurso GetValidConcursoFechado()
        {
            List<int> numeros = new List<int>();
            numeros.Add(01);
            numeros.Add(02);
            numeros.Add(03);
            numeros.Add(04);
            numeros.Add(05);
            numeros.Add(06);

            Concurso concurso = new Concurso();
            concurso.Data = DateTime.Now;
            concurso.IsFechado = true;
            concurso.Resultado = new Resultado() { NumerosSorteados = numeros };

            return concurso;
        }

        public static Concurso GetValidConcursoAberto()
        {
            Concurso concurso = new Concurso();
            concurso.Id = 1;
            concurso.Data = DateTime.Now;
            concurso.IsFechado = false;
            concurso.Premio = 1000;

            return concurso;
        }

        public static Concurso GetValidConcursoAbertoComId(Resultado resultado)
        {
            Concurso concurso = new Concurso();
            concurso.Id = 1;
            concurso.Data = DateTime.Now;
            concurso.IsFechado = false;
            concurso.Resultado = resultado;
            concurso.Premio = 1000;

            return concurso;
        }

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

        public static Bolao GetBolaoValido()
        {
            Concurso concurso = ObjectMother.GetValidConcursoAberto();
            Bolao bolao = new Bolao();
            bolao.Apostas.Add(ObjectMother.GetValidAposta(concurso));
            bolao.Apostas.Add(ObjectMother.GetValidAposta(concurso));
            bolao.Apostas.Add(ObjectMother.GetValidAposta(concurso));
            bolao.Apostas.Add(ObjectMother.GetValidAposta(concurso));
            return bolao;
        }

        public static Bolao GetBolaoVazio()
        {
            return new Bolao();
        }
    }
}
