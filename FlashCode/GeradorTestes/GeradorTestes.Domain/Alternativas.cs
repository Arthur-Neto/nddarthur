using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain
{
    public class Alternativas : Entidade
    {
        public string A { get; set; }
        public string B{ get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string Correta { get; set; }

        public void Valida()
        {
            if (string.IsNullOrEmpty(A))
                throw new Exception("Alternativa A não está preenchida");

            if (string.IsNullOrEmpty(B))
                throw new Exception("Alternativa B não está preenchida");

            if (string.IsNullOrEmpty(C))
                throw new Exception("Alternativa C não está preenchida");

            if (string.IsNullOrEmpty(D))
                throw new Exception("Alternativa D não está preenchida");

            if (A.Equals(B)
                || A.Equals(C)
                || A.Equals(D)
                || B.Equals(C)
                || B.Equals(D)
                || C.Equals(D))
            {
                throw new Exception("Existem alternativas que são iguais");
            }
            
        }

        public string RetornaLetraAlternativaCorreta()
        {
            if (A.Equals(Correta.Trim()))
                return "A";
            else if (B.Equals(Correta.Trim()))
                return "B";
            else if (C.Equals(Correta.Trim()))
                return "C";
            else
                return "D";
        }
    }
}
