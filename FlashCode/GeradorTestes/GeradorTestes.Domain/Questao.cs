using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain
{
    public class Questao : Entidade
    {
        public Materia materia { get; set; }
        
        public string Bimestre { get; set; }

        public string Pergunta { get; set; }

        public Alternativas Alternativa { get; set; }
        
        public override string ToString()
        {
            string pergunta = string.Empty;
            pergunta = (Pergunta.Length > 30 ? Pergunta.Substring(0, 29) + " ..." : Pergunta);
            return pergunta;
        }

        public void Validacao()
        {

            if (Bimestre.Length < 1)
            {
                throw new Exception("Deve conter um bimestre");
            }

            if (materia == null)
            {
                throw new Exception("Deve conter uma matéria");
            }

            if (Pergunta.Length < 4)
            {
                throw new Exception("A pergunta não pode conter menos que 4 caracteres");
            }
            if(Pergunta.Length > 1000)
                throw new Exception("A pergunta não pode conter mais que mil caracteres");

            Alternativa.Valida();
        }
    }
}
