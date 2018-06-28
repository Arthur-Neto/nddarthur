using GeradorTestes.Domain;
using GeradorTestes.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.Cadastros
{
    public partial class CadastroSerieDialog : Form
    {
        private SerieServico _serieService;
        public CadastroSerieDialog(SerieServico serieService)
        {
            InitializeComponent();
            _serieService = serieService;
        }

        public Serie NovaSerie
        {
            get
            {
                var serie = new Serie();
                serie.Nome = mskSerie.Text;
                return serie;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                _serieService.Adicionar(NovaSerie);
                MessageBox.Show("Serie cadastrada", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }

        }

        private void CadastroSerieDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
