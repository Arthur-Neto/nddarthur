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

namespace Mariana.WinApp.Features.DisciplinaModule
{
    public partial class DisciplinaControl : UserControl
    {
        public DisciplinaControl()
        {
            InitializeComponent();
        }
        public void PopularListagemDisciplinas(IList<Disciplina> disciplina)
        {
            listDisciplinas.Items.Clear();

            foreach (Disciplina c in disciplina)
            {
                listDisciplinas.Items.Add(c);
            }
        }

        public Disciplina GetDisciplina()
        {
            return listDisciplinas.SelectedItem as Disciplina;
        }
    }
}
