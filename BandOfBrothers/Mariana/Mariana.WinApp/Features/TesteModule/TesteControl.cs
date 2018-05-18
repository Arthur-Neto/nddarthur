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

namespace Mariana.WinApp.Features.ExercicioModule
{
    public partial class TesteControl : UserControl
    {
        public TesteControl()
        {
            InitializeComponent();
        }

        public void PopularListagemTestes(IList<Teste> teste)
        {
            listTestes.Items.Clear();

            foreach (Teste c in teste)
            {
                listTestes.Items.Add(c);
            }
        }

        public Teste GetTeste()
        {
            return listTestes.SelectedItem as Teste;
        }
    }
}
