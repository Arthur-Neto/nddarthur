using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Dominio.Features.Avaliacoes
{
    public class Avaliacao : Entidade
    {
        public Avaliacao()
        {
            Resultados = new List<Resultado>();
        }

        public string Assunto { get; set; }
        public DateTime Data { get; set; }
        public IList<Resultado> Resultados { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrWhiteSpace(Assunto))
                throw new AvaliacaoAssuntoVazioException();

            if (Resultados.Count != Resultados.Distinct().Count())
                throw new AvalicaoResultadosMesmoAlunoException();
        }
    }
}
