using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mariana.Dominio
{
    public class Teste : Entidade
    {
        public DateTime DataTesteGerado { get; set; }
        public int NumeroQuestoes { get; set; }
        public IList<Questao> Questoes { get; set; }
        public string Nome { get; set; }
        public string CaminhoDestino { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public Serie Serie { get; set; }


        public Teste()
        {
            Disciplina = new Disciplina();
            Serie = new Serie();
            Materia = new Materia();
            Questoes = new List<Questao>();
        }

        public override string ToString()
        {
            return String.Format("Descrição: {0} - Disciplina: {1} - Matéria: {2} - Série: {3} - Data do Teste: {4} - Número de Questões: {5}", Nome, Disciplina.Nome, Materia.Nome, Serie.NumeroSerie, DataTesteGerado, NumeroQuestoes);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Validar()
        {
            if (Nome.Length < 4 || Nome.Length > 30)
                throw new Exception("O NomeTeste do Teste não pode ser menor que 4 e maior que 30 catacteres.");

            if (string.IsNullOrWhiteSpace(Nome))
                throw new Exception("O Nome não pode estar vazio");

            if (string.IsNullOrWhiteSpace(CaminhoDestino))
                throw new Exception("O Caminho de destino não pode estar vazio");

            if (Serie == null)
                throw new Exception("Deve selecionar uma Série");

            if (Disciplina == null)
                throw new Exception("Deve selecionar uma Disciplina");

            if (Materia == null)
                throw new Exception("Deve Selecionar um Matéria");

            if (!Regex.IsMatch(Nome, @"^[a-zA-Z_áéíóúàèìòùâêîôûãõçÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÃÕ\s]*$"))
            {
                if (Regex.IsMatch(Nome, @"^\d+"))
                    throw new Exception("Nome da materia não pode ser somente números e caracteres especiais");
            }
        }
    }
}
