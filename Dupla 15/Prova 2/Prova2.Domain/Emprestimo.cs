using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Domain
{
    public class Emprestimo
    {
        public Emprestimo()
        {
            Livro = new Livro();
        }

        public int Id { get; set; }
        public string Cliente { get; set; }
        public Livro Livro { get; set; }
        public DateTime DataDevolucao { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0} - Titulo: {1} - Cliente: {2} - Data de Devolução: {3}", Id, Livro.Titulo, Cliente, DataDevolucao);
        }
        public override bool Equals(object obj)
        {
            var emprestimo = obj as Emprestimo;
            if (emprestimo != null)
            {
                return this.Id == emprestimo.Id;
            }
            return base.Equals(obj);
        }

        double multa = 2.50;

        /// <summary>
        /// Multa: Dias de atraso x 2,50
        /// </summary>
        public double CalculaMulta
        {
            get
            {
                //return (DateTime.Now.Day - DataDevolucao.Day) * multa;
                return (DateTime.Now.DayOfYear - DataDevolucao.DayOfYear) * multa;
            }
        }


    }


}
