using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;

namespace Loterica.Dominio.Features.Apostas
{
    public enum EstadoAposta
    {
        PERDEDORA = 0, GANHADORA_QUADRA, GANHADORA_QUINA, GANHADORA_SENA
    }

    public class Aposta : Entidade
    {
        public virtual List<int> Numeros { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual Concurso Concurso { get; set; }
        public virtual DateTime Validade { get; set; }
        public virtual decimal Valor { get; set; }        
        public virtual int NumerosAcertados { get; set; }

        public Aposta()
        {
            Numeros = new List<int>();
        }

        public virtual EstadoAposta IsGanhadora()
        {
            if (NumerosAcertados == 6)
                return EstadoAposta.GANHADORA_SENA;
            else if (NumerosAcertados == 5)
                return EstadoAposta.GANHADORA_QUINA;
            else if (NumerosAcertados == 4)
                return EstadoAposta.GANHADORA_QUADRA;
            else
                return EstadoAposta.PERDEDORA;
        }

        public virtual int NumerosAcertos()
        {
            int numerosAcertados = 0;
            foreach (int numero in Concurso.Resultado.NumerosSorteados)
            {
                if (this.Numeros.Contains(numero))
                    numerosAcertados++;
            }
            return numerosAcertados;
        }

        public override void Validar()
        {
            if (Numeros.Count < 6)
                throw new ApostaNumeroInsufficientException();
            if (Concurso == null)
                throw new ApostaConcursoNullException();
            if (Data < Concurso.Data)
                throw new ApostaDateOverflowException();
            if (Valor < 3.5m)
                throw new ApostaValorInsufficientException();
        }
    }
}
