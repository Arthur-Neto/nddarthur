using ProvaTDD.Dominio.Features.Avaliacoes;
using ProvaTDD.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;

namespace ProvaTDD.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Avaliacao ObterAvaliacaoValida()
        {
            return new Avaliacao()
            {
                Assunto = "Matematica",
                Data = DateTime.Now,
            };
        }

        public static Avaliacao ObterAvaliacaoComResultados()
        {
            return new Avaliacao()
            {
                Assunto = "Matematica",
                Data = DateTime.Now,
                Resultados = new List<Resultado>() { ObterResultadoValidoComAluno() }
            };
        }
        public static Avaliacao ObterAvaliacaoComResultadosNotaCincoMeio()
        {
            return new Avaliacao()
            {
                Assunto = "Matematica",
                Data = DateTime.Now,
                Resultados = new List<Resultado>() { ObterResultadoValidoComAlunoNotaCincoMeio() }
            };
        }
        public static Avaliacao ObterAvaliacaoComResultadosAlunoNotaSeis()
        {
            return new Avaliacao()
            {
                Assunto = "Matematica",
                Data = DateTime.Now,
                Resultados = new List<Resultado>() { ObterResultadoValidoComAlunoNotaSeis() }
            };
        }
    }
}
