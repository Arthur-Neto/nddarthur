using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Dominio.Features.Apostas
{
    public class Aposta : Entidade
    {
        public virtual List<int> Numeros { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual Concurso Concurso { get; set; }
        public virtual DateTime Validade { get; set; }
        public virtual decimal Valor { get; set; }

        private int _numerosAcertados { get; set; }
        public virtual int NumerosAcertados
        {
            get
            {
                return NumerosAcertos();
            }
            set
            {
                _numerosAcertados = value;
            }
        }

        public Aposta()
        {
            Numeros = new List<int>();
        }

        public virtual bool IsGanhadora()
        {
            if (NumerosAcertos() >= 4)
                return true;
            else
                return false;
        }

        private int NumerosAcertos()
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
