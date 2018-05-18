using Mariana.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mariana.WinApp.Features.SerieModule
{
    public partial class frmCadastroSerie : Form
    {
        private Serie serie;

        public frmCadastroSerie()
        {
            InitializeComponent();
            btnCadastrar.Focus();
        }

        public Serie NovaSerie
        {
            get
            {
                return serie;
            }
            set
            {
                serie = value;
            }
        }

       private void numericUpDownSerie_keyDown(object sender , KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                btnCadastrar.PerformClick();
            }
            if(e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                serie.NumeroSerie = Convert.ToInt32(numericUpDownSerie.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                DialogResult = DialogResult.None;
            }
        }
    }
}
