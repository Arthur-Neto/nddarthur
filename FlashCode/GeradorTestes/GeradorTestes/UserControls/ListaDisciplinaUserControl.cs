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

namespace GeradorTestes.UserControls
{
    public partial class ListaDisciplinaUserControl : UserControl
    {
        private DisciplinaServico _disciplinaService;

        public ListaDisciplinaUserControl(DisciplinaServico disciplinaService)
        {
            InitializeComponent();
            _disciplinaService = disciplinaService;
            CarregaLista();
        }
        public void CarregaLista()
        {
            listBox.Items.Clear();
            foreach(var item in _disciplinaService.GetAll())
            {
                listBox.Items.Add(item);
            }
        }
        public Disciplina GetSelect()
        {
            Disciplina disciplina = listBox.SelectedItem as Disciplina;
            return disciplina;
        }
    }
}
