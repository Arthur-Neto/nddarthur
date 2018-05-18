using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Domain
{
    public class Livro
    {
        public Livro()
        {

        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Tema { get; set; }
        public string Autor { get; set; }
        public int Volume { get; set; }
        public DateTime DataPublicacao { get; set; }
        public bool Disponibilidade { get; set; }


        public void Validate()
        {
            if (Titulo.Length < 4 || String.IsNullOrEmpty(Titulo))
                throw new Exception("Deve ter um nome com mais de 4 caracteres!");
            if (Tema.Length < 4 || String.IsNullOrEmpty(Tema))
                throw new Exception("Deve ter um nome com mais de 4 caracteres!");
            if (Autor.Length < 4 || String.IsNullOrEmpty(Autor))
                throw new Exception("Deve ter um nome com mais de 4 caracteres!");
            if (Volume < 0)
                throw new Exception("O volume deve ser maior que 0!");
        }
        /// <summary>
        /// Retorna uma string customizada do objeto atual
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Id: {0} - Titulo: {1} - Autor: {2} - Disponibilidade {3}", Id, Titulo, Autor, Disponibilidade ? "Sim" : "Não");
        }

        public override bool Equals(object obj)
        {
            var livro = obj as Livro;
            if (livro != null)
            {
                return this.Id == livro.Id;
            }
            return base.Equals(obj);
        }

    }
}
