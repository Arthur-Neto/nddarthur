using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain
{
    public class Disciplina : Entidade
    {
        public string Nome { get; set; }

        public void Validacao()
        {
            if (string.IsNullOrEmpty(Nome) || Nome.Trim() == "")
                throw new Exception("O nome da Disciplina não pode ser em branco");

            if (Nome.Length < 4)
                throw new Exception("O nome da Disciplina deve ter mais que 4 caracteres");

            if (Nome.Length > 25)
                throw new Exception("O nome da Disciplina deve ser menor que 25 caracteres");

            if (ValidaNome())
                throw new Exception("Nome não pode conter números!");

            if (!System.Text.RegularExpressions.Regex.IsMatch(Nome.ToLower(), @"^[a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new Exception("Nome da disciplina não pode conter caracters especiais!");

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
        public override string ToString()
        {
            return  Nome;
        }

    }
}
