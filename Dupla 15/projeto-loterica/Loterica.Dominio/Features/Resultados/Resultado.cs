using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Dominio.Features.Resultados
{
    public class Resultado : Entidade
    {
        public virtual List<int> NumerosSorteados { get; set; }

        public Resultado()
        {
            NumerosSorteados = new List<int>();
        }

        public override void Validar()
        {
            if (NumerosSorteados.Count < 6)
                throw new ResultadoNumerosSorteadosInsufficientException();
        }
    }
}
