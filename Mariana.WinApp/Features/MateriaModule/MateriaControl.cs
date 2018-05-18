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

namespace Mariana.WinApp.Features.MateriaModule
{
    public partial class MateriaControl : UserControl
    {
        public MateriaControl()
        {
            InitializeComponent();
        }
        public void PopularListagemMaterias(IList<Materia> materia)
        {
            listMaterias.Items.Clear();

            foreach (Materia c in materia)
            {
                listMaterias.Items.Add(c);
            }
        }

        public Materia GetMateria()
        {
            return listMaterias.SelectedItem as Materia;
        }
    }
}
