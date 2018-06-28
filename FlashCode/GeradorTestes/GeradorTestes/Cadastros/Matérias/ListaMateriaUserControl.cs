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

namespace GeradorTestes.Cadastros.Matérias
{
    public partial class ListaMateriaUserControl : UserControl
    {
        MateriaServico _materiaServico = new MateriaServico();
        public ListaMateriaUserControl()
        {
            InitializeComponent();
            CarregaLista();
        }

        public void CarregaLista()
        {
            lbxMaterias.Items.Clear();

            foreach (var item in _materiaServico.GetAllMaterias())
            {
                lbxMaterias.Items.Add(item);
            }
        }
        public Materia GetSelect()
        {
            Materia materia = lbxMaterias.SelectedItem as Materia;
            return materia;
        }
    }

}
