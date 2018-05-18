using Mariana.Dominio.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Mariana.Dominio
{
    public class Materia : Entidade
    {
        public Disciplina Disciplina { get; set; }
        public string Nome { get; set; }
        public Serie Serie { get; set; }
        public Materia()
        {
            Disciplina = new Disciplina();
            Serie = new Serie();
        }

        public override string ToString()
        {
            return String.Format("Nome: {0} - Disciplina: {1} - {2}º Série ", Nome, Disciplina.Nome, Serie.NumeroSerie);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Validar()
        {
            if (Nome.Length < 4 || Nome.Length > 30)
                throw new ValidacaoException("O Nome da matéria não pode ser menor que 4 e maior que 30 catacteres.");

            if (string.IsNullOrWhiteSpace(Nome))
                throw new ValidacaoException("O Nome não pode estar vazio");

            if (Serie == null)
                throw new ValidacaoException("Deve selecionar uma Série");

            if (Disciplina == null)
                throw new ValidacaoException("Deve selecionar uma Disciplina");

            if (!Regex.IsMatch(Nome, @"^[a-zA-Z_áéíóúàèìòùâêîôûãõçÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÃÕ\s]*$"))
            {
                if (Regex.IsMatch(Nome, @"^\d+"))
                    throw new ValidacaoException("Nome da materia não pode ser somente números e caracteres especiais");
            }
        }
    }
}