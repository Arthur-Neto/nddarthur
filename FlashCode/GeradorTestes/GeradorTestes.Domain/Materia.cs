using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain
{
    public class Materia : Entidade
    {
        public Serie serie { get; set; }
        public string Nome { get; set; }
        public Disciplina disciplina { get; set; }

        public override string ToString()
        {
            return String.Format(Nome);
        }

        public void Valida()
        {
            if(disciplina == null)
                throw new Exception("A Disciplina não pode ser nula");
            if (serie == null)
                throw new Exception("A série não pode ser nula");
            if (string.IsNullOrEmpty(Nome) || Nome.Trim() == "")
                throw new Exception("O nome da Matéria não pode ser em branco");
            if (Nome.Length > 25)
                throw new Exception("O nome da Matéria não pode conter mais que 25 caracteres");
            if (Nome.Length < 4)
                throw new Exception("O nome da Matéria não pode conter menos que 4 caracteres");        
            if (ValidaNome())
                throw new Exception("O nome da Matéria não pode conter números, favor utilizar algarismos romanos.");
            if (!System.Text.RegularExpressions.Regex.IsMatch(Nome.ToLower(), @"^[a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new Exception("Nome da disciplina não pode conter caracteres especiais");
        }

        private bool ValidaNome()
        {
            string numeros = "0123456789";
            for (int i = 0; i < Nome.Length; i++)
            {
                if (numeros.Contains(Nome[i]))
                    return true;
            }
            return false;
        }
    }
}
