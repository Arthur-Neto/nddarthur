using Mariana.Dominio.Exceptions;
using System;
using System.Collections.Generic;

namespace Mariana.Dominio
{
    public class Questao : Entidade
    {
        public string Enunciado { get; set; }
        public Bimestre Bimestre { get; set; }
        public Materia Materia { get; set; }
        public Disciplina Disciplina { get; set; }
        public IList<Resposta> Respostas { get; set; }

        public Questao()
        {
            Materia = new Materia();
            Disciplina = new Disciplina();
            Respostas = new List<Resposta>();
        }

        public override string ToString()
        {
            return String.Format("Enunciado: {0} - Disciplina: {1} - Matéria: {2} - {3}º Série", Enunciado, Disciplina.Nome, Materia.Nome, Materia.Serie.NumeroSerie);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Validar()
        {
            if (Enunciado.Length < 4 || Enunciado.Length > 500)
                throw new ValidacaoException("O enunciado deve conter pelo menos 4 caracteres e não pode ultrapassar 500 caracteres.");

            if (string.IsNullOrWhiteSpace(Enunciado))
                throw new ValidacaoException("O enunciado não pode estar vazio");

            if (Materia == null)
                throw new ValidacaoException("A matéria não pode estar vazia.");

            if (Disciplina == null)
                throw new ValidacaoException("A disciplina não pode estar vazia.");
        }

        public void ValidarListaRespostas(IList<Resposta> respostas)
        {
            if (respostas.Count < 2)
            {
                throw new ValidacaoException("A lista de respostas deve conter pelo menos duas respostas.");
            }

            if (respostas.Count > 6)
            {
                throw new ValidacaoException("A lista de respostas não deve ser maior do que seis respostas.");
            }

            int count = 0;
            foreach (var item in respostas)
            {
                if (item.Correta == true)
                    count++;
            }
            if (count != 1)
                throw new Exception(String.Format("Deve cadastrar somente uma resposta correta."));
        }
    }


}
