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
    public partial class QuestaoControl : UserControl
    {
        public QuestaoControl()
        {
            InitializeComponent();
        }
        public void PopularListagemQuestoes(IList<Questao> questao)
        {
            listQuestoes.Items.Clear();

            foreach (Questao c in questao)
            {
                listQuestoes.Items.Add(c);
            }
        }

        public Questao GetQuestao()
        {
            return listQuestoes.SelectedItem as Questao;
        }
    }
}
