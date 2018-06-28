using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain
{
    public class Teste : Entidade
    {       
        public string Descricao { get; set; }
        public Questao questao { get; set; }
        public Questao GetQuestao()
        {
            return listaQuestao[0];
        }
        public IList<Questao> listaQuestao { get; set; }

        public DateTime dataGeracao { get; set; }

        public int QuantidadeQuestoes { get; set; }
        
        public override string ToString()
        {
            return string.Format("Data de geração: " + dataGeracao.Day +"/"+dataGeracao.Month+"/" + dataGeracao.Year +"     -      "+"Quantidade de questões: "+ QuantidadeQuestoes);
        }
    }
}
