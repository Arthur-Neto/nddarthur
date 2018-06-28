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
        private SerieServico _serieServico;

        public CadastroSerieDialog(SerieServico serieServico, string titulo, Serie serie = null)
        {

            InitializeComponent();
            this.Text = titulo;
            _serieServico = serieServico;
            NovaSerie = serie;
            if (NovaSerie != null)
            {
                mskSerie.Text = NovaSerie.Nome;
            }

        }
        private Serie _novaSerie;
        public Serie NovaSerie
        {
            get
            {
                return _novaSerie;
            }
            set
            {
                _novaSerie = value;
            }
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (NovaSerie != null)
                {
                    if (NovaSerie.Nome.Trim() == mskSerie.Text.Trim())
                        return;
                    NovaSerie.Nome = mskSerie.Text;
                    _serieServico.Editar(NovaSerie);
                    MessageBox.Show("Serie Editada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    NovaSerie = new Serie();
                    NovaSerie.Nome = mskSerie.Text;
                    _serieServico.Adicionar(NovaSerie);
                    MessageBox.Show("Serie Adicionada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                NovaSerie = null;
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadastroSerieDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
