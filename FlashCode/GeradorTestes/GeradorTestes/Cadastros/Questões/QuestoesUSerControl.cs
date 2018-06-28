using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorTestes.Servicos;
using GeradorTestes.Domain;

namespace GeradorTestes.Cadastros.Questões
{
    public partial class QuestoesUSerControl : UserControl
    {
        QuestoesServico _questoesServico = new QuestoesServico();

        public QuestoesUSerControl()
        {
            InitializeComponent();
            CarregaLista();
        }

        public void CarregaLista()
        {
            lbxQuestoes.Items.Clear();

            foreach (var item in _questoesServico.GetAll())
            {
                lbxQuestoes.Items.Add(item);
            }
        }
        public Questao GetSelect()
        {
            Questao questao = lbxQuestoes.SelectedItem as Questao;
            return questao;
        }

    }
}
