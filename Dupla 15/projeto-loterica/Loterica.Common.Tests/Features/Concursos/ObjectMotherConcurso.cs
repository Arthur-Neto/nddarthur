using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;

namespace Loterica.Common.Tests
{
    public static partial class ObjectMother
    {
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
            concurso.Resultado = GetValidResultado();

            return concurso;
        }

        public static Concurso GetValidConcursoComApostas()
        {
            Concurso concurso = new Concurso();
            concurso.Id = 1;
            concurso.Data = DateTime.Now;
            concurso.IsFechado = false;
            concurso.Resultado = ObjectMother.GetValidResultado();
            concurso.Apostas.Add(GetValidApostaQuadra(concurso));
            concurso.Apostas.Add(GetValidApostaQuina(concurso));
            concurso.Apostas.Add(GetValidApostaSena(concurso));
            concurso.Apostas.Add(GetNumerosInvalidosAposta(concurso));
            concurso.Apostas.Add(GetNumerosInvalidosAposta(concurso));

            return concurso;
        }

        public static Concurso GetValidConcursoFechadoComApostas()
        {
            Concurso concurso = new Concurso();
            concurso.Id = 1;
            concurso.Data = DateTime.Now;
            concurso.Resultado = ObjectMother.GetValidResultado();
            concurso.Apostas.Add(GetValidApostaQuadra(concurso));
            concurso.Apostas.Add(GetValidApostaQuina(concurso));
            concurso.Apostas.Add(GetValidApostaSena(concurso));
            concurso.Apostas.Add(GetNumerosInvalidosAposta(concurso));
            concurso.Apostas.Add(GetNumerosInvalidosAposta(concurso));
            concurso.FecharConcurso();

            return concurso;
        }

        public static Concurso GetValidConcursoComApostaseBolao()
        {
            Concurso concurso = GetValidConcursoComApostas();
            concurso.Boloes.Add(GetBolaoValido());

            return concurso;
        }

        public static Concurso GetValidConcursoComApostaseBolaoQuadraQuinaeSena()
        {
            Concurso concurso = GetValidConcursoComApostas();
            concurso.Boloes.Add(GetBolaoValidoComApostasSenaQuinaeQuadra());

            return concurso;
        }

        public static Concurso GetValidConcursoAbertoComId(Resultado resultado)
        {
            Concurso concurso = new Concurso();
            concurso.Id = 1;
            concurso.Data = DateTime.Now;
            concurso.IsFechado = false;
            concurso.Resultado = resultado;
            concurso.Premio.Total = 1000;

            return concurso;
        }

        public static List<Concurso> GetConcursos()
        {
            List<Concurso> _concursos = new List<Concurso>();

            _concursos.Add(GetValidConcursoAberto());

            return _concursos;
        }
    }
}
