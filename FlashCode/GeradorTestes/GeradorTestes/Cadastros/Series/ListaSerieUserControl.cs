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

namespace GeradorTestes.Cadastros.Series
{
    public partial class ListaSerieUserControl : UserControl
    {
        SerieServico _serieServico = new SerieServico();
        public ListaSerieUserControl()
        {
            InitializeComponent();
            CarregaLista();
        }

        private void ListaSerieUserControl_Load(object sender, EventArgs e)
        {

        }
        public void CarregaLista()
        {
            ListBoxSeries.Items.Clear();

            foreach (var item in _serieServico.GetAllSeries()) 
            {
                ListBoxSeries.Items.Add(item);
            }
        }
        public Serie GetSelect()
        {
            Serie serie = ListBoxSeries.SelectedItem as Serie;
            return serie;
        }

    }
}
