using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mariana.Dominio;

namespace Mariana.WinApp.Features.QuestaoModule
{
    public partial class QuestaoControlResposta : UserControl
    {
        public QuestaoControlResposta()
        {
            InitializeComponent();
        }

        internal void PopularListagemRespostas(IList<Resposta> respostas)
        {
            listBoxRespostas.Items.Clear();

            foreach (Resposta s in respostas)
            {
                listBoxRespostas.Items.Add(s);
            }
        }

        public Resposta GetResposta()
        {
            return listBoxRespostas.SelectedItem as Resposta;
        }
    }
}
