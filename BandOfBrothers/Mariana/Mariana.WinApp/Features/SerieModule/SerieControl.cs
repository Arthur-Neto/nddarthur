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

namespace Mariana.WinApp.Features.SerieModule
{
    public partial class SerieControl : UserControl
    {
        public SerieControl()
        {
            InitializeComponent();
        }

        internal void PopularListagemSeries(IList<Serie> series)
        {
            listSeries.Items.Clear();

            foreach (Serie s in series)
            {
                listSeries.Items.Add(s);
            }
        }

        public Serie GetSerie()
        {
            return listSeries.SelectedItem as Serie;
        }

    }
}
