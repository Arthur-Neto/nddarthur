using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Features.Avaliacoes;
using System;
using System.Collections.Generic;

namespace ProvaTDD.Dominio.Features.Alunos
{
    public class Aluno : Entidade
    {
        public string Nome { get; set; }
        public short Idade { get; set; }
        public double Media { get; set; }

        public void CalcularMedia(IList<Avaliacao> avaliacoes)
        {
            foreach (var avaliacao in avaliacoes)
            {
                foreach (var resultado in avaliacao.Resultados)
                {
                    Media += resultado.Nota;
                }
            }
            Media /= avaliacoes.Count;
            ArredondarMedia();
        }

        private void ArredondarMedia()
        {
            var decimais = Media - Math.Floor(Media);
            if (decimais < 0.35)
                Media = Math.Ceiling(Media);
            else if (decimais < 0.75)
                Media = Math.Round(Media * 2) / 2;
            else
                Media = Math.Ceiling(Media);


        }

        public override void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new AlunoNomeVazioException();
            if (Idade < 0)
                throw new AlunoIdadeInvalidaException();
        }
    }
}
